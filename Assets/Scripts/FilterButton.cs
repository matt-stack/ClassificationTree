using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButton : MonoBehaviour
{
    // To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.
    //Make sure to attach these Buttons in the Inspector
    public Button button1, button2, button3;
    float m_FieldOfView;


    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        button1.onClick.AddListener(TaskOnClick);
        button2.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
        button3.onClick.AddListener(() => ButtonClicked(42));
        button3.onClick.AddListener(TaskOnClick);

        m_FieldOfView = 132f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_FieldOfView = 1500f;
        }
        Camera.main.fieldOfView = m_FieldOfView;
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        m_FieldOfView = 1500f;

    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
        m_FieldOfView = 1500f;
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
        m_FieldOfView = 1500f;
    }
    void OnGUI()
    {
        //Set up the maximum and minimum values the Slider can return (you can change these)
        float max, min;
        max = 132.0f;
        min = 110.0f;
        //This Slider changes the field of view of the Camera between the minimum and maximum values
        m_FieldOfView = 200f;
    }
}