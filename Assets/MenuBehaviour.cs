using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    UI UI;
    int coolDown = 2;
    bool ativado = true;
    string[] cenas = new string[] { "SampleScene", "Creditos","saito" };
    public GameObject som;

    private void Awake() 
    {
        DontDestroyOnLoad(som);
    }
    private void Fade()
    {
        if (ativado)
        {
            ativado = !ativado;
            UI = GetComponent<UI>();
            UI.Fades(false, coolDown, Random.Range(0, 2));
        }
    }
    public void BotaoInciar() 
    {
        Fade();
        StartCoroutine(CoolDown(coolDown,cenas[0]));
        Destroy(som);
    }
    public void BotaoDiverso()
    {
        Fade();
        StartCoroutine(CoolDown(coolDown,cenas[2]));
    }

    
    IEnumerator CoolDown(int cd,string cena) 
    {
        yield return new WaitForSeconds(cd);
        SceneManager.LoadScene(cena);

    }
}
