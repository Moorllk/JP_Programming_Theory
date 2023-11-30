using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
