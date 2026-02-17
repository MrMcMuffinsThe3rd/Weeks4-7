using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 2f;
    public float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         t = Time.deltaTime;

        //basic directional movement (along the y vector to accomodate for the direction of each car (up/down))
        transform.position += transform.up * speed * t;
    }
}
