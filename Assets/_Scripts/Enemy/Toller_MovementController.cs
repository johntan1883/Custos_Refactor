using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Toller_MovementController : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;

    private Rigidbody2D rb2d;
    private Transform currentPoint;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }
      
    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position; //direction of where the enemy will go
        if (currentPoint == pointB.transform)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) //if the enemy has reach the current point and the point is pointB
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) //if the enemy has reach the current point and the point is pointA
        {
            currentPoint = pointB.transform;
        }
    }
}
