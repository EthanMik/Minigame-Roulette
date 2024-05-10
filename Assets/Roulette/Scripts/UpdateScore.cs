using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string gameName;

    private void Start()
    {
        scoreText.GetComponent<TextMeshProUGUI>();    
    }

    void FixedUpdate()
    {
        if (gameName == "Circle Attack")
        {
            scoreText.text = "Best Circle Attack Score: " + CircleAttackScore.score.ToString();
        }

        if (gameName == "Shape Run")
        {
            scoreText.text = "Best Shape Run Score: " + ShapeRunScore.score.ToString();
        }

        if (gameName == "Cube Climb")
        {
            scoreText.text = "Best Cube Climb Score: " + CubeClimbScore.score.ToString();
        }
    }
}
