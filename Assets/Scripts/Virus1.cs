﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Virus1 : MonoBehaviour
{ 
    [SerializeField] private Vector2 coracaoposition;
    [SerializeField] private float speed, multiplicadorTamanho;
    Collider2D[] objetos;
    public float pontos;

    void Start()
    {
        coracaoposition = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speedReal = speed * Time.deltaTime;
        //Posiçao e tamanho
        transform.position = Vector3.MoveTowards(transform.position, coracaoposition, speedReal);
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);
    }
}
