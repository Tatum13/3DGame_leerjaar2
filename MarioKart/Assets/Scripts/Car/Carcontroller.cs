using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    /// <summary>
    /// Hiermee kan je gas geven, achter uit rijden en sturen.
    /// Ook laat ik de gravity groter zijn als je in de lucht bent.
    /// En de wielen draaien als je vertical input doet.
    /// </summary>

    public Rigidbody RB;

    [Header("CAR STATS")]
    public float forwardAccel = 2f;
    public float reverseAccel = 1f;
    public float maxSpeed = 10f;
    public float turnStrenght = 90f;
    public float gravityForce = 10f;
    private float dragOnGround = 3f;

    private float speedInput, turnInput;

    [Header("BOOLS")]
    private bool grounded;

    [Header("RAY")]
    public LayerMask wahtIsGround;
    public float gourndRayLength = .5f;
    public Transform groundRayPoint;

    [Header("WHEELS STUFF")]
    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public float maxWheelTrun = 40;

    void Start()
    {
        RB.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0;
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 25f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 25f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if(grounded)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTrun) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTrun, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = RB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, gourndRayLength, wahtIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            RB.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                RB.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            RB.drag = 0.1f;
            RB.AddForce(Vector3.up * -gravityForce * 5f);
        }
    }
}
