using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; }
    protected override float RotationSpeed { get => m_RotationSpeed; set => m_RotationSpeed = value; }

    [SerializeField] private Transform holeExit;
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
        transform.position = canClimb ? holeExit.position : transform.position;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        canClimb = other.gameObject.CompareTag("HoleEnter") ? true : false;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerEnter(other);
        canClimb = other.gameObject.CompareTag("HoleEnter") ? false : true;
    }
}
