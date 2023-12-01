using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal // INHERITANCE
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; } // ENCAPSULATION
    protected override float RotationSpeed { get => m_RotationSpeed; set => m_RotationSpeed = value; } // ENCAPSULATION

    [SerializeField] private float m_MovementSpeed; // ENCAPSULATION
    [SerializeField] private float m_RotationSpeed; // ENCAPSULATION

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Eat();
        }
    }

    protected override void Move() // POLYMORPHISM
    {
        float speedBoost = 6f;
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        movement *= Input.GetKey(KeyCode.LeftShift) ? speedBoost : MovementSpeed;

        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(-verticalMovement, 0.0f, horizontalMovement));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
        }

        transform.Translate(movement * Time.deltaTime, Space.World);
    }
}