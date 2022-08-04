using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public void increaseScore(int ammountToIncrease)
    {
        score += ammountToIncrease;
        Debug.Log($"Score is now: {score}");
    }
}

