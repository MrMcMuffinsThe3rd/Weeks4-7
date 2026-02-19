using UnityEngine;
using UnityEngine.UI;

public class PlayerCarScript : MonoBehaviour
{
    public Slider slider;
    public Button restart;

    CarScript csStop;
    MoveCar mcStop;
    PlayerCarScript pcsStop;

    public bool gotHit = false; //checks if player car hit a car

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        csStop = GetComponent<CarScript>();
        mcStop = GetComponent<MoveCar>();
        pcsStop = GetComponent<PlayerCarScript>();
    }

    // Update is called once per frame
    void Update()
    {
      crashed();
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
        //check if player car is in NPC car's bounds (hit it)
        //if it is: stop the game, show score at the time the game stopped and prompt the player to restart
        //stop all scripts from running (deactivate them)

        if (gotHit == true)
        {



            //deactivates all game objects with these scripts attached (stops the game)
            csStop.gameObject.SetActive(false);
            mcStop.gameObject.SetActive(false);
            pcsStop.gameObject.SetActive(false);

            //shows end score, restart button and end game white screen, deactivates slider
            restart.gameObject.SetActive(true);
            slider.gameObject.SetActive(false);
            gameObject.SetActive(true); //shows end white screen

        }
        else
        {
            csStop.gameObject.SetActive(true);
            mcStop.gameObject.SetActive(true);
            pcsStop.gameObject.SetActive(true);

            restart.gameObject.SetActive(false);
            slider.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }
    }

    public void restartGame()
    {
        // prompts the player to restart the game if they want (using restart button "OnClick function")
        gotHit = false;
    }
}
