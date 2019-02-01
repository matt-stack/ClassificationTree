using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptHeightLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject bigA;
    public GameObject smallA;

    public void Start()
    {
        {
            //bigA = GameObject.Find("Big Arrow Left");
            //smallA = GameObject.Find("Small Arrow Left");

            bigA.SetActive(false);
            smallA.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bigA.SetActive(true);
        smallA.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bigA.SetActive(false);
        smallA.SetActive(false);
    }
}