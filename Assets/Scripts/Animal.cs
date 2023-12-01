using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected virtual float MovementSpeed { get; set; }
    protected virtual float RotationSpeed { get; set; }
    protected virtual float Satiety { get; set; }

    protected Vector3 movement;
    private Collider food;

    protected virtual void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(-verticalMovement, 0.0f, horizontalMovement));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
        }

        transform.Translate(movement * MovementSpeed * Time.deltaTime, Space.World);
    }

    protected void Eat()
    {
        if (food != null)
        {
            Debug.Log("Feeding");
            food.gameObject.SetActive(false);
            Satiety++;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Can Eat");
            food = other;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Can't Eat");
            food = null;
        }
    }
}