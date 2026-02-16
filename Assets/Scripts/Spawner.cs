using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            randomSpawn();
        }

        
    }

    public void randomSpawn()
    {
        Vector2 newPos = transform.position;
        //Random.range
        //newPos.x =
        //Instantiate(prefab, transform.position);
        
    }
}
