using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float t;
    public float speed = 2f;

   //public GameObject car;

   public Transform start;
    public Transform end;

    public Vector2 movePos;

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
        //Instantiate(car, start.position, Quaternion.identity);

        //basic directional movement (along the y vector to accomodate for the direction of each car (up/down))
        transform.position += transform.up * speed * t;

        movePos = transform.position;
        transform.position = movePos;
        movePos.y = transform.position.y;

        //if left car is at the end point (up), respawn at bottom with a random speed (2-4)
        //if right car is at the end point (down), respawn at up with a random speed (2-4)
        if (movePos.y == end.position.y)
        {
            //despawn/respawn up/down (depending on lane) with a random speed between 2-4
            despawns = true;

            movePos.y = start.position.y;

            despawns = false;
        }


        //change the colour of the 3 cars every time the toy resets or the colour of the car that despawns and respawns
        t = Time.deltaTime;

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
}
