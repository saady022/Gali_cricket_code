using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FielderController : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private Rigidbody _rb;
    public float fielderSpeed = 10;

    public void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _rb.position = Vector3.MoveTowards(transform.position, other.transform.position, fielderSpeed * Time.deltaTime);
        }
    }
        
}
