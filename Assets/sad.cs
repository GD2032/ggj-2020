using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sad : MonoBehaviour
{
    UI UI;
    void Start()
    {
        UI = GetComponent<UI>();
        UI.Fades(true,2, Random.Range(0,3));
    }
  
}
