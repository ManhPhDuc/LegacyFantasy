using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float patrolDistance = 3f;
    [SerializeField] private bool startMovingRight = true;

    [Header("Sprite")]
    [SerializeField] private bool spriteFacesRightByDefault = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float startX;
    private int direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        startX = transform.position.x;
        direction = startMovingRight ? 1 : -1;

        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        CheckTurnAround();
        Patrol();
        UpdateFacingDirection();
    }

    private void Patrol()
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void CheckTurnAround()
    {
        if (transform.position.x >= startX + patrolDistance)
        {
            direction = -1;
        }
        else if (transform.position.x <= startX - patrolDistance)
        {
            direction = 1;
        }
    }

    private void UpdateFacingDirection()
    {
        if (spriteRenderer == null) return;

        if (spriteFacesRightByDefault)
        {
            spriteRenderer.flipX = direction < 0;
        }
        else
        {
            spriteRenderer.flipX = direction > 0;
        }
    }
}
