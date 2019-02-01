using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptHat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hatA;
    public GameObject noHatA;
    public GameObject hatARight;
    public GameObject noHatARight;

    public GameController gameControllerScript;

    public void Start()
    {
        {
            //hatA = GameObject.Find("Hat Arrow");
            //noHatA = GameObject.Find("No Hat Arrow");

            hatA.SetActive(false);
            noHatA.SetActive(false);
            hatARight.SetActive(false);
            noHatARight.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameControllerScript.oneTime == false)
        {
            hatA.SetActive(true);
            noHatA.SetActive(true);
        }
        else
        {
            hatARight.SetActive(true);
            noHatARight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hatA.SetActive(false);
        noHatA.SetActive(false);
        hatARight.SetActive(false);
        noHatARight.SetActive(false);
    }
}
