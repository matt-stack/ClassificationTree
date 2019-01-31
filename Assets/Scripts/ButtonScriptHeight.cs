﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptHeight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject bigA;
    GameObject smallA;

    public void Start()
    {
        {
            bigA = GameObject.Find("Big Arrow");
            smallA = GameObject.Find("Small Arrow");

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