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

        hasWon = true;

        PlayerController playerController = collision.GetComponent<PlayerController>();
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
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