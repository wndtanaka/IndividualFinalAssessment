using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Base Enemy")]
    public int health;
    public int damage;
    public int loot;

    private float curHealth;
    bool isDead = false;
    Image healthBar;
    GameObject enemyHealthBar;
   
    // Use this for initialization
    void Start()
    {
        curHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        //curHealth -= damage;
        //healthBar.fillAmount = curHealth / health;

        if (health <= 0 && isDead)
            Die();
    }
    public void Die()
    {
        isDead = true;

        Destroy(gameObject);
    }
}
