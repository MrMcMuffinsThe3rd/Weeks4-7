using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color col;
    public Sprite[] barrels;
    public int randomNumber;
    public List<Sprite> barrelsList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PickARandomColour(); 
        //PickARandomSprite();

        spriteRenderer = GetComponent<SpriteRenderer>();
        //PickARandomSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            PickARandomColour();
            PickARandomSprite();

            Debug.Log("New Colour please");
            if (barrelsList.Count > 0)
            {
                PickARandomSprite();
            }
        }

        //get the mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //NOT this one: spriteRenderer.sprite.bounds.Contains(mousePos). This is at (0,0)
        //THIS ONE: spriteRenderer.bounds.Contains(mousePos). This is where the sprite renderer is in the world

        //is the mouse over this sprite?
        if (spriteRenderer.bounds.Contains(mousePos) == true)
        {
            //Y:set the colour to our col variable
            spriteRenderer.color = col;
        }
        else
        {
            //N: set the colour to white
            spriteRenderer.color = Color.white;
        }
        if (Mouse.current.leftButton.wasPressedThisFrame == true && barrelsList.Count > 0)
        {
            barrelsList.RemoveAt(0);
        }

        void PickARandomColour()
        {
            spriteRenderer.color = Random.ColorHSV();
        }

        void PickARandomSprite()
        {
            //pick a random
            randomNumber = Random.Range(0, barrels.Length);
            //assign that sprite to our sprite renderer
            spriteRenderer.sprite = barrels[randomNumber];
        }

    }
}
