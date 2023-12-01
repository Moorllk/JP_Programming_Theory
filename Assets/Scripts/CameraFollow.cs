using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 offset = new Vector3(0f, 4f, -2f);

    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
