using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterController : MonoBehaviour
{
    public float pont = 25, gbQuant = 0;
    [SerializeField]
    private Text texto,gbtext;
    [SerializeField]
    private Animator animado;

    void Update() 
    {
        textin();
        animação();
        print(pont);
    }
    void animação() 
    {
        animado.SetBool("comprar reparamento", false);
        animado.SetFloat("pont", pont);
    }
    void textin() 
    {
        texto.text = pont.ToString();
        gbtext.text = gbQuant.ToString();
    }
    public void cont(float up)
    {
        pont = pont + up;
    }
}
