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
    public bool right = true;

    private string species;
    private string[] colors = { "green", "brown" };
    private string[] speciess = { "kiwi", "Moa" };

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
        if (height > 1f)
        {
            species = speciess[1];
        }
        else
        {
            species = speciess[0];
        }
        // sprite editing
        // color
        if (color == "green")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        }
        else if (color == "brown")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteY;
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
