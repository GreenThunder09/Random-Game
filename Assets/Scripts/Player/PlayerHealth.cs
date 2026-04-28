using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    
    public float currentHealth { get; private set; }
    private bool dead;
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //make iframes later
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
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
