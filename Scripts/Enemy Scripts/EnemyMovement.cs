using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private bool moveOnX, moveOnY;

    private float min_X, max_X;
    private float min_Y, max_Y;

    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private float horizontal_MovementTreshold = 8f;
    [SerializeField]
    private float vertical_MovementTreshold = 6f;

    private Vector3 tempMovement_Horizontal;
    private Vector3 tempMovement_Vertical;

    private bool moveLeft = false;
    private bool moveUp = false;

    private void Start()
    {
        min_X = transform.position.x - horizontal_MovementTreshold;
        max_X = transform.position.x + horizontal_MovementTreshold;

        max_Y = transform.position.y;
        min_Y = transform.position.y - vertical_MovementTreshold;

        if (Random.Range(0,2) > 0)
        {
            moveLeft = true;
        }

    }

    private void Update()
    {

        HandleEnemyMovement_Horizontal();
        HandleEnemyMovement_Vertical();

    }

    void HandleEnemyMovement_Horizontal()
    {
        if (!moveOnX)
            return;

        if(moveLeft)
        {
            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;

            if (transform.position.x < min_X)
                moveLeft = false;
        }
        else
        {

            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;

            if (transform.position.x > max_X)
                moveLeft = true;

        }

    }


    void HandleEnemyMovement_Vertical()
    {

        if (!moveOnY)
            return;

        if (moveUp)
        {
            
            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;

            if (transform.position.y > max_Y)
                moveUp = false;
            
        }
        else
        {

            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;

            if (transform.position.y < min_Y)
                moveUp = true;

        }

    }








}
