using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptColorLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject yellowA;
    public GameObject blueA;

    public void Start()
    {
        {
            //blueA = GameObject.Find("Blue Arrow Left");
            //yellowA = GameObject.Find("Yellow Arrow Left");

            blueA.SetActive(false);
            yellowA.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        blueA.SetActive(true);
        yellowA.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        blueA.SetActive(false);
        yellowA.SetActive(false);
    }
}
