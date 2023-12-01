using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected virtual float MovementSpeed { get; set; }
    protected virtual float RotationSpeed { get; set; }
    protected virtual float Satiety {  get; set; }

    protected Vector3 movement;
    private Collider food;
    private bool canEat = false;

    protected virtual void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        Debug.Log(movement);

        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(-verticalMovement, 0.0f, horizontalMovement));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
        }

        transform.Translate(movement * MovementSpeed * Time.deltaTime, Space.World);
    }

    protected void Eat()
    {
        if(canEat && Input.GetKeyDown(KeyCode.F) && food != null)
        {
            food.gameObject.SetActive(false);
            Satiety++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("Can Eat");
            food = collision.gameObject.GetComponent<Collider>();
            canEat = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("Can't Eat");
            food = null;
            canEat = false;
        }
    }
}
