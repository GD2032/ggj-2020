using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterController : MonoBehaviour
{
    public float pont = 25, gbQuant = 0;
    [SerializeField]
    private Text texto, gbtext;
    [SerializeField]
    private Animator animado;
    [SerializeField]
    GameObject[] JOJO;
    void Update() 
    {
        if (pont > 24 &&  pont < 76)
        {
            JOJO[0].SetActive(true);
            JOJO[1].SetActive(false);
            JOJO[2].SetActive(false);
            JOJO[3].SetActive(false);
        }
        else if(pont < 25 && pont > 10)
        {
            JOJO[0].SetActive(false);
            JOJO[1].SetActive(false);
            JOJO[2].SetActive(true);
            JOJO[3].SetActive(false);
        }
        else if(pont < 11) 
        {
            JOJO[0].SetActive(false);
            JOJO[1].SetActive(false);
            JOJO[3].SetActive(true);
            JOJO[2].SetActive(false);
        }
        else if (pont > 75)
        {
            JOJO[0].SetActive(false);
            JOJO[1].SetActive(true);
            JOJO[2].SetActive(false);
            JOJO[3].SetActive(false);
        }
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
        gbtext.text = gbQuant.ToString();
    }
    public void cont(float up)
    {
        pont = pont + up;
    }
}
