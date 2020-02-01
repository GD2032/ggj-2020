using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coriBehaviour : MonoBehaviour
{
    [SerializeField]
    private LayerMask vLayer;
    private Collider2D[] virus;
    [SerializeField]
    private LayerMask hLayer;
    private Collider2D[] Hemacia;

    counterController pontos;

    void Start()
    {
        pontos = GameObject.FindGameObjectWithTag("pont").GetComponent<counterController>();
    }
    void Update()
    {
        virus = Physics2D.OverlapCircleAll(transform.position, 1);
        if (virus.Length > 1)
        {
            for (int i = 0; i < virus.Length; i++)
            {
                if (virus[i].tag == "virus")
                {
                    pontos.cont(-virus[i].gameObject.GetComponent<Virus1>().pontos);
                    Destroy(virus[i].gameObject);
                }
                else if (virus[i].tag == "hema")
                {
                    pontos.cont(5);
                    Destroy(virus[i].gameObject);
                }
            }
        }
    }
}
