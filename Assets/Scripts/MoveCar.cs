using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 3f;
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

        //basic directional movement (along the y vector to accomodate for the direction of each car (up/down))
        transform.position += transform.up * speed * t;
    }

    void changeColour()
    {
        //changes the colour of the spawned car to a random colour
        sr.color = Random.ColorHSV();

    }
}
