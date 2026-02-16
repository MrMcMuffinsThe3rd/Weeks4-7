using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirstScript : MonoBehaviour
{
    public float speed = 1f;

    public SpriteRenderer body;

    Vector2 bottomLeft;
    Vector2 bottomRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        bottomRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //speed = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveTank = transform.position;
        moveTank.x += speed;
        transform.position = moveTank;

        Vector2 screenSize = Camera.main.WorldToScreenPoint(transform.position);

        if (screenSize.x < 0 || screenSize.x > Screen.width)
        {
            speed *= -1;
        }
    }
}
