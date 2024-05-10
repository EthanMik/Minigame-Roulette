using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private Score score;

    private void Start()
    {
        score = GetComponent<Score>();
    }

    void Update()
    {
        if (!score.isGameRunning)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);

    }
}
