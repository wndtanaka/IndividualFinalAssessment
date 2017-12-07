using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; } // other class can get value, but set only from this class

    public Stats damage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage) // when character taking damage
    {
        currentHealth -= damage;
        if (currentHealth <= 0) // when currenthealth <= 0 die
        {
            Die();
        }
    }
    public virtual void Die() // for future, we can set this to respawn, game over or anything because of virtual
    {
        Debug.Log("DIE");
    }
}
