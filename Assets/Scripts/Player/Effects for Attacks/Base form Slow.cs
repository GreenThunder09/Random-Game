using System.Collections.Generic;
using UnityEngine;

public class BaseformSlow : MonoBehaviour
{
    
    public int damageAmount = 1;
    public float damageRate = 1f; // Damage applied every X seconds
    public float duration = 10f; // How long the residue lasts
    private List<Collider2D> enemiesInRange = new List<Collider2D>();
    
    public LayerMask enemyLayer;
    public LayerMask PlayerLayer;

    

    void Start()
    {
        Destroy(gameObject, duration); // Residue disappears after 'duration'
        StartCoroutine(ApplyDamageRoutine());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0) // Check if the object is on the enemy layer
        {
            enemiesInRange.Add(other);
        }

        
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemiesInRange.Contains(other))
        {
            enemiesInRange.Remove(other);
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
                    }
                }
            }
        }
    }
}
