using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;
    [SerializeField] private float multiplicadorTamanho;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public float pontos;
    Collider2D[] objetos;

    private void Awake() {

        canvas = GameObject.FindGameObjectWithTag("canva").GetComponent<Canvas>();

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
    }
    private void Update()
    {
        Detectar();
        transform.localScale = new Vector3(pontos * multiplicadorTamanho, pontos * multiplicadorTamanho);
    }
    private void Detectar()
    {
        objetos = Physics2D.OverlapCircleAll(transform.position, 1);
        if (objetos.Length > 1)
        {
            for (int i = 0; i < objetos.Length; i++)
            {
                if (objetos[i].tag == "Coronga")
                {
                    print("alo");
                    ClasseHelper.retVida(ref pontos, ref objetos[i].gameObject.GetComponent<Virus1>().pontos);
                }
                else if(objetos[i].tag == "GlobuloB")
                {
                    print("hello");
                   ClasseHelper.juntVida(ref pontos, ref objetos[i].gameObject.GetComponent<DragDrop>().pontos);
                }
            }
        }
    }
}
