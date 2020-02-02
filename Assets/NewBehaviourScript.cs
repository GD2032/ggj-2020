using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void ganhar()
    {
        if (GetComponent<counterController>().pont > 100)
            Invoke("mudarCena", 5);
    }
    void mudarCena()
    {
        SceneManager.LoadScene("CenaAragão");
    }
}
