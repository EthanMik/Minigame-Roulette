using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteSpin : MonoBehaviour
{
    private Selection gameSelected;

    public float degrees;
    public float multiplier = 0.1f;
    float randomEnd;
    bool isSpinning;

    [System.Obsolete]
    private void Start()
    {
        gameSelected = FindObjectOfType<Selection>();

        System.Random random = new System.Random();
        randomEnd = (float)(random.NextDouble() * (12.5 - 11.5) + 11.5);
        isSpinning = true;
    }
    void FixedUpdate()
    {
        Debug.Log(gameSelected.GetSceneNum());

        transform.rotation = Quaternion.Euler(transform.rotation.z, transform.rotation.y, transform.rotation.z + degrees);
        if (isSpinning)
        {
            degrees += multiplier;
            multiplier += 0.2f;
        }

        if (multiplier >= 30)
        {
            multiplier = 30;
        }

        if (multiplier >= 30 || !isSpinning)
        {
            isSpinning = false;

            if (System.MathF.Round(degrees / 360, 1) == System.MathF.Round(randomEnd, 1))
            {
                multiplier = 0;
                StartCoroutine(Wait());
            }

            degrees += multiplier;
            multiplier -= 0.2f;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        int sceneNum = gameSelected.GetSceneNum();

        if (sceneNum == 1)
        {
            SceneManager.LoadScene("Shape Run Controls");
        }
        if (sceneNum == 2)
        {
            SceneManager.LoadScene("Circle Attack Controls");
        }
        if (sceneNum == 4) 
        {
            SceneManager.LoadScene("Cube Climb Controls");
        }
    }
}
