using System.Collections;
using UnityEngine;

public class EnemyHitFeedback : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Hit Feedback")]
    [SerializeField] private float blinkDuration = 0.2f;
    [SerializeField] private float blinkInterval = 0.05f;

    private Coroutine blinkCoroutine;

    private void Awake()
    {
        if (health == null)
        {
            health = GetComponent<Health>();
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void OnEnable()
    {
        if (health != null)
        {
            health.OnDamaged += PlayHitFeedback;
        }
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.OnDamaged -= PlayHitFeedback;
        }
    }

    private void PlayHitFeedback()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayEnemyHitSound();
        }
        
        if (spriteRenderer == null) return;

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }

        blinkCoroutine = StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        float timer = 0f;

        while (timer < blinkDuration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            timer += blinkInterval * 2f;
        }

        spriteRenderer.enabled = true;
    }
}