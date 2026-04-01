using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; 
    public int currentHealth;
    public float speed = 5f;
    public float currentSpeed;
    

    void Start()
    {
        currentSpeed = speed;
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

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}
