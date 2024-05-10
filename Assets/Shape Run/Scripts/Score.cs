using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 1f;
    private int timeSeconds;
    private double timeDecimal;
    public string gameName;

    public bool isGameRunning;

    public TextMeshProUGUI textMeshPro;

    public GameObject player;

    private float startTime;

    public int maxPoints = 500000;

    private void Start()
    {
        isGameRunning = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;

            if (timer > interval)
            {
                IncrementTime();

                timer = 0f;
            }
        }
        else
        {
            int points = (int)(maxPoints / timeDecimal);
            textMeshPro.text = "Score: " + points;

            if (gameName == "Cube Climb")
                CubeClimbScore.SetScore(points);
            if (gameName == "Shape Run")
                ShapeRunScore.SetScore(points);

            SceneManager.LoadScene("Roulette");
            player.SetActive(false);       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            isGameRunning = false;
        }
    }

    public void IncrementTime()
    {
        float elapsedTime = Time.time - startTime;
        timeDecimal = elapsedTime;
        timeSeconds = Mathf.CeilToInt(elapsedTime);
        textMeshPro.text = timeSeconds.ToString();
    }
}
