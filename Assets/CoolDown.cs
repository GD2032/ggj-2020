using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    private float tempoCd, cd;
    public bool podeClicar;
    private GameObject cori, coriIlustracao;
    private Image coriSprite;

    void Start()
    {
        cori = GameObject.FindWithTag("pont");
        coriIlustracao = GameObject.FindWithTag("coriIlustracao");
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
            case "repararCoriLoja":

                break;

        }
        coriSprite = coriIlustracao.GetComponent<Image>();
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
        if (cori.GetComponent<counterController>().pont > 100)
            coriSprite.color = new Color(coriSprite.color.r,coriSprite.color.b,coriSprite.color.g,0.3f);
        else
            coriSprite.color = new Color(coriSprite.color.r, coriSprite.color.b, coriSprite.color.g, 1f);
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
