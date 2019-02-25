using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    TMP_Text healthText;
    Player player;

	// Use this for initialization
	void Start () {
        healthText = GetComponent<TMP_Text>();
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = player.GetHealth().ToString();
	}
}
