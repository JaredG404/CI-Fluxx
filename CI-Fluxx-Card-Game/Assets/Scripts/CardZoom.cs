using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{

    public GameObject Canvas;
    private GameObject zoomCard;
    public void Awake()
    {
        Canvas = GameObject.Find("Canvas");
    }

    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x - 450, Input.mousePosition.y - 200), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.transform.localScale = new Vector2(2,2);
        zoomCard.transform.Rotate(0, 180, 0);
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
        Debug.Log("zoom destroyed");
    }
}
