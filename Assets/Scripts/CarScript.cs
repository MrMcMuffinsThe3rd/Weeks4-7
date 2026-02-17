using Unity.VisualScripting;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float t;
    public float speed = 2f;

   public GameObject SpawnedCar; //white car prefab

    public Transform leftLane;
    public Transform rightLane;

    public Vector2 movePos;

   public bool despawns = false;

    SpriteRenderer sr; 
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        leftLane = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //change the colour of the 3 cars every time the toy resets or the colour of the car that despawns and respawns
        t = Time.deltaTime;
        


        //Instantiate(SpawnedCar, leftLane.position, Quaternion.identity); //instantiates car prefab

        //basic directional movement (along the y vector to accomodate for the direction of each car (up/down))
        transform.position += transform.up * speed * t;

        //if left car is at the end point (up), respawn at bottom with a random speed (2-4)
        //if right car is at the end point (down), respawn at up with a random speed (2-4)
        if (t > 1)
        {
            //despawn/respawn up/down (depending on lane) with a random speed between 2-4
            despawns = true;

            movePos.y = leftLane.position.y;

            despawns = false;
        }

        if (despawns == true)
        {
            changeColour();
        }

       
    }


    void changeColour()
    {
        
       sr.color = Random.ColorHSV();
        
    }

    void randomDirectionSpawn()
    {

    }


    //white car source: https://www.istockphoto.com/vector/white-car-from-top-view-isolated-on-white-background-delivery-automobile-sedan-icon-gm1768708309-545597961
}
