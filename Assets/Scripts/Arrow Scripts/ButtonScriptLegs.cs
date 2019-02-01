using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptLegs : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject legsA;
    public GameObject noLegsA;
    public GameObject legsARight;
    public GameObject noLegsARight;

    public GameController gameControllerScript;

    public void Start()
    {
        {
            //legsA = GameObject.Find("Legs Arrow");
           //noLegsA = GameObject.Find("No Legs Arrow");

            legsA.SetActive(false);
            noLegsA.SetActive(false);
            legsARight.SetActive(false);
            noLegsARight.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameControllerScript.oneTime == false)
        {
            legsA.SetActive(true);
            noLegsA.SetActive(true);
        }
        else
        {
            legsARight.SetActive(true);
            noLegsARight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        legsA.SetActive(false);
        noLegsA.SetActive(false);
        legsARight.SetActive(false);
        noLegsARight.SetActive(false);
    }
}
