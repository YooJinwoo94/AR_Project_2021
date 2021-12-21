using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragObj : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    [SerializeField]
    TutorialManager tutorialManagerScript;

    public void OnBeginDrag(PointerEventData eventData)
    {
       // if (Application.isMobilePlatform) return;

        tutorialManagerScript.firstPos = Input.GetTouch(0).position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // if (Application.isMobilePlatform) return;

        tutorialManagerScript.nowPos = Input.GetTouch(0).position;

        Debug.Log("aasds");
    }
}
