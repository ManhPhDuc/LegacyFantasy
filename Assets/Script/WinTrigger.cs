using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WinUI winUI;

    [Header("Settings")]
    [SerializeField] private string playerTag = "Player";

    private bool hasWon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasWon) return;
        if (!collision.CompareTag(playerTag)) return;

        Health playerHealth = collision.GetComponent<Health>();

        if (playerHealth != null && playerHealth.IsDead)
        {
            return;
        }

        hasWon = true;

        PlayerController playerController = collision.GetComponent<PlayerController>();
        PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (playerAttack != null)
        {
            playerAttack.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (winUI != null)
        {
            winUI.ShowWinPanel();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayWinSound();
        }

        Debug.Log("Player wins!");
    }
}