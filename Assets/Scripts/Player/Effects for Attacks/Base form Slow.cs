using System.Collections.Generic;
using UnityEngine;

public class BaseformSlow : MonoBehaviour
{
    public int damageAmount = 2;
    public float damageRate = 2f; // Damage applied every X seconds
    public float duration = 10f; // How long the residue lasts
    private List<Collider2D> enemiesInRange = new List<Collider2D>();
    [SerializeField] float slowSpeed = 0.5f;

    void Start()
    {
        Destroy(gameObject, duration); // Residue disappears after 'duration'
        StartCoroutine(ApplyDamageRoutine());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) // Check if the object is on the enemy layer
        {
            enemiesInRange.Add(other);
            other.GetComponent<EnemyHealth>().SetSpeed(slowSpeed);
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemiesInRange.Contains(other))
        {
            enemiesInRange.Remove(other);
            other.GetComponent<EnemyHealth>().ResetSpeed();
        }
    }
    
    System.Collections.IEnumerator ApplyDamageRoutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(damageRate);
            foreach (Collider2D enemyCollider in enemiesInRange)
            {
                
                if (enemyCollider != null)
                {
                    EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                        enemyHealth.currentSpeed = enemyHealth.speed * 0.5f;
                    }
                }
            }
        }
    }
}
