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

    public List<GameObject> cars; //list of 3 cars (bec only 3 cars can spawn on the screen at the same time)

    public Transform startPointLeft;
    public Transform startPointRight;

    public Transform endPointLeft;
    public Transform endPointRight;

    public bool despawns = false;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnedCar = Instantiate(carPrefab, startPointLeft.transform.position, Quaternion.identity);

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
            float distance = Vector2.Distance(cars[i].transform.position, endPointLeft.position);

            if (distance < 0.5f)
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



            ////despawns the car that reached the lanes' respective end points
            //if (SpawnedCar.transform.position.y == endPointRight.transform.position.y || SpawnedCar.transform.position.y == endPointLeft.transform.position.y)
            //{
            //    //destroy THIS car object (using list index)
            //    Destroy(SpawnedCar);
            //    //then set despawns to true
            //    despawns = true;
            //}
    }

    //white car source: https://www.istockphoto.com/vector/white-car-from-top-view-isolated-on-white-background-delivery-automobile-sedan-icon-gm1768708309-545597961
}
