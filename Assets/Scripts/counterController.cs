using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterController : MonoBehaviour
{
    private enum lojinha {PararOTempo,menosVirus,maisHemacias,comprarGlobulos};
    private lojinha loja;
    private bool pT = false, mV = false, mH = false, cG = false;
    private float pont = 25;     
    [SerializeField]
    private Text texto;

    void Update() 
    {
        texto.text = pont.ToString();
        print(pont);
    }
    void compras()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pT = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            mV = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mH = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            cG = true;
        }
    }
    public void cont(float up)
    {
        pont = pont + up;
    }
}
