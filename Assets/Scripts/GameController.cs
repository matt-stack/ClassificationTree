using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int birdPoolSize = 5;
    public int bigDataSize = 30;
    public GameObject birdPrefab;
    public Button button1, button2, button3, button4, button5, button6, button7, button8;
    public bool bigDataClicked = false;
    public GameObject winText, loseText;

    private List<GameObject> birds;
    private Vector2 objectPoolPosition = new Vector2(0, 5);

    float m_FieldOfView;
    bool oneTime;
    bool clicked;
    GameObject b1;
    GameObject b2;
    GameObject b3;
    GameObject b5;
    GameObject b6;
    GameObject b7;
    GameObject b8;

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
        button3.onClick.AddListener(OnClickBird);
        button3.onClick.AddListener(OnClickZoom);
        button4.onClick.AddListener(OnClickRestart);
        button4.onClick.AddListener(OnClickZoom);
        button5.onClick.AddListener(OnClickBigData);
        button6.onClick.AddListener(OnClickColorLeft);
        button6.onClick.AddListener(OnClickZoom);
        button7.onClick.AddListener(OnClickHeightLeft);
        button7.onClick.AddListener(OnClickZoom);
        button8.onClick.AddListener(OnClickBirdLeft);
        button8.onClick.AddListener(OnClickZoom);
        button1.onClick.AddListener(OnClickEndCheck);
        button2.onClick.AddListener(OnClickEndCheck);
        button3.onClick.AddListener(OnClickEndCheck);
        button4.onClick.AddListener(OnClickEndCheck);
        button6.onClick.AddListener(OnClickEndCheck);
        button7.onClick.AddListener(OnClickEndCheck);
        button8.onClick.AddListener(OnClickEndCheck);

        Camera.main.transform.position = new Vector3(0f, 9.32f, -10f);
        b1 = GameObject.Find("Color_right");
        b2 = GameObject.Find("Height_right");
        b3 = GameObject.Find("Bird_right");
        b5 = GameObject.Find("BigData");
        b6 = GameObject.Find("Color_left");
        b7 = GameObject.Find("Height_left");
        b8 = GameObject.Find("Bird_left");
        b6.SetActive(false);
        b7.SetActive(false);
        b8.SetActive(false);

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
            b5.SetActive(false);
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
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.height > 1)
                    {
                        bird.gameObject.layer = 9;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                    b7.SetActive(false);
                    b8.SetActive(true);
                    b6.SetActive(true);
                }
                else
                {
                    if (bird.height > 1)
                    {
                        bird.gameObject.layer = 14;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 13;
                }
            }
        }
        clicked = true;
        b2.SetActive(false);
        b5.SetActive(false);
        if (!b1.activeInHierarchy)
            b3.SetActive(false);
        if (!b3.activeInHierarchy)
            b1.SetActive(false);
    }

    void OnClickHeightLeft()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (!bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.height > 1)
                    {
                        bird.gameObject.layer = 9;
                        //bird.right = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                }
                else
                {
                    if (bird.height > 1)
                    {
                        bird.gameObject.layer = 12;
                        // bird.right = false;
                    }
                    else
                        bird.gameObject.layer = 11;
                }
            }
        }
        clicked = true;
        b5.SetActive(false);
        b7.SetActive(false);
        if (!b8.activeInHierarchy)
            b6.SetActive(false);
        if (!b6.activeInHierarchy)
            b8.SetActive(false);
    }

    void OnClickColor()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.color.Equals("blue"))
                    {
                        bird.gameObject.layer = 9;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                    b6.SetActive(false);
                    b7.SetActive(true);
                    b8.SetActive(true);
                }
                else
                {
                    if (bird.color.Equals("blue"))
                    {
                        bird.gameObject.layer = 14;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 13;
                }
            }
        }
        clicked = true;
        b1.SetActive(false);
        b5.SetActive(false);
        if (!b2.activeInHierarchy)
            b3.SetActive(false);
        if (!b3.activeInHierarchy)
            b2.SetActive(false);
    }
    void OnClickColorLeft()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (!bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.color.Equals("blue"))
                    {
                        bird.gameObject.layer = 9;
                        // bird.right = false;

                    }
                    else
                        bird.gameObject.layer = 8;
                }
                else
                {
                    if (bird.color.Equals("blue"))
                    {
                        bird.gameObject.layer = 12;
                        //bird.right = false;
                    }
                    else
                        bird.gameObject.layer = 11;
                }
            }
        }
        clicked = true;
        b5.SetActive(false);
        b6.SetActive(false);
        if (!b7.activeInHierarchy)
            b8.SetActive(false);
        if (!b8.activeInHierarchy)
            b7.SetActive(false);
    }


    void OnClickBird()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (bird.isRight)
            {
                if (clicked == false)
                {
                    bird.gameObject.layer = 8;

                    b6.SetActive(true);
                    b7.SetActive(true);
                    b8.SetActive(false);
                }
                else
                {
                    bird.gameObject.layer = 13;
                }
            }
        }
        clicked = true;
        b3.SetActive(false);
        b5.SetActive(false);
        if (!b1.activeInHierarchy)
            b2.SetActive(false);
        if (!b2.activeInHierarchy)
            b1.SetActive(false);
    }

    void OnClickBirdLeft()
    {
        //Output this to console when Button1 or Button3 is clicked
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (!bird.isRight)
            {
                if (clicked == false)
                {
                    bird.gameObject.layer = 11;
                }
                else
                {
                    bird.gameObject.layer = 8;
                }
            }
        }
        clicked = true;
        b5.SetActive(false);
        b8.SetActive(false);
        if (!b7.activeInHierarchy)
            b6.SetActive(false);
        if (!b6.activeInHierarchy)
            b7.SetActive(false);
    }

    void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnClickEndCheck()
    {
        int count = 0;
        count += b1.activeInHierarchy ? 1 : 0;
        count += b2.activeInHierarchy ? 1 : 0;
        count += b3.activeInHierarchy ? 1 : 0;
        count += b6.activeInHierarchy ? 1 : 0;
        count += b7.activeInHierarchy ? 1 : 0;
        count += b8.activeInHierarchy ? 1 : 0;
        if(count < 1)
        {
            endGame();
        }
    }

    private void endGame()
    {
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
        b8.SetActive(false);

        bool kiwi11 = false;
        bool moa11 = false;

        bool kiwi12 = false;
        bool moa12 = false;

        bool kiwi13 = false;
        bool moa13 = false;

        bool kiwi14 = false;
        bool moa14 = false;

        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (b.layer == 11)
            {
                if (bird.species.Equals("common"))
                {
                    kiwi11 = true;
                }
                else
                {
                    moa11 = true;
                }
            }
            if (b.layer == 12)
            {
                if (bird.species.Equals("common"))
                {
                    kiwi12 = true;
                }
                else
                {
                    moa12 = true;
                }
            }
            if (b.layer == 13)
            {
                if (bird.species.Equals("common"))
                {
                    kiwi13 = true;
                }
                else
                {
                    moa13 = true;
                }
            }
            if (b.layer == 14)
            {
                if (bird.species.Equals("common"))
                {
                    kiwi14 = true;
                }
                else
                {
                    moa14 = true;
                }
            }
        }
        if ((kiwi11 && moa11) || (kiwi12 && moa12) || (kiwi13 && moa13) || (kiwi14 && moa14))
        {
            loseText.SetActive(true);
            Debug.Log("" + (kiwi11 && moa11) + ", " + (kiwi12 && moa12) + ", " + (kiwi13 && moa13) + ", " + (kiwi14 && moa14));
        }
        else
        {
            winText.SetActive(true);
        }
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
