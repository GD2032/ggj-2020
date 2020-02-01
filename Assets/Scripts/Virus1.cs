using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1 : MonoBehaviour
{
    [SerializeField] private Vector3 coracaoposition;
    [SerializeField] private float speed,multiplicadorTamanho;
    public float pontos;

    [SerializeField]
    RectTransform yourposition;
    [SerializeField]
    private LayerMask CoriLayer;
    private Collider2D[] coracao;

    void Start()
    {
        coracaoposition = transform.parent.position; 
    }

    // Update is called once per frame
    void Update()
    {
        coracao = Physics2D.OverlapCircleAll(transform.position, 1, CoriLayer);

        float speedReal = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, coracaoposition, speedReal);
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);

        if (yourposition.position == coracaoposition)
        {
            Destroy(this.gameObject);
        }
    }
}
