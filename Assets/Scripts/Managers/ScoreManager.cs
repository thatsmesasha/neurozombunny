﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    public Text text;


    void Awake ()
    {
        score = 0;
    }


    void Update ()
    {
        text.text = "SCORE: " + score;
    }
}
