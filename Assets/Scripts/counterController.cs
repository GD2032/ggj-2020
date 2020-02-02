using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterController : MonoBehaviour
{
    public float pont = 25;     
    [SerializeField]
    private Text texto;
    [SerializeField]
    private Animator animado;

    void Update() 
    {
        textin();
        animação();
    }
    void animação() 
    {
        animado.SetBool("comprar reparamento", false);
        animado.SetFloat("pont", pont);
    }
    void textin() 
    {
        texto.text = pont.ToString();
        print(pont);
    }
    public void cont(float up)
    {
        pont = pont + up;
    }
}
