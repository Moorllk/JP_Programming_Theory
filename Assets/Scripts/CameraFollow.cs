using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; }
    public GameObject target;
    private Vector3 offset = new Vector3(0f, 4f, -2f);

    private void Awake()
    {
        Instance = this;
    }

    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
