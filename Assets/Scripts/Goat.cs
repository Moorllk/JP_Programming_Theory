using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : Animal // INHERITANCE
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; } // ENCAPSULATION
    protected override float RotationSpeed { get => m_RotationSpeed; set => m_RotationSpeed = value; } // ENCAPSULATION

    private Rigidbody rb;
    [SerializeField] private float m_MovementSpeed; // ENCAPSULATION
    [SerializeField] private float m_RotationSpeed; // ENCAPSULATION
    [SerializeField] private float jumpForce;
    private bool isGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Eat();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0 && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = collision.gameObject.CompareTag("Ground") ? true : false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = collision.gameObject.CompareTag("Ground") ? false : true;
    }
}
