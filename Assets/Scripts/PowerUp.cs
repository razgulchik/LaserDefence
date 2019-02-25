using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] GameObject powerUpType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.GetType());
        FindObjectOfType<Player>().SetupPowerUp(powerUpType);
        Destroy(gameObject);
    }
}
