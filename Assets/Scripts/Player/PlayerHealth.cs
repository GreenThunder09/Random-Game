using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    
    public float currentHealth { get; private set; }
    private bool dead;
    [SerializeField] private Animator animator;

    private const string flashRedAnim = "FlashRed";
    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

            animator.SetTrigger(flashRedAnim);
            //make iframes later
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("die");
                GetComponent<Playercontroller>().enabled = false;
                dead = true;
                Debug.Log("You Have Died!");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);


    }


}
