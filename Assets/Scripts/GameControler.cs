using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject virus, canvas;
    float cd;
    bool Spawn;

    void Start()
    {
        Spawn = true;
        cd = 2f;
    }
    // Update is called once per frame
    void Update()
    {
        GerarVirus();
    }
    private void GerarVirus()
    {
        if (Spawn)
        {
            Instantiate(virus, GerarPosicao(), Quaternion.identity, canvas.transform);
            Spawn = !Spawn;
            StartCoroutine(Cooldown(cd));
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
    IEnumerator Cooldown(float cd) 
    {
        yield return new WaitForSeconds(cd);
        Spawn = true;
    }
    
}
