using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Virus1 : MonoBehaviour
{ 
    [SerializeField] private Vector2 coracaoposition;
    [SerializeField] private float speed, multiplicadorTamanho;
    Collider2D[] objetos;
    public float pontos;
    public bool movimento;
    void Start()
    {
        coracaoposition = new Vector2(0,6);
    }


    void Update()
    {
        float speedReal = speed * Time.deltaTime;
        //Posiçao e tamanho
        GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(GetComponent<RectTransform>().anchoredPosition, coracaoposition, speedReal);
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);
    }
}
