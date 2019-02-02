using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    // Bird features
    public string color;
    public float height;
    public bool hasHat;
    public bool hasLegs;
    public bool isBird;

    public bool isRight = true;

    public string species;
    private string[] colors = { "yellow", "blue" };
    private string[] speciess = { "common", "endangered" };

    // Sprites
    private Sprite spriteB; // Blue
    private Sprite spriteY; // Yellow
    private Sprite spriteBL; // Blue w/ legs
    private Sprite spriteYL; // Yellow w/ legs
    private Sprite spriteBH; // Blue w/ hat
    private Sprite spriteYH; // Yellow w/ hat
    private Sprite spriteBHL; // Blue w/ hat + legs
    private Sprite spriteYHL; // Yellow w/ hat + legs

    // Size
    Vector2 scaleB = new Vector2(1, 1);
    Vector2 scaleS = new Vector2(0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        // Load sprites
        gameObject.transform.position = new Vector2(0, 10);
        spriteB = Resources.Load<Sprite>("BirdHeroblue");
        spriteY = Resources.Load<Sprite>("BirdHero");
        spriteBL = Resources.Load<Sprite>("BirdHeroblueLegs");
        spriteYL = Resources.Load<Sprite>("BirdHeroLegs");
        spriteBH = Resources.Load<Sprite>("Blue Hat Bird");
        spriteYH = Resources.Load<Sprite>("Yellow Hat Bird");
        spriteBHL = Resources.Load<Sprite>("Blue Hat + Legs Bird");
        spriteYHL = Resources.Load<Sprite>("Yellow Hat + Legs Bird");

        // Randomly assign features
        color = (Random.value > 0.5f) ? colors[0] : colors[1];
        height = Random.value * 2f;
        hasHat = (Random.value > 0.5f) ? true : false;
        hasLegs = (Random.value > 0.5f) ? true : false;
        isBird = true;

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
        if (color == "yellow" && !hasHat && !hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteY;
        }
        else if (color == "blue" && !hasHat && !hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteB;
        }
        else if (color == "yellow" && !hasHat && hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteYL;
        }
        else if (color == "blue" && !hasHat && hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBL;
        }
        else if (color == "yellow" && hasHat && !hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteYH;
        }
        else if (color == "blue" && hasHat && !hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBH;
        }
        else if (color == "yellow" && hasHat && hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteYHL;
        }
        else if (color == "blue" && hasHat && hasLegs)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBHL;
        } else
        {
            Debug.Log("No valid sprite");
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
