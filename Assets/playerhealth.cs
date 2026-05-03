using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 100;

    private int currentHealth;
    private bool canTakeDamage = true;
    private bool isDead = false;

    public float damageCooldown = 1f;

    private PlayerMovement playerMovement;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (healthBar != null)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, Time.deltaTime * 5f);
        }

        if (!isDead && currentHealth <= 0)
        {
            isDead = true;
            if (playerMovement != null)
            {
                playerMovement.GameOverFromHealth();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage || isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        canTakeDamage = false;
        Invoke(nameof(ResetDamage), damageCooldown);
    }

    // Fixed: Logic to increase health and cap it at max
    public void Heal(int amount)
    {
        if (isDead) return;
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); 
    }

    void ResetDamage()
    {
        canTakeDamage = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Updated: Damage increased to -25 as requested
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(25); 
        }
    }

    // Updated: This handles the Potion pickup and vanishing
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Potion"))
        {
            Heal(10); // Give +10 health
            Destroy(other.gameObject); // This makes the potion vanish
            Debug.Log("Health increased by 10!");
        }
    }
}