using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI Score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += 1;
        Score.text = ((int)score).ToString();
    }
}
