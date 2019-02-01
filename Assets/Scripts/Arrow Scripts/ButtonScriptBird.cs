using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptBird : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject birdA;
    public GameObject birdARight;

    public GameController gameControllerScript;


    public void Start()
    {
        {
            //birdA = GameObject.Find("isBird Arrow");

            birdA.SetActive(false);
            birdARight.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameControllerScript.oneTime == false)
        {
            birdA.SetActive(true);
        }
        else
        {
            birdARight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        birdA.SetActive(false);
        birdARight.SetActive(false);
    }
}
