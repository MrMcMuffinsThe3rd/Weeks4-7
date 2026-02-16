using UnityEngine;

public class RotateMe : MonoBehaviour
{
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.z += speed * Time.deltaTime;
        transform.eulerAngles = rotate;
    }

    public void StartSpin()
    {
        speed = 100f;
    }

    public void StopSpin()
    {
        speed = 0f;
    }
}
