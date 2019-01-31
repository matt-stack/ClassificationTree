using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject yellowA;
    GameObject blueA;

    public void Start()
    {
        {
            blueA = GameObject.Find("Blue Arrow");
            yellowA = GameObject.Find("Yellow Arrow");

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
