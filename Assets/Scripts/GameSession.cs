using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;
    int amountOfKilledEnemies = 0;

    // Use this for initialization
    private void Awake () {
        SetupSingleton();
	}

    private void SetupSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Start () {
		
	}

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public void AddToKilledEnemies()
    {
        amountOfKilledEnemies++;
    }

    public int GetKilledEnemies()
    {
        return amountOfKilledEnemies;
    }

    public void ResetKilledEnemies()
    {
        amountOfKilledEnemies = 0;
    }
}
