using UnityEngine;
using UnityEngine.UI;

public class PlayerCarScript : MonoBehaviour
{
    public Slider slider;
    public Button restart;

    public bool gotHit = true; //checks if a car got hit by player car 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<CarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player car is in NPC car's bounds (hit it)
        //if it is: stop the game, show score at the time the game stopped and prompt the player to restart
        //stop all scripts from running (deactivate them)

    }

    public void move()
    {
        //used this source for help: https://discussions.unity.com/t/using-a-slider-to-change-an-objects-transform/602006/2
        //turns out I was just assigning transform.position to movePlayer before assigning the value of movePlayer.x to the slider value

        //assigns the slider to move the X axis of the player car
        Vector2 movePlayer = transform.position;
        movePlayer.x = slider.value;
        transform.position = movePlayer;
    }

    public void crashed()
    {
        if (gotHit == true)
        {
            //stop the game, show restart button and restartScreen
            //stop all scripts from running (deactivate them)
         
            gameObject.SetActive(true);
        }
        else if (gotHit == false || restart == false)
        {
            gameObject.SetActive(false);
        }

    }
}
