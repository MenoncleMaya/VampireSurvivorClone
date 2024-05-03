using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SimpleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 
{
    public Action OnClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

}
