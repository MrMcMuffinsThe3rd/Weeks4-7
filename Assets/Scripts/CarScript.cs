using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarScript : MonoBehaviour
{
    public float t = 0f;
    float laneSpawn;

    public GameObject SpawnedCar;
    public GameObject carPrefab; 

    public List<GameObject> cars; //list to keep track of spawned cars

    public Transform startPointLeft;
    public Transform startPointRight;

    public Transform endPointLeft;
    public Transform endPointRight;

    public bool despawns = false;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnedCar = Instantiate(carPrefab, startPointLeft.transform.position, Quaternion.identity);
        cars.Add(SpawnedCar);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;


        //simulates a coin flip to decide between which lane to spawn the car
        //returns a number for laneSpawn
        if (t > 2 || t == 2)
        {
            t = 0;

            //picks between 1 or 2 to decide later which lane to spawn the car in
            laneSpawn = Random.Range(1, 3);

        }

        //type casts lane spawn to int to be used in if statement
        laneSpawn = (int)laneSpawn;
        despawns = false;

        spawnCar();

        //if (cars.Count > 0)
        //{
        //    for (int i = cars.Count - 1; i >= 0; i--)
        //    {
        //        //checks if playerCar crashed into NPCcar
        //        PlayerCarScript player = GetComponent<PlayerCarScript>();

        //        player.gameObject.transform.position = transform.position;

        //        float distanceBetweenNPCcarAndPlayerCar = Vector2.Distance(cars[i].transform.position, player.gameObject.transform.position);

        //        if (distanceBetweenNPCcarAndPlayerCar < 0.05f)
        //        {
        //            PlayerCarScript ps = GetComponent<PlayerCarScript>();
        //            ps.gotHit = true;
        //        }
        //    }
        //}

        despawnCar();
       
    }

        void spawnCar()
    {
        //spawns car either at start point right lane or start point left lane (random)
        if (despawns == false)
        {


            if (laneSpawn == 1)
            {
                //spawn car in start point left lane
                SpawnedCar = Instantiate(carPrefab, startPointLeft.transform.position, Quaternion.identity);
                
                //randomises speed of each car spawned (cs = "car speed")
                MoveCar cs = SpawnedCar.GetComponent<MoveCar>();
                cs.speed = Random.Range(3f, 5f);

                //adds spawned cars to the list of cars
                cars.Add(SpawnedCar);

                //resets attributes
                despawns = false;
                laneSpawn = 0;
            }
            else if (laneSpawn == 2)
            {
                //spawn car in start point right lane
                SpawnedCar = Instantiate(carPrefab, startPointRight.transform.position, Quaternion.Euler(0, 0, 180));

                //randomises speed of each car spawned (cs = "car speed")
                MoveCar cs = SpawnedCar.GetComponent<MoveCar>();
                cs.speed = Random.Range(3f, 5f);

                //adds spawned cars to the list of cars
                cars.Add(SpawnedCar);

                //resets attributes
                despawns = false;
                laneSpawn = 0;
            }

        }

    }


    void despawnCar()
    {
        for (int i = cars.Count - 1; i >= 0 ; i--)
        {
            float distanceLeft = Vector2.Distance(cars[i].transform.position, endPointLeft.position);
            float distanceRight = Vector2.Distance(cars[i].transform.position, endPointRight.position);

            //checks if the cars reached the end points of the lanes, despawns them if they did
            //removes any spawned cars out of bounds that weren't otherwise despawned by using distance
            if (distanceLeft < 0.05f || distanceRight < 0.05f || SpawnedCar.transform.position.y > endPointLeft.position.y || SpawnedCar.transform.position.y < endPointRight.position.y)
            {
                Debug.Log("despawned car succesfully " + i);

                //local variable to get a referance to the car
                GameObject car = cars[i];

                //remove the car from the list
                cars.Remove(car);

                //then destroy the car
                Destroy(car);
            }
        }
    }

    //white car source: https://www.istockphoto.com/vector/white-car-from-top-view-isolated-on-white-background-delivery-automobile-sedan-icon-gm1768708309-545597961
}
