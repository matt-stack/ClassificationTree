using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int birdPoolSize = 5;
    public int bigDataSize = 30;
    public GameObject birdPrefab;
    public Button button1, button2, button3, button4, button5;
    public bool bigDataClicked = false;

    private List<GameObject> birds;
    private Vector2 objectPoolPosition = new Vector2(0, 5);

    float m_FieldOfView;
    bool oneTime;
    bool clicked;
    GameObject b1;
    GameObject b2;
    GameObject b3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        birds = new List<GameObject>();
        for (int i = 0; i < birdPoolSize; i++)
        {
            birds.Add((GameObject)Instantiate(birdPrefab, objectPoolPosition, Quaternion.identity));
        }
    }

    void Start()
    {
        m_FieldOfView = 63f;
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        button1.onClick.AddListener(OnClickColor);
        button1.onClick.AddListener(OnClickZoom);
        button2.onClick.AddListener(OnClickHeight);
        button2.onClick.AddListener(OnClickZoom);
        button3.onClick.AddListener(OnClickFlight);
        button3.onClick.AddListener(OnClickZoom);
        button4.onClick.AddListener(OnClickRestart);
        button4.onClick.AddListener(OnClickZoom);
        button5.onClick.AddListener(OnClickBigData);

        Camera.main.transform.position = new Vector3(0f, 9.32f, -10f);
        b1 = GameObject.Find("Button");
        b2 = GameObject.Find("Button (1)");
        b3 = GameObject.Find("Button (2)");


    }

    void OnClickBigData()
    {
        if (!bigDataClicked && !clicked) // cannot click Big Data Button if it has already been clicked, or a feature has already been picked
        {
            for (int i = 0; i < bigDataSize; i++)
            {
                birds.Add((GameObject)Instantiate(birdPrefab, objectPoolPosition, Quaternion.identity));
            }
            bigDataClicked = true;
        }

    }

    void OnClickZoom()
    {
        if (oneTime == false)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y - 5f, Camera.main.transform.position.z);
            m_FieldOfView = 100f;
            oneTime = true;
        }

    }

    void OnClickHeight()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (clicked == false)
            {
                if (bird.height > 1)
                    bird.gameObject.layer = 8;
                else
                    bird.gameObject.layer = 9;
            }
            else
            {
                if (bird.height > 1)
                    bird.gameObject.layer = 11;
                else
                    bird.gameObject.layer = 12;
            }
        }
        clicked = true;
        b2.SetActive(false);
    }

    void OnClickColor()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (clicked == false)
            {
                if (bird.color.Equals("brown"))
                    bird.gameObject.layer = 8;
                else
                    bird.gameObject.layer = 9;
            }
            else
            {
                if (bird.color.Equals("brown"))
                    bird.gameObject.layer = 11;
                else
                    bird.gameObject.layer = 12;
            }
        }
        clicked = true;
        b1.SetActive(false);
    }
    void OnClickFlight()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (clicked == false)
            {
                bird.gameObject.layer = 8;
            }
            else
            {
                bird.gameObject.layer = 11;
            }
        }
        clicked = true;
        b3.SetActive(false);

    }

    void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView = m_FieldOfView;
    }
}
