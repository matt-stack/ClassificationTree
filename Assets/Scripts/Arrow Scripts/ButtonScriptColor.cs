using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject yellowA;
    public GameObject blueA;
    public GameObject yellowARight;
    public GameObject blueARight;

    public GameController gameControllerScript;

    public void Start()
    {
        {
            //blueA = GameObject.Find("Blue Arrow");
            //yellowA = GameObject.Find("Yellow Arrow");

            blueA.SetActive(false);
            yellowA.SetActive(false);
            blueARight.SetActive(false);
            yellowARight.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameControllerScript.oneTime == false)
        {
            blueA.SetActive(true);
            yellowA.SetActive(true);
        }
        else
        {
            blueARight.SetActive(true);
            yellowARight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        blueA.SetActive(false);
        yellowA.SetActive(false);
        blueARight.SetActive(false);
        yellowARight.SetActive(false);
    }
}
