﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        scoreCount += pointsPerSecond * Time.deltaTime;

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
    }
}
