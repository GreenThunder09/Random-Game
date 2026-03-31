using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; 
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        Destroy(gameObject); 
    }
}
