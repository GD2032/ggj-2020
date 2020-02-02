using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject hemacia;
    float cdV, cdH;
    [SerializeField]
    bool SpawnV, SpawnH, maisHemacias, menosVirus;
    [SerializeField] GameObject virus;
    [SerializeField] Canvas canvas;
    float cd;
    bool Spawn;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        m_Raycaster = GameObject.FindWithTag("canva").GetComponent<GraphicRaycaster>();
        m_EventSystem = GameObject.FindWithTag("canva").GetComponent<EventSystem>();
        SpawnV = true;
        SpawnH = true;
        maisHemacias = false;
        menosVirus = false;
        cdV = 2f;
        cdH = 9f;
    }
    // Update is called once per frame
    void Update()
    {
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
                print(result.gameObject.tag);
                switch (result.gameObject.tag)
                {
                    case "globuloBranco":
                        goto case "a";
                    case "tempoLoja":
                        menosVirus = true;
                        SpawnV = false;
                        StartCoroutine(CooldownMV());
                        break;
                        goto case "a";
                    case "freezeLoja":
                        
                        goto case "a";
                    case "aumentoHemaciaLoja":
                        maisHemacias = true;
                        SpawnH = true;
                        StartCoroutine(CooldownMH());
                        break;
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
            Instantiate(virus, GerarPosicao(), Quaternion.identity, canvas.transform);
            SpawnV = !SpawnV;
            StartCoroutine(CooldownV(cdV));
        }
        if (SpawnH)
        {
            Instantiate(hemacia, GerarPosicao(), Quaternion.identity, canvas.transform);
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
                return new Vector3(-70, Random.Range(450, -110));
                break;
            case 1:
                return new Vector3(600, Random.Range(450, -110));
                break;
            case 2:
                return new Vector3(Random.Range(-70, 600), 450);
                break;
            case 3:
                return new Vector3(Random.Range(-70, 600), -110);
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
}
