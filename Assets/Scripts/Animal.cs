using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected virtual float MovementSpeed { get; set; }
    protected virtual float Satiety {  get; set; }

    private Collider food;
    private bool canEat = false;

    protected void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalMovement, 0.0f, -horizontalMovement);

        transform.Translate(movement * MovementSpeed * Time.deltaTime);
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
