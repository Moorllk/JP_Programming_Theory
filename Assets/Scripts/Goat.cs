using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : Animal
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; }
    protected override float RotationSpeed { get => m_RotationSpeed; set => m_RotationSpeed = value; }

    private Rigidbody m_Rigidbody;
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_RotationSpeed;
    [SerializeField] private float m_JumpForce;
    private bool isGround;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
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
        m_Rigidbody.AddForce(Vector3.up * m_JumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
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
