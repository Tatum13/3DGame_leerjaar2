using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    public Rigidbody RB;

    public float forwardAccel = 2f, reverseAccel = 1f, maxSpeed = 10f, trunStrenght = 90f;

    private float speedInput, turnInput;

    void Start()
    {
        RB.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0;
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 50f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 50f;
        }

        transform.position = RB.transform.position;
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(speedInput) > 0)
        {
            RB.AddForce(transform.forward * speedInput);
        }
    }
}
