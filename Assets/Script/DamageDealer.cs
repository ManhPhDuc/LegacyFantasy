using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float damageCooldown = 1f;

    [Header("Target Settings")]
    [SerializeField] private string targetTag = "Player";

    private readonly Dictionary<Health, float> lastDamageTime = new Dictionary<Health, float>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDealDamage(collision.gameObject);
    }

    private void TryDealDamage(GameObject targetObject)
    {
        Health targetHealth = targetObject.GetComponentInParent<Health>();

        if (targetHealth == null) return;
        if (targetHealth.IsDead) return;

        if (!string.IsNullOrEmpty(targetTag))
        {
            bool targetObjectHasTag = targetObject.CompareTag(targetTag);
            bool healthObjectHasTag = targetHealth.CompareTag(targetTag);

            if (!targetObjectHasTag && !healthObjectHasTag)
            {
                return;
            }
        }

        if (lastDamageTime.TryGetValue(targetHealth, out float lastTime))
        {
            if (Time.time < lastTime + damageCooldown)
            {
                return;
            }
        }

        targetHealth.TakeDamage(damageAmount);
        lastDamageTime[targetHealth] = Time.time;
    }
}
