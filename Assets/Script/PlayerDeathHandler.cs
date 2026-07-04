using System.Collections;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health health;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameOverUI gameOverUI;

    [Header("Animation")]
    [SerializeField] private string deadParameterName = "isDead";

    [Header("Death Settings")]
    [SerializeField] private bool stopMovementOnDeath = true;
    [SerializeField] private float gameOverDelay = 1f;

    private bool isDead;

    private void Awake()
    {
        if (health == null)
        {
            health = GetComponent<Health>();
        }

        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
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

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (stopMovementOnDeath && rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        if (animator != null)
        {
            animator.SetFloat("speed", 0f);
            animator.SetBool("isJump", false);
            animator.SetBool(deadParameterName, true);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPlayerDeathSound();
        }

        StartCoroutine(ShowGameOverAfterDelay());
    }

    private IEnumerator ShowGameOverAfterDelay()
    {
        yield return new WaitForSeconds(gameOverDelay);

        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }
}