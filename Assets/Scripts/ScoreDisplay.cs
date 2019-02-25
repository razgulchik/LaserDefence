﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    TMP_Text scoreText;
    GameSession gameSession;
    

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<TMP_Text>();
        gameSession = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = gameSession.GetScore().ToString();
	}
}
