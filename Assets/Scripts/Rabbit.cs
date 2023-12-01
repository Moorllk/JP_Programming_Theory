using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; }
    protected override float RotationSpeed { get => m_RotationSpeed; set => m_RotationSpeed = value; }

    [SerializeField] private Transform holeExit;
    private Rigidbody m_Rigidbody;
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_RotationSpeed;
    private bool canClimb = false;

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Eat();
            IntoTheHole();
        }
    }

    private void IntoTheHole()
    {
        if(canClimb)
        {
            Debug.Log("Rabbit Teleport");
            transform.position = holeExit.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HoleEnter"))
        {
            Debug.Log("Can Climb");
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HoleEnter"))
        {
            Debug.Log("Can't Climb");
            canClimb = false;
        }
    }
}
