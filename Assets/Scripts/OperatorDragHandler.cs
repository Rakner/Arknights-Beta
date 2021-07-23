using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OperatorDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
  public Transform prefab;  


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Instantiate(prefab, Input.mousePosition, Quaternion.identity);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      transform.localPosition =  Vector3.zero;
    }
}
