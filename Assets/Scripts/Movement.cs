using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rigidbody1;
    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotation = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Going up");
            rigidbody1.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate Left");
            ApplyRotation(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate Right");
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        rigidbody1.freezeRotation = true;
        rigidbody1.transform.Rotate(direction * Time.deltaTime * rotation);
        rigidbody1.freezeRotation = false;
    }
}
