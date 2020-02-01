using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    UI UI;
    int coolDown = 2;
    bool ativado = true;
    string[] cenas = new string[] { "SampleScene", "Creditos" };

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
    }
    public void BotaoDiverso()
    {
        Fade();
        StartCoroutine(CoolDown(coolDown,cenas[1]));
    }

    
    IEnumerator CoolDown(int cd,string cena) 
    {
        yield return new WaitForSeconds(cd);
        SceneManager.LoadScene(cena);

    }
}
