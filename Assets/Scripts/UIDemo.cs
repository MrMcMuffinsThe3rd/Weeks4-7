using UnityEngine;
using UnityEngine.InputSystem;

public class UIDemo : MonoBehaviour
{

    //public SpriteRenderer spriteRenderer; //you can make it public to show up in the inspector

    //ORRR

    //don't make it private and refernce it in Start()
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     sr = GetComponent<SpriteRenderer>(); //sprite renderer reference
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame == true)
        {
            ChangeColour();
        }
    }

    public void ChangeColour() 
    {

      sr.color = Random.ColorHSV();
    
    }

    public void SetSize(float size)
    {
        transform.localScale = Vector3.one * size; //or Vector2.one 
        //Note: In the inspector, setting the scale to function to -1 will flip the game object upside down
    }
}
