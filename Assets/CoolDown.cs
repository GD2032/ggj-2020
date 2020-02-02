using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    private float tempoCd, cd;
    public bool podeClicar;

    void Start()
    {
       podeClicar = true;
       transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
        switch (transform.tag)
        {
            case "globuloBranco":
                tempoCd = 5;
                break;
            case "tempoLoja":
                tempoCd = 10;
                break;
            case "freezeLoja":
                tempoCd = 20;
                break;

        }
    }
    void Update() 
    {
        if (cd >= 0)
        {
            cd -= Time.deltaTime;
            transform.GetChild(0).GetComponent<Image>().fillAmount = cd / tempoCd;
        }
        else 
        {
            podeClicar = true;
        }

        
    }
    public void Clique() 
    {
        if(podeClicar)
        {
            podeClicar = !podeClicar;
            cd = tempoCd;    
        }
    }
}
