using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class counterController : MonoBehaviour
{
    public float pont = 25, gbQuant = 0;
    [SerializeField]
    GameObject coracao;
    [SerializeField]
    private Text texto,gbtext;
    [SerializeField]
    private Animator animado;
    private bool final;
    UI UI;
    void Start() 
    {
        final = true;
    }
    void Update() 
    {
        textin();
        animação();
        print(pont);
        if(pont <=0 && final)
        {
            UI = GetComponent<UI>();
            UI.Fades(false, 2, 0);
            StartCoroutine(cd(5));
            final = false;
        }
        if(pont >=100 && final)
        {
            UI = GetComponent<UI>();
            UI.Fades(false,2,0);
            StartCoroutine(cd(5));
            final = false;
        }

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
    IEnumerator cd(float cd)
    {
        yield return new WaitForSeconds(cd);
        StartCoroutine(alo(2));
        
        
    }
    IEnumerator alo (float cd)
    {
        yield return new WaitForSeconds(cd);
        SceneManager.LoadScene("CenaAragão");
    }
    IEnumerator ale()
    {
        yield return new WaitForSeconds(2);
    }

}
