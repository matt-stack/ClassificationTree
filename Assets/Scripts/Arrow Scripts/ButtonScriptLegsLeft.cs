using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptLegsLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject legsA;
    public GameObject noLegsA;

    public void Start()
    {
        {
            // legsA = GameObject.Find("Legs Arrow Left");
            //noLegsA = GameObject.Find("No Legs Arrow Left");

            legsA.SetActive(false);
            noLegsA.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        legsA.SetActive(true);
        noLegsA.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        legsA.SetActive(false);
        noLegsA.SetActive(false);
    }
}
