using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Toller_MovementController : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private Transform playerTransform;

    private Rigidbody2D rb2d;
    private Transform currentPoint;
    private EnemyDetectPlayer detectPlayer;
    private bool isChasing;

    private void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void Start()
    {
        Flip();
        rb2d = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        detectPlayer = GetComponentInChildren<EnemyDetectPlayer>();

        detectPlayer.OnDetectPlayer += DetectPlayer_OnDetectPlayer; //Subscribe to OnDetectPlayer Event
    }

    private void Update()
    {
        Patrol();
        ChasePlayer();
    }

    private void DetectPlayer_OnDetectPlayer()
    {
        Debug.Log("Player Detected");
        isChasing = true;
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Patrol()
    {   if (isChasing != true)
        {
            Vector2 point = currentPoint.position - transform.position; //direction of where the enemy will go
            if (currentPoint == pointB.transform)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) //if the enemy has reach the current point and the point is pointB
            {
                currentPoint = pointA.transform;
                Flip();
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) //if the enemy has reach the current point and the point is pointA
            {
                currentPoint = pointB.transform;
                Flip();
            }
        }
    }

    private void ChasePlayer()
    {
        if (isChasing)
        {
            if (playerTransform != null)
            {
                if (transform.position.x > playerTransform.position.x) //if the player is at the left of the enemy
                {
                    transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x) //if the player is at the left of the enemy
                {
                    transform.position += Vector3.right * chaseSpeed * Time.deltaTime;
                }
            }
        }
    }
}
