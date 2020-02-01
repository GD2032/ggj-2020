using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject virus,hemacia,canvas;
    float cdV,cdH;
    bool SpawnV,SpawnH;

    void Start()
    {
        SpawnV = true;
        SpawnH = true;
        cdV = 2f;
        cdH = 9f;
    }
    // Update is called once per frame
    void Update()
    {
        GerarVirus();
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
        int typePosition = 0;
        switch (typePosition)
        {
            case 0:
                return new Vector3(-70, Random.Range(450, -110));
                break;
        }
        return new Vector3(0,0,0);
    }
    IEnumerator CooldownV(float cd) 
    {
        yield return new WaitForSeconds(cd);
        SpawnV = true;
    }
    IEnumerator CooldownH(float cd)
    {
        yield return new WaitForSeconds(cd);
        SpawnH = true;
    }

}
