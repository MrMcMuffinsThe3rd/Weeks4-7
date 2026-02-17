using UnityEngine;
using UnityEngine.UI;

public class PlayerCarScript : MonoBehaviour
{
    public Slider slider;
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void move()
    {
        //used this source for help: https://discussions.unity.com/t/using-a-slider-to-change-an-objects-transform/602006/2
        //turns out I was just assigning transform.position to movePlayer before assigning the value of movePlayer.x to the slider value

        //assigns the slider to move the X axis of the player car
        Vector2 movePlayer = transform.position;
        movePlayer.x = slider.value * Time.deltaTime;
        transform.position = movePlayer;
    }
}
