using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] float health = 500f;
    [SerializeField] int scoreValue = 100;

    [Header("Shooting")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float minTimeBetweenShots = 10f;
    [SerializeField] float maxTimeBetweenShots = 2000f;
    float shotCounter;

    [Header("Effects")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip dieSound;
    [SerializeField] [Range(0, 1)] float dieSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.1f;
    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.05f;

    GameSession gameSession;
    BonusController bonusController;

    // Use this for initialization
    void Start () {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        gameSession = FindObjectOfType<GameSession>();
        bonusController = FindObjectOfType<BonusController>();
    }
	
	// Update is called once per frame
	void Update () {
        CountDownAndShot();
	}

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots); ;
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position,shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
        TriggerExplosionVFX();
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, hitSoundVolume);
    }

    private void Die()
    {
        
        gameSession.AddToKilledEnemies();
        gameSession.AddScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 0.7f);
        if(UnityEngine.Random.Range(1, 12) == 6)
        {
            RespawnBonus();
        }
        AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position, dieSoundVolume);
    }

    private void TriggerExplosionVFX()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 0.07f);
    }

    private void RespawnBonus()
    {
        GameObject powerUp = Instantiate(
            bonusController.ReturnBonusType(),
            transform.position,
            Quaternion.identity) as GameObject;
        powerUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
    }
}
