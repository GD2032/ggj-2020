using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseHelper : MonoBehaviour
{

    UI UI;
    void Start() 
    {
        UI = GetComponent<UI>();
        UI.Fades(true, 2, Random.Range(0, 3));
    }
    static class Resiliencia 
    {
        /// <summary>
        /// retorna as vidas por referencia
        /// subtraindo a maior pela menor
        /// </summary>
        /// <param name="a">vida1</param>
        /// <param name="b">vida2</param>
        static void retVida(ref float a, ref float b)
        {
            if (a >= b)
            {
                a -= b;
                b = 0;
            }
            else
            {
                b -= a;
                a = 0;
            }
        }
        /// <summary>
        /// retorna as vidas por referencia
        /// somando a primeira com a segunda
        /// 
        /// </summary>
        /// <param name="a">vida1</param>
        /// <param name="b">vida2</param>
        static void juntVida(ref float a, ref float b) 
        {
            a += b;
            b = 0;
        } 
    }
}
