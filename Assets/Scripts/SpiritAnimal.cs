using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAnimal : Animal
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; }

    [SerializeField] private float m_MovementSpeed;
    private MeshRenderer meshRenderer;
    private bool exitAvailable = false;
    public Animal currentAnimal;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!exitAvailable)
        {
            Move();
        }
        else
        {
            transform.position = currentAnimal.gameObject.transform.position + new Vector3(0f, 1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentAnimal != null)
            {
                TakingControl();
            }
        }
    }

    private void LateUpdate()
    {
        if (!exitAvailable)
        {
            Levitation();
        }
    }

    private void TakingControl()
    {
        string text = !exitAvailable ? "Exit from " + currentAnimal.GetType().Name : "Switching to " + currentAnimal.GetType().Name;
        currentAnimal.enabled = !exitAvailable ? true : false;
        meshRenderer.enabled = !exitAvailable ? false : true;
        exitAvailable = !exitAvailable? true : false;

        Debug.Log(text);
    }

    private void Levitation()
    {
        float levitationSpeed = 0.09f;
        float topY = 0.6f;
        float downY = 0.4f;
        float newY = Mathf.PingPong(Time.time * levitationSpeed, topY - downY) + downY;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Animal animal = other.GetComponent<Animal>();
            currentAnimal = animal != null ? animal : null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentAnimal = other.gameObject.CompareTag("Animal") && !exitAvailable ? null : currentAnimal;
    }
}
