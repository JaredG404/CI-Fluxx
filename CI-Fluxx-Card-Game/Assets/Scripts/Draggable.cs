using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeHolderParent = null;
    GameObject placeHolder = null;

    public enum areas
    {
        KEEPERS,
        HAND,
        DECK
    }

    public areas typeOfArea = areas.DECK;



    public void OnBeginDrag(PointerEventData eventData)
    {
        // placeholder object for when dragging 
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);

        // sets the size of placeholder to be of the same size of the card
        LayoutElement layoutElement = placeHolder.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        
        layoutElement.flexibleHeight = 0;
        layoutElement.flexibleWidth = 0;

        // lets you decide the spot of the card
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeHolderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if(placeHolder.transform.parent != placeHolderParent)
        {
            placeHolder.transform.SetParent(placeHolderParent);
        }

        // to be able to move card around in its area and the cards are able to be re-ordered
        int newSiblingIndex = placeHolderParent.childCount;
        for(int i = 0; i < placeHolderParent.childCount; i++)
        {
            if(this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if(placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);

        // puts card back in deck if not used
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // deletes empty space
        Destroy(placeHolder);
    }
}
