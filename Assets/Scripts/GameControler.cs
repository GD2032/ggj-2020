using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject hemacia, clone;
    float cdV, cdH;
    [SerializeField] GameObject virus, globuloB, spawnPoint;
    private Collider2D[] irus;
    [SerializeField]
    bool SpawnV, SpawnH, maisHemacias, menosVirus;
    [SerializeField] Canvas canvas;
    float cd;
    public float quantG;
    counterController pontos;
    public bool podeUsar;
    bool Spawn, poderUm, poderDois, poderTres, poderQuatro, poderCinco;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        pontos = GameObject.FindGameObjectWithTag("pont").GetComponent<counterController>();
        quantG = 5;
        m_Raycaster = GameObject.FindWithTag("canva").GetComponent<GraphicRaycaster>();
        m_EventSystem = GameObject.FindWithTag("canva").GetComponent<EventSystem>();
        SpawnV = true;
        SpawnH = true;
        maisHemacias = false;
        menosVirus = false;
        poderCinco = true;
        poderQuatro = true;
        poderTres = true;
        poderDois = true;
        poderUm = true;
        cdV = 2f;
        cdH = 9f;
    }
    // Update is called once per frame
    void Update()
    {
        pontos.gbQuant = quantG;
        irus = Physics2D.OverlapCircleAll(transform.position, 1);
        GerarVirus();
        CliqueMouse();
    }
    private void CliqueMouse()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            foreach (RaycastResult result in results)
            {
                switch (result.gameObject.tag)
                {
                    case "globuloLoja":
                        if (poderUm && quantG <= 10)
                            StartCoroutine(Coold(2));
                        goto case "a";
                    case "tempoLoja":
                        menosVirus = true;
                        SpawnV = false;
                        StartCoroutine(CooldownMV());
                        goto case "a";
                    case "freezeLoja":
                        goto case "a";
                    case "aumentoHemaciaLoja":
                        maisHemacias = true;
                        SpawnH = true;
                        StartCoroutine(CooldownMH());
                        goto case "a";
                    case "diminuir1":
                        goto case "a";
                    case "a":
                        result.gameObject.GetComponent<CoolDown>().Clique();
                        break;
                }
            }
        }
    }
    private void GerarVirus()
    {
        if (SpawnV)
        {
            clone = Instantiate(virus, GerarPosicao(), Quaternion.identity, canvas.transform);
            clone.transform.SetSiblingIndex(2);
            clone.GetComponent<RectTransform>().anchoredPosition = GerarPosicao();

            SpawnV = !SpawnV;
            StartCoroutine(CooldownV(cdV));
        }
        if (SpawnH)
        {
            clone = Instantiate(hemacia, GerarPosicao(), Quaternion.identity, canvas.transform);
             clone.transform.SetSiblingIndex(2);
            clone.GetComponent<RectTransform>().anchoredPosition = GerarPosicao();
            SpawnH = !SpawnH;   
            StartCoroutine(CooldownH(cdH));
        }

    }

    private Vector3 GerarPosicao()
    {
        int typePosition = Random.Range(0, 4);
        switch (typePosition)
        {
            case 0:
                return new Vector3(-400, Random.Range(-450, 400));
                break;
            case 1:
                return new Vector3(400, Random.Range(-450, 400));
                break;
            case 2:
                return new Vector3(Random.Range(-300, 300), -400);
                break;
            case 3:
                return new Vector3(Random.Range(-300, 300), 430);
                break;
        }
        return new Vector3(0, 0, 0);
    }
    IEnumerator CooldownV(float cd)
    {
        yield return new WaitForSeconds(cd);
        SpawnV = true;
    }
    IEnumerator CooldownH(float cd)
    {
        if (!maisHemacias)
        {
            yield return new WaitForSeconds(cd);
            SpawnH = true;
        }
        else if (maisHemacias)
        {
            yield return new WaitForSeconds(3f);
            SpawnH = true;
        }
    }
    IEnumerator CooldownMH()
    {
        yield return new WaitForSeconds(6.5f);
        maisHemacias = false;
    }
    IEnumerator CooldownMV()
    {
        yield return new WaitForSeconds(12f);
        menosVirus = false;
        SpawnV = true;
    }

    IEnumerator Coold(int cd)
    {
        poderUm = false;
        clone = Instantiate(globuloB, Vector2.zero, Quaternion.identity, canvas.transform);
        clone.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 80);
        quantG++;
        yield return new WaitForSeconds(cd);
        poderUm = true;
    }
}
