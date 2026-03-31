using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public GameObject residuePrefab;
    public Transform groundCheckPoint; // An empty child GameObject at the player's feet
    public float attackCooldown = 10f;
    private float cooldownTimer;
    Playercontroller playerController;

    private void Start()
    {
        playerController = GetComponent<Playercontroller>();
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && cooldownTimer <= 0 && playerController.isGrounded) 
        {
            CastSpecialAttack();
            cooldownTimer = attackCooldown;
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }

    //    else
    //    {
    //        isGrounded = false;
    //    }
    //}

    void CastSpecialAttack()
    {
        
        Instantiate(residuePrefab, groundCheckPoint.position, Quaternion.identity);
        // add an animation trigger
    }
}
