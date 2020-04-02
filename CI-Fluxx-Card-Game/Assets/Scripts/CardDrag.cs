using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool isDragging = false;
    public Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(isDragging)
        // {
        //     transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // }
    }

    // public void StartDrag()
    // {
    //     startPos = transform.position;
    //     isDragging = true;
    // }
    // public void EndDrag()
    // {
    //     isDragging = false;
    // }

    void OnMouseDown()
 {
     screenPoint = Camera.main.WorldToScreenPoint(transform.position);
     offset =  this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
 }

 void OnMouseDrag()
 {
     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
     transform.position = curPosition;
 }
}
