using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 0.05f;
    public float t;

    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        changeColour();
    }

    // Update is called once per frame
    void Update()
    {

         t = Time.deltaTime;

        //if (t > 0.02 || t == 0.02)
        //{
        //    t = 0;

        //    //makes the speed change in this range every 4 seconds
        //    speed = Random.Range(0.05f, 0.08f);
        //}

        Debug.Log("spawned car speed = " + speed);

        //basic directional movement (along the y vector to accomodate for the direction of each car (up/down))
        transform.position += transform.up * speed * t;
    }

    void changeColour()
    {
        //changes the colour of the spawned car to a random colour
        sr.color = Random.ColorHSV();

    }
}
