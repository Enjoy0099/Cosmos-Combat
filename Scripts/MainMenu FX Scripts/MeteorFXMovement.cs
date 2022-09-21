using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 5f, maxSpeed = 10f;

    private float speedY, speedX;

    [SerializeField]
    private float minRotateSpeed = 8f, maxRotateSpeed = 20f;

    private float rotationSpeed;

    private float zRotation;

    private bool moveX;

    private Vector3 tempPos;

    [HideInInspector]
    public bool moveDown;




    private void Awake()
    {
        speedY = Random.Range(minSpeed, maxSpeed);
        speedX = speedY;
        
        if (Random.Range(0, 2) > 0)
            moveX = true;

        if (Random.Range(0, 2) > 0)
            speedX *= -1f;

        rotationSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        if(Random.Range(0, 2)>0)
            rotationSpeed *= -1f;

    }


    private void Start()
    {
        if (moveDown)
            speedY *= -1f;
    }


    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }


    void HandleMovement()
    {
        tempPos = transform.position;
        tempPos.y += speedY * Time.deltaTime;
        transform.position = tempPos;

        if (!moveX)
            return;

        tempPos = transform.position;
        tempPos.x += speedX * Time.deltaTime;
        transform.position = tempPos;
    }

    void HandleRotation()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}
