using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptHeight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject bigA;
    public GameObject smallA;
    public GameObject bigARight;
    public GameObject smallARight;

    public GameController gameControllerScript;

    public void Start()
    {

            //bigA = GameObject.Find("Big Arrow");
            //smallA = GameObject.Find("Small Arrow");

        bigA.SetActive(false);
        smallA.SetActive(false);
        bigARight.SetActive(false);
        smallARight.SetActive(false);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameControllerScript.oneTime == false)
        {
            bigA.SetActive(true);
            smallA.SetActive(true);
        }
        else
        {
            bigARight.SetActive(true);
            smallARight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bigA.SetActive(false);
        smallA.SetActive(false);
        bigARight.SetActive(false);
        smallARight.SetActive(false);
    }
}