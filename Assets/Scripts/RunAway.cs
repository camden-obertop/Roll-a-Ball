using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public float speed;
    
    private Rigidbody _rb;
    private Vector3 _movement = new Vector3(0, 0, 0);

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Vision Radius"))
        {
            _movement = transform.position - other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vision Radius"))
        {
            _movement = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_movement * speed);
    }
}
