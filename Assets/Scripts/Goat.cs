using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : Animal
{
    [SerializeField] private float m_movementSpeed;
    protected override float MovementSpeed { get => m_movementSpeed; set => m_movementSpeed = value; }

    void Update()
    {
        Move();
    }

    private void Jump()
    {

    }
}
