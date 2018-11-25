using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData) {
        Debug.Log("down");
    }

    public void OnPointerUp(PointerEventData pointerEventData) {
        Debug.Log("up");
    }
}
