using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    public string color;
    public float height;
    public bool flight;
    public bool isRight = true;

    public string species;
    private string[] colors = { "yellow", "blue" };
    private string[] speciess = { "kiwi", "moa" };

    private Sprite spriteB;
    private Sprite spriteY;
    Vector2 scaleB = new Vector2(1, 1);
    Vector2 scaleS = new Vector2(0.5f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(0, 10);
        spriteB = Resources.Load<Sprite>("BirdHeroblue");
        spriteY = Resources.Load<Sprite>("BirdHero");
        color = (Random.value > 0.5f) ? colors[0] : colors[1];
        height = Random.value * 2f;
        flight = Random.value > 0.5f;
        if ((height > 1f && color.Equals("blue")) || (height <= 1f && color.Equals("yellow")))
        {
            species = speciess[1];
        }
        else
        {
            species = speciess[0];
        }
        // sprite editing
        // color
        if (color == "yellow")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteY;
        }
        else if (color == "blue")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        }
        //size
        //gameObject.transform.Translate(1.0f, 1.0f, 1.0f);
        if (height >= 1)
        {
            gameObject.transform.localScale = scaleB;
        }
        else if (height < 1)
        {
            gameObject.transform.localScale = scaleS;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
