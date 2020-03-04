using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZoneKeepers : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null)
        {
            return;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }
}
