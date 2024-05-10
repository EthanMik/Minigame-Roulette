using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeClimbScore
{
    public static int score = 0;

    public static void SetScore(int points)
    {
        if (points > score)
            score = points;
    }
}
