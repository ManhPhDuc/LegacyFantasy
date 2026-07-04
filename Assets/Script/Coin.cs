using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private string playerTag = "Player";

    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected) return;

        if (!collision.CompareTag(playerTag)) return;

        isCollected = true;
        
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCoinSound();
        }

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}
