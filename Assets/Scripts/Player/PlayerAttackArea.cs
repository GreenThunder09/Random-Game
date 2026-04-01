using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    private int damage = 2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage dealt");
            collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
