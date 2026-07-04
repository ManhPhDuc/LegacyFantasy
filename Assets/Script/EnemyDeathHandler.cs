using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health health;
    [SerializeField] private EnemyPatrol enemyPatrol;
    [SerializeField] private DamageDealer damageDealer;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D enemyCollider;

    [Header("Animation")]
    [SerializeField] private string deadParameterName = "isDead";

    [Header("Death Settings")]
    [SerializeField] private float destroyDelay = 1f;

    private bool isDead;

    private void Awake()
    {
        if (health == null) health = GetComponent<Health>();
        if (enemyPatrol == null) enemyPatrol = GetComponent<EnemyPatrol>();
        if (damageDealer == null) damageDealer = GetComponent<DamageDealer>();
        if (animator == null) animator = GetComponent<Animator>();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (enemyCollider == null) enemyCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        if (health != null)
        {
            health.OnDead += HandleDeath;
        }
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.OnDead -= HandleDeath;
        }
    }

    private void HandleDeath()
    {
        if (isDead) return;

        isDead = true;

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = false;
        }

        if (damageDealer != null)
        {
            damageDealer.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        if (animator != null)
        {
            animator.SetBool(deadParameterName, true);
        }
        
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayEnemyDeathSound();
        }

        Destroy(gameObject, destroyDelay);
    }
}