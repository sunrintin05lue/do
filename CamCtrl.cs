using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    public GameObject PC;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - PC.transform.position;

    }
    void LateUpdate()
    {
        transform.position = new Vector3(PC.transform.position.x + offset.x, 2.2f, -10);
    }
}



