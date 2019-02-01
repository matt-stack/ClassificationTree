using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


//TODO: Edit activeInHierarchy sections in filter functions
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int birdPoolSize = 5;
    public int bigDataSize = 30;
    public GameObject birdPrefab;

    //button declarations
    public Button Color_r_b, Height_r_b, Bird_r_b, Restart_b, BigData_b, Color_l_b, Height_l_b, Bird_l_b, Hat_r_b, Legs_r_b, Hat_l_b, Legs_l_b;
    public bool bigDataClicked = false;
    public GameObject winText, loseText, xSprite, check;

    private List<GameObject> birds;
    private Vector2 objectPoolPosition = new Vector2(0, 5);

    float m_FieldOfView;
    public bool oneTime;
    bool clicked;
    GameObject crb;         //color right
    GameObject hrb;         //height right
    GameObject brb;         //bird right
    GameObject bigdata;     //big data button
    GameObject clb;         //color left
    GameObject hlb;         //height left
    GameObject blb;         //bird left
    GameObject trb;         //hat right
    GameObject lrb;         //legs right
    GameObject tlb;         //hat left
    GameObject llb;         //legs left

    public GameObject cta;         //color top arrow
    public GameObject cla;         //color left arrow
    public GameObject cra;         //color right arrow
    public GameObject hta;         //height top arrow
    public GameObject hla;         //height left arrow
    public GameObject hra;         //height right arrow
    public GameObject hhta;         //hat top arrow
    public GameObject hhla;         //hat left arrow
    public GameObject hhra;         //hat right arrow
    public GameObject lta;         //leg top arrow
    public GameObject lla;         //leg left arrow
    public GameObject lra;         //leg left arrow
    public GameObject bta;         //bird top arrow
    public GameObject bla;         //bird left arrow
    public GameObject bra;         //bird right arrow

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
        Color_r_b.onClick.AddListener(OnClickColor);
        Color_r_b.onClick.AddListener(OnClickZoom);
        Height_r_b.onClick.AddListener(OnClickHeight);
        Height_r_b.onClick.AddListener(OnClickZoom);
        Bird_r_b.onClick.AddListener(OnClickBird);
        Bird_r_b.onClick.AddListener(OnClickZoom);
        Restart_b.onClick.AddListener(OnClickRestart);
        Restart_b.onClick.AddListener(OnClickZoom);
        BigData_b.onClick.AddListener(OnClickBigData);
        Color_l_b.onClick.AddListener(OnClickColorLeft);
        Color_l_b.onClick.AddListener(OnClickZoom);
        Height_l_b.onClick.AddListener(OnClickHeightLeft);
        Height_l_b.onClick.AddListener(OnClickZoom);
        Bird_l_b.onClick.AddListener(OnClickBirdLeft);
        Bird_l_b.onClick.AddListener(OnClickZoom);
        
        Hat_r_b.onClick.AddListener(OnClickHat);
        Hat_r_b.onClick.AddListener(OnClickZoom);
        Legs_r_b.onClick.AddListener(OnClickLegs);
        Legs_r_b.onClick.AddListener(OnClickZoom);
        Hat_l_b.onClick.AddListener(OnClickHatLeft);
        Hat_l_b.onClick.AddListener(OnClickZoom);
        Legs_l_b.onClick.AddListener(OnClickLegsLeft);
        Legs_l_b.onClick.AddListener(OnClickZoom);


        Color_r_b.onClick.AddListener(OnClickEndCheck);
        Height_r_b.onClick.AddListener(OnClickEndCheck);
        Bird_r_b.onClick.AddListener(OnClickEndCheck);
        Restart_b.onClick.AddListener(OnClickEndCheck);
        Color_l_b.onClick.AddListener(OnClickEndCheck);
        Height_l_b.onClick.AddListener(OnClickEndCheck);
        Bird_l_b.onClick.AddListener(OnClickEndCheck);


        Camera.main.transform.position = new Vector3(0f, 9.32f, -10f);
       
        crb = GameObject.Find("Color_right");
        hrb = GameObject.Find("Height_right");
        brb = GameObject.Find("Bird_right");
        trb = GameObject.Find("Hat_right");
        lrb = GameObject.Find("Legs_right");
        bigdata = GameObject.Find("BigData");
        clb = GameObject.Find("Color_left");
        hlb = GameObject.Find("Height_left");
        blb = GameObject.Find("Bird_left");
        tlb = GameObject.Find("Hat_left");
        llb = GameObject.Find("Legs_left");
        clb.SetActive(false);
        hlb.SetActive(false);
        blb.SetActive(false);
        tlb.SetActive(false);
        llb.SetActive(false);

        cta.SetActive(false);         //color top arrow
        cla.SetActive(false);         //color left arrow
        cra.SetActive(false);         //color right arrow
        hta.SetActive(false);         //height top arrow
        hla.SetActive(false);         //height left arrow
        hra.SetActive(false);         //height right arrow
        hhta.SetActive(false);         //hat top arrow
        hhla.SetActive(false);         //hat left arrow
        hhra.SetActive(false);         //hat right arrow
        lta.SetActive(false);           //leg top arrow
        lla.SetActive(false);         //leg left arrow
        lra.SetActive(false);         //leg right arrow
        bta.SetActive(false);         //bird top arrow
        bla.SetActive(false);         //bird left arrow
        bra.SetActive(false);         //bird right arrow

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
            bigdata.SetActive(false);
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

                    hlb.SetActive(false);
                    blb.SetActive(true);
                    clb.SetActive(true);
                    tlb.SetActive(true);
                    llb.SetActive(true);
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
        hrb.SetActive(false);
        bigdata.SetActive(false);
        if (!crb.activeInHierarchy)
            brb.SetActive(false);
        if (!brb.activeInHierarchy)
            crb.SetActive(false);
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
        bigdata.SetActive(false);
        hlb.SetActive(false);
        if (!blb.activeInHierarchy)
            clb.SetActive(false);
        if (!clb.activeInHierarchy)
            blb.SetActive(false);
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

                    clb.SetActive(false);
                    hlb.SetActive(true);
                    blb.SetActive(true);
                    tlb.SetActive(true);
                    llb.SetActive(true);
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
        crb.SetActive(false);
        bigdata.SetActive(false);
        if (!hrb.activeInHierarchy)
            brb.SetActive(false);
        if (!brb.activeInHierarchy)
            hrb.SetActive(false);
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
        bigdata.SetActive(false);
        clb.SetActive(false);
        if (!hlb.activeInHierarchy)
            blb.SetActive(false);
        if (!blb.activeInHierarchy)
            hlb.SetActive(false);
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

                    clb.SetActive(true);
                    hlb.SetActive(true);
                    blb.SetActive(false);
                    tlb.SetActive(true);
                    llb.SetActive(true);
                }
                else
                {
                    bird.gameObject.layer = 13;
                }
            }
        }
        clicked = true;
        brb.SetActive(false);
        bigdata.SetActive(false);
        if (!crb.activeInHierarchy)
            hrb.SetActive(false);
        if (!hrb.activeInHierarchy)
            crb.SetActive(false);
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
        bigdata.SetActive(false);
        blb.SetActive(false);
        if (!hlb.activeInHierarchy)
            clb.SetActive(false);
        if (!clb.activeInHierarchy)
            hlb.SetActive(false);
    }


    void OnClickHat()
    {
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.hasHat)
                    {
                        bird.gameObject.layer = 9;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                    hlb.SetActive(true);
                    blb.SetActive(true);
                    clb.SetActive(true);
                    tlb.SetActive(false);
                    llb.SetActive(true);
                }
                else
                {
                    if (bird.hasHat)
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
        trb.SetActive(false);
        bigdata.SetActive(false);

    }

    void OnClickHatLeft()
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
                    if (!bird.hasHat)
                    {
                        bird.gameObject.layer = 9;
                        //bird.right = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                }
                else
                {
                    if (!bird.hasHat)
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
        bigdata.SetActive(false);
        tlb.SetActive(false);
        
    }


    void OnClickLegs()
    {
        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (bird.isRight)
            {
                if (clicked == false)
                {
                    if (bird.hasLegs)
                    {
                        bird.gameObject.layer = 9;
                        bird.isRight = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                    hlb.SetActive(true);
                    blb.SetActive(true);
                    clb.SetActive(true);
                    tlb.SetActive(true);
                    llb.SetActive(false);
                }
                else
                {
                    if (bird.hasLegs)
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
        lrb.SetActive(false);
        bigdata.SetActive(false);

    }

    void OnClickLegsLeft()
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
                    if (!bird.hasLegs)
                    {
                        bird.gameObject.layer = 9;
                        //bird.right = false;
                    }
                    else
                        bird.gameObject.layer = 8;

                }
                else
                {
                    if (!bird.hasLegs)
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
        bigdata.SetActive(false);
        llb.SetActive(false);

    }



    void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //TODO: Edit OnClickEndCheck()
    void OnClickEndCheck()
    {
        int count = 0;
        count += crb.activeInHierarchy ? 1 : 0;
        count += hrb.activeInHierarchy ? 1 : 0;
        count += brb.activeInHierarchy ? 1 : 0;
        count += trb.activeInHierarchy ? 1 : 0;
        count += lrb.activeInHierarchy ? 1 : 0;
        count += clb.activeInHierarchy ? 1 : 0;
        count += hlb.activeInHierarchy ? 1 : 0;
        count += blb.activeInHierarchy ? 1 : 0;
        count += tlb.activeInHierarchy ? 1 : 0;
        count += llb.activeInHierarchy ? 1 : 0;
        if(count < 1)
        {
            endGame();
        }
    }

    private void endGame()
    {
        crb.SetActive(false);
        hrb.SetActive(false);
        brb.SetActive(false);
        trb.SetActive(false);
        lrb.SetActive(false);
        clb.SetActive(false);
        hlb.SetActive(false);
        blb.SetActive(false);
        tlb.SetActive(false);
        llb.SetActive(false);

        bool common11 = false;
        bool endangered11 = false;

        bool common12 = false;
        bool endangered12 = false;

        bool common13 = false;
        bool endangered13 = false;

        bool common14 = false;
        bool endangered14 = false;

        foreach (GameObject b in birds)
        {
            Bird bird;
            bird = b.GetComponent<Bird>();
            if (b.layer == 11)
            {
                if (bird.species.Equals("common"))
                {
                    common11 = true;
                }
                else
                {
                    endangered11 = true;
                }
            }
            if (b.layer == 12)
            {
                if (bird.species.Equals("common"))
                {
                    common12 = true;
                }
                else
                {
                    endangered12 = true;
                }
            }
            if (b.layer == 13)
            {
                if (bird.species.Equals("common"))
                {
                    common13 = true;
                }
                else
                {
                    endangered13 = true;
                }
            }
            if (b.layer == 14)
            {
                if (bird.species.Equals("common"))
                {
                    common14 = true;
                }
                else
                {
                    endangered14 = true;
                }
            }
        }
        if ((common11 && endangered11) || (common12 && endangered12) || (common13 && endangered13) || (common14 && endangered14))
        {
            loseText.SetActive(true);
            xSprite.SetActive(true);
            Debug.Log("" + (common11 && endangered11) + ", " + (common12 && endangered12) + ", " + (common13 && endangered13) + ", " + (common14 && endangered14));
        }
        else
        {
            check.SetActive(true);
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
