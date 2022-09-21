using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10f, minSpeed = 4f;

    private float speedX, speedY;
    private bool moveOnX, moveOnY = true;

    [SerializeField]
    private float minRotationSpeed = 15f, maxRotationSpeed = 50f;

    private float rotationSpeed;

    private Vector3 tempMovement;
    private float z_Rotation;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if(Random.Range(0,2)>0)
        {
            speedX *= -1f;
        }

        if (Random.Range(0, 2) > 0)
        {
            rotationSpeed *= -1f;
        }

        if (Random.Range(0, 2) > 0)
        {
            moveOnX = true;
        }
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();

        RotateMeteor();
    }

    void HandleMovementX()
    {
        if (!moveOnX)
            return;

        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;

    }

    void HandleMovementY()
    {
        if (!moveOnY)
            return;

        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    void RotateMeteor()
    {
        z_Rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(z_Rotation, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.METEOR_TAG))
        {
            speedX *= -1f;
            collision.GetComponent<EnemyHealth>().TakeDamage(Random.Range(13f, 33f), 0f);
            gameObject.GetComponent<EnemyHealth>().TakeDamage(Random.Range(13f, 33f), 0f);
        }
    }

}
