using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score
    {
        get;
        private set;
    }

    private void AddScore(int score, int magnification)
    {
        Score += score * magnification;
    }
}
