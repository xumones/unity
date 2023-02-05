using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]float thrustValue = 1000f;
    [SerializeField]float rotateValue = 100f;
    Rigidbody rgbody;


    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFly();
        ProcessRotate();
    }

    void ProcessFly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rgbody.AddRelativeForce(Vector3.up * thrustValue * Time.deltaTime);
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateValue);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateValue);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rgbody.freezeRotation = true; //freezing for stop unity physic
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rgbody.freezeRotation = false; //unfreezing for start unity physic over agian
    }
}
