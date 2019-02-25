using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesDisplay : MonoBehaviour {

    Text enemiesAmountText;
    GameSession gameSession;

    // Use this for initialization
    void Start()
    {
        enemiesAmountText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAmountText.text = gameSession.GetKilledEnemies().ToString();
    }
}
