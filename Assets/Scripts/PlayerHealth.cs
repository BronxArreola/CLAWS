using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public Transform spawnPoint;


    public SpriteRenderer playerSr;
    public SideScrollPlayer playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
{
    health -= amount;

    if (health <= 0)
    {
        transform.position = spawnPoint.position;

        health = maxHealth;

        playerSr.enabled = true;
        playerMovement.enabled = true;
    }
}

}