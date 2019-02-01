using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptBirdIntro : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject birdA;

    public void Start()
    {
        {
            //birdA = GameObject.Find("isBird Arrow");

            birdA.SetActive(false);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

            birdA.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        birdA.SetActive(false);

    }
}