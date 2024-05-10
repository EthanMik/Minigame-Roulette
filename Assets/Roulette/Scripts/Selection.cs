using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public int gameNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Game 1"))
        {
            gameNumber = 1;
        }

        if (other.gameObject.CompareTag("Game 2"))
        {
            gameNumber = 2;
        }

        if (other.gameObject.CompareTag("Game 3"))
        {
            gameNumber = 3;
        }

        if (other.gameObject.CompareTag("Game 4"))
        {
            gameNumber = 4;
        }

    }

    public int GetSceneNum()
    {
        return gameNumber;
    }
}
