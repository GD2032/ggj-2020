using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1 : MonoBehaviour
{
    [SerializeField] private Vector2 coracaoposition;
    [SerializeField] private float speed, pontos, multiplicadorTamanho;

    void Start()
    {
        coracaoposition = transform.parent.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float speedReal = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, coracaoposition, speedReal);
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);
    }
}
