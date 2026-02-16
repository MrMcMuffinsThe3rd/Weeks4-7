using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject is the GameObejct this script is atatched to
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
