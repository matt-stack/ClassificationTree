using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScriptHatLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hatA;
    public GameObject noHatA;

    public void Start()
    {
        {
            //hatA = GameObject.Find("Hat Arrow Left");
            //noHatA = GameObject.Find("No Hat Arrow Left");

            hatA.SetActive(false);
            noHatA.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hatA.SetActive(true);
        noHatA.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hatA.SetActive(false);
        noHatA.SetActive(false);
    }
}
