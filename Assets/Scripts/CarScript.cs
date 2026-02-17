using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarScript : MonoBehaviour
{
    public float t;

    public GameObject SpawnedCar;
    public GameObject carPrefab; 

    public List<GameObject> cars; //list of 3 cars (bec only 3 cars can spawn on the screen at the same time)

    public Transform startPointLeft;
    public Transform startPointRight;

    public Transform endPointLeft;
    public Transform endPointRight;


    public bool despawns = false;

    SpriteRenderer sr; 
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
 
    }

    // Update is called once per frame
    void Update()
    {
        //change the colour of the 3 cars every time the toy resets or the colour of the car that despawns and respawns
        t = Time.deltaTime;

        //spawnCar = Instantiate(SpawnedCar, transform.position, transform.rotation);

        if (Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            SpawnedCar = Instantiate(SpawnedCar, startPointLeft.transform.position, Quaternion.identity);
        }
           

        //Instantiate(SpawnedCar, leftLane.position, Quaternion.identity); //instantiates car prefab

        

        //if left car is at the end point (up), respawn at bottom with a random speed (2-4)
        //if right car is at the end point (down), respawn at up with a random speed (2-4)

        //spawns car at either at start point right lane or start point left lane (random)
        if (gameObject.transform.position.y == endPointLeft.transform.position.y)
        {
            float laneSpawn = Random.Range(1, 2);

            laneSpawn = (int)laneSpawn; //type casts lane spawn to int to be used in if statement

            if (laneSpawn == 1)
            {
                //spawn car in start point left lane
                changeColour();
                SpawnedCar = Instantiate(carPrefab, startPointLeft.transform.position, Quaternion.identity);
                //SpawnedCar.transform.position = startPointLeft.transform.position;
                despawns = false;
            }
            else if (laneSpawn == 2)
            {
                //spawn car in start point right lane
                changeColour();
                SpawnedCar.transform.position = startPointRight.transform.position;
                despawns = false;
            }

        }

        //despawns the car that reached the lanes' respective end points
        if (SpawnedCar.transform.position == endPointRight.transform.position)
        {
            //destroy THIS car object (using list index)

            //then set despawns to true
            despawns = true;
        }


    }


    void changeColour()
    {
        //changes the colour of the spawned car to a random colour
       sr.color = Random.ColorHSV();
        
    }

    //white car source: https://www.istockphoto.com/vector/white-car-from-top-view-isolated-on-white-background-delivery-automobile-sedan-icon-gm1768708309-545597961
}
