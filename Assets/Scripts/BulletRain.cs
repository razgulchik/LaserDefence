using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRain : MonoBehaviour {

    Player player;
    [SerializeField] float durationOfBulletRain = 7f;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position;
    }

    IEnumerator Countdown()
    {
        player.GetComponent<Player>().SetProjectyleSpeed(25f, 0.02f);
        yield return new WaitForSeconds(durationOfBulletRain);
        player.GetComponent<Player>().SetProjectyleSpeed(16f, 0.1f);
        Destroy(gameObject);
    }
}
