using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankSpawner : MonoBehaviour
{
    public GameObject tankPrefab; //"GameObject" is the unity keyword for Prefabs
    public int howManyTanks = 0;
    public GameObject SpawnedTank;

    public FirstScript tankScript;
    public SpriteRenderer tankSR;

    public List<GameObject> tanks;
    public Transform barrel;

    public GameObject duckiePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Instantiate(duckiePrefab, Random.insideUnitCircle * 3, Quaternion.identity);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Instantiate(tankPrefab); //this is the Constructor keyword we use to spawn Tank prefabs

            //setting a spawn point for prefabs
            //instantiate a prefab, a vector2 or vector3, a Quaternion: make it appear at this position and rotation
            //Instantiate(tankPrefab, transform.position, transform.rotation);
            //transform.postion and transform.rotation is assigned from the gameobject this current script (TankSpawner) is palced on

            SpawnedTank = Instantiate(tankPrefab, transform.position, transform.rotation);
            
            tankScript = SpawnedTank.GetComponent<FirstScript>(); //hey, get me the FirstScript from
                                                                  //the spawnedTank and assign it to my tankScript

            tankSR = SpawnedTank.GetComponent<SpriteRenderer>();

            howManyTanks += 1;
            tankScript.speed = howManyTanks;
            //tankScript.body.color = Random.ColorHSV();

            tanks.Add(SpawnedTank);


            if (Mouse.current.rightButton.wasPressedThisFrame == true)
            {
                tanks.Remove(SpawnedTank);
                Destroy(SpawnedTank);
            }

            //loop through everything in the tanks list: these are gameobjects
            //get hold of that game object's FirstScript component
            //set the speed to howManyTanks

            for (int i = 0; i < tanks.Count; i++)
            {
                //FirstScript ts = tanks[i].GetComponent<FirstScript>();
                //ts.speed = howManyTanks;

                float distance = Vector2.Distance(tanks[i].transform.position, barrel.position);
                if (distance < 0.5f)
                {
                    Debug.Log("Explode tank" + i);
                    //make a local variable to get a reference to the tank
                    GameObject tank = tanks[i];
                    //remove the tank from the list
                    tanks.Remove(tank);

                    //destroy the tank
                    Destroy(tank);
                }


            }

            //Vector2 spawnPos = Random.insideUnitCircle * 3;
            //Quaternion.identity means it won't rotate which is the same as euler angles (0, 0, 0)
            //Why don't we just not add any rotation at all? --> instatiate(prefab, vector2/3, a quaternion) requires us to add a rotation
            //Instantiate(tankPrefab, spawnPos, Quaternion.identity);
        }

        //if (Mouse.current.rightButton.wasPressedThisFrame)
        //{
        //    //instantiate a prefabe, a Transform: makes it appear at 0, 0 as the child of that transform
        //    Instantiate(tankPrefab, transform);
        //} 
    }
}
