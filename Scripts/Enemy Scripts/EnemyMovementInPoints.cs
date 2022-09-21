using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementInPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] movementPoints;

    private int currentMoveIndex = 0;

    private Vector3 targetPosition;

    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private bool moveRandomly;


    private void Start()
    {
        SetTargetPosition();
    }


    private void Update()
    {
        Move();
    }

    void SelectRandomPosition()
    {
        while(movementPoints[currentMoveIndex].position == targetPosition)
        {
            currentMoveIndex = Random.Range(0, movementPoints.Length);
        }
        targetPosition = movementPoints[currentMoveIndex].position;
    }

    void SelectPointToPointPosition()
    {

        if (currentMoveIndex == movementPoints.Length)
            currentMoveIndex = 0;

        targetPosition = movementPoints[currentMoveIndex].position;

        currentMoveIndex++;

    }

    void SetTargetPosition()
    {

        if (moveRandomly)
            SelectRandomPosition();
        else
            SelectPointToPointPosition();

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                targetPosition, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetTargetPosition();
        }
    }







}
