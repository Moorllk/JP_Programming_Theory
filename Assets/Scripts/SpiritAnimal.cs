using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAnimal : Animal
{
    protected override float MovementSpeed { get => m_MovementSpeed; set => m_MovementSpeed = value; }

    [SerializeField] private float m_MovementSpeed;
    private MeshRenderer meshRenderer;
    public Animal currentAnimal;
    private bool up = true;
    private bool movedIn = false;
    private bool exitAvailable = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!movedIn)
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
        if (!movedIn)
        {
            Levitation();
        }
    }

    private void TakingControl()
    {
        if (exitAvailable)
        {
            Debug.Log("Exit from " + currentAnimal.GetType().Name);
            currentAnimal.enabled = false;
            meshRenderer.enabled = true;
            movedIn = false;
            exitAvailable = false;
            currentAnimal = null;
        }
        else
        {
            Debug.Log("Switching to " + currentAnimal.GetType().Name);
            currentAnimal.enabled = true;
            meshRenderer.enabled = false;
            movedIn = true;
            exitAvailable = true;
        }
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
        else
        {
            transform.Translate(Vector3.down * levitationSpeed * Time.deltaTime);
            if (transform.position.y < downY)
            {
                up = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Animal animal = other.GetComponent<Animal>();
            if (animal != null)
            {
                currentAnimal = animal;
            }
        }
    }
}
