using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float mainThrust;
    [SerializeField] private float rotationSpeed;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust *Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
          
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationThrust(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationThrust(-rotationSpeed);
        }
    }

    void RotationThrust(float rotationSpeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
