using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipFXMovement : MonoBehaviour
{

    [SerializeField]
    private float minSpeed = 5f, maxSpeed = 10f;

    private float moveSpeed;

    private Vector3 temp;

    private bool moveVertical, moveHorizontal;

    private void Update()
    {
        MoveVertical();
        MoveHorizontal();

    }

    void MoveVertical()
    {
        if (!moveVertical)
            return;

        temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void MoveHorizontal()
    {
        if (!moveHorizontal)
            return;

        temp = transform.position;
        temp.x += moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    public void SetMovement(bool verticalMovement, bool horizontalMovement, bool moveNegative)
    {
        moveHorizontal = horizontalMovement;
        moveVertical = verticalMovement;

        moveSpeed = Random.Range(minSpeed, maxSpeed);

        if (moveNegative)
            moveSpeed *= -1f;

        if (moveVertical && moveNegative)
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        if (moveHorizontal && moveNegative)
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        if (moveHorizontal && !moveNegative)
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);

    }


}
