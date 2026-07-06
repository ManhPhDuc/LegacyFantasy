using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackRange = 0.6f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    [Header("Attack Point Position")]
    [SerializeField] private float attackPointX = 0.8f;
    [SerializeField] private float attackPointY = 0.05f;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Health playerHealth;

    [Header("Animation")]
    [SerializeField] private string attackTriggerName = "attack";

    private float nextAttackTime;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        }
    }

    private void Update()
    {
        UpdateAttackPointPosition();

        if (playerHealth != null && playerHealth.IsDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.J) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void UpdateAttackPointPosition()
    {
        if (attackPoint == null || spriteRenderer == null) return;

        float facingDirection = spriteRenderer.flipX ? -1f : 1f;

        attackPoint.localPosition = new Vector3(
            facingDirection * attackPointX,
            attackPointY,
            0f
        );
    }

    private void Attack()
    {
        if (attackPoint == null) return;

        if (animator != null)
        {
            animator.ResetTrigger(attackTriggerName);
            animator.SetTrigger(attackTriggerName);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPlayerAttackSound();
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponentInParent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, 0.05f);
    }
}