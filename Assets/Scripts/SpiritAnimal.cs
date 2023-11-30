using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAnimal : Animal
{
    protected override float MovementSpeed { get => m_movementSpeed; set => m_movementSpeed = value; }

    [SerializeField] private float m_movementSpeed;
    private bool up = true;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        Levitation();
    }

    private void Levitation()
    {
        float levitationSpeed = 0.09f;
        float topY = 0.6f;
        float downY = 0.4f;

        if (up)
        {
            transform.Translate(Vector3.up * levitationSpeed * Time.deltaTime);
            if (transform.position.y > topY)
            {
                up = false;
            }
        }

        if (!up)
        {
            transform.Translate(Vector3.down * levitationSpeed * Time.deltaTime);
            if (transform.position.y < downY)
            {
                up = true;
            }
        }
    }
}
