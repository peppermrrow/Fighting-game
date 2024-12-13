using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    public static bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            rb.velocity = new Vector3(0, 6, 0);
        }
    }
}
