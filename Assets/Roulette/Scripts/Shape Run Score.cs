using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShapeRunScore
{
    public static int score = 0;

    public static void SetScore(int points)
    {
        if (points > score) 
            score = points;
    }
}
