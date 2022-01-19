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
    public GameObject viuals;

    [Header("CAR STATS")]
    public float forwardAccel = 2f;
    public float reverseAccel = 1f;
    public float maxSpeed = 10f;
    public float boostSpeed;
    public float turnStrenght = 90f;
    public float gravityForce = 10f;
    private float dragOnGround = 3f;

    //speedInput == current speed
    [SerializeField] private float speedInput, turnInput;

    [Header("DRIFTING")]
    [SerializeField]private float steerDirection;
    [SerializeField] private float driftTime;
    public Color drift1;
    public Color drift2;
    public Color drift3;

    private float boostTime = 0;

    public Transform boostFire;
    public Transform boostExplosion;

    [Header("BOOLS")]
    [SerializeField] private bool grounded;
    [SerializeField] private bool driftingRight;
    [SerializeField] private bool driftingLeft;
    [SerializeField] private bool isSliding;

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
        Move();
        Steering();
        Drift();
        Boost();

        //wielen draai
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

    private void Move()
    {
        //vooruit en achteruit
        speedInput = 0;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 25f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 25f;
        }
        turnInput = Input.GetAxis("Horizontal");

        //sturen
        if (grounded)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
    }
    private void Steering()
    {       
        steerDirection = Input.GetAxisRaw("Horizontal"); // -1, 0, 1

        if (driftingLeft && !driftingRight && speedInput == 50)
        {
            steerDirection = Input.GetAxisRaw("Horizontal") < 0 ? -1.5f : -0.5f;
            viuals.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -35f, 0f));
        }
        else if (!driftingLeft && driftingRight && speedInput == 50)
        {
            steerDirection = Input.GetAxisRaw("Horizontal") > 0 ? 1.5f : 0.5f;
            viuals.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 35f, 0f));
        }
        else
            viuals.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, 0f));
    }
    private void Drift()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            if(turnInput > 0)
            {
                driftingRight = true;
                driftingLeft = false;
            }
            else if (turnInput < 0)
            {
                driftingLeft = true;
                driftingRight = false;
            }
        }

        if(Input.GetButton("Jump") && grounded && speedInput > 30 && Input.GetAxis("Horizontal") != 0)
        {
            driftTime += Time.deltaTime;
            //particals/
        }

        if(Input.GetButtonUp("Jump"))
        {
            driftingRight = false;
            driftingLeft = false;
            isSliding = false;

            if (driftTime > 1.5 && driftTime < 2.5)
            {
                boostTime = 0.75f;
                Debug.Log("kleine boost");
            }
            else if (driftTime < 5)
            {
                boostTime = 1.5f;
                Debug.Log("meduim boost");
            }
            else if (driftTime >= 5)
            {
                boostTime = 2.5f;
                Debug.Log("groote boost");
            }

            //reset everything
            driftTime = 0;
            isSliding = false;

            //stop de particals ook hier/
            
        }
    }
    private void Boost()
    {
        boostTime -= Time.deltaTime;
        if(boostTime > 0)
        {
            //uitlaat vuur partical aan roepen/

            maxSpeed = boostSpeed;
            speedInput = Mathf.Lerp(speedInput, maxSpeed, 1 * Time.deltaTime);
        }
        else
        {
            //STOP uitlaat vuur partical aan roepen/

            maxSpeed = boostSpeed - 20f;
        }
    }
}
