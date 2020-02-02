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
        coracaoposition = transform.parent.position;
    }


    void Update()
    {
        float speedReal = speed * Time.deltaTime;
        //Posiçao e tamanho
        if(movimento)
            transform.position = Vector3.MoveTowards(transform.position, coracaoposition, speedReal);
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);
    }
}
