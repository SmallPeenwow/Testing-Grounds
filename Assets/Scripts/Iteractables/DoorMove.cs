using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://stackoverflow.com/questions/37129162/open-a-door-front-and-back-in-unity3d-similar-to-amnesia // Code for moving doors

public class DoorMove : Interactable
{
    [SerializeField] private Rigidbody doorRigid;
    [SerializeField] private HingeJoint joint;
    private float rotateSpeed = 40f;

    private bool doorState = false;
    private float yRot = 0;
    private InputManager inputManager;

    private Vector3 mOffset;
    private float mZCoord;

    public float moveSpeed = 1f;

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    //private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        //inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = 45f;
        //JointLimits jl = new JointLimits();
        //jl.min = angle;
        //jl.max = angle;
        //hingeJoint.limits = jl;
        //MoveDoor(inputManager.onFoot.Look.ReadValue<Vector2>());
        //Interact();
        //if (doorState)
        //{
        //    DoorMovement();
        //}
    }

    private void DoorMovement()
    {
        float yRot = 0.0f; // rotation around the up/y axis


        //yRot += Input.GetAxis("Mouse Y") * inputManager.GetComponent<PlayerLook>().ySensitivity * Time.deltaTime;
        Debug.Log(yRot * 1000 + " First");
        yRot = Mathf.Clamp(0, yRot, 0);
        Debug.Log(yRot);
        transform.localRotation = Quaternion.Euler(0.0f, yRot * 1000, 0.0f);
    }

    //public void MoveDoor(Vector2 input)
    //{
    //    Debug.Log("Dooor");
    //    float mouseX = input.x;

    //    joint.transform.localRotation = Quaternion.Euler(0, mouseX * Time.deltaTime, 0);
    //}

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; // Mouse position in the world

        mousePoint.y = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    protected override void Interact()
    {
        Debug.Log("yes");

       /* transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 80f, 0), rotateSpeed * Time.deltaTime)*/

        if (!doorState)
        {
            transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (doorState)
        {
            transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        }

        doorState = !doorState;


        //float speed = 2;
        //Transform camTransform = Camera.main.transform;
        //Vector3 camPosition = new Vector3(transform.position.x, camTransform.position.y, transform.position.z);
        //Vector3 direction = (transform.position - camPosition).normalized;
        //Vector3 horizontalMovement = camTransform.right * Input.GetAxis("Horizontal");
        //Vector3 movement = Vector3.ClampMagnitude(horizontalMovement, 1);
        //transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //var v = Input.mousePosition.x;

        //Vector3 position2 = transform.position;
        //position2.y -= Time.deltaTime * moveSpeed;
        //transform.position = position2;
        //Debug.Log(position2);

        ////transform.Rotate(new Vector3(0f, rotateSpeed * Time.deltaTime, 0f));

        ////doorRigid.AddTorque(new Vector3(0f, UnityEngine.Random.Range(-1f, 1f), 0f), ForceMode.Impulse);
        //transform.localRotation = Quaternion.Euler(0, position2.y, 0);
        //Debug.Log(horizontalMovement);


        //RaycastHit hit;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Debug.Log(ray);

        //var v = Random.Range(-90f, 90f);

        //joint.transform.localRotation = Quaternion.Euler(0, v, 0);

        //mPosDelta = Input.mousePosition - mPrevPos;
        ////transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
        ////var v = transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World;

        //Ray playerAim = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        //Vector3 v = Camera.main.transform.position + playerAim.direction * 3f;

        //mPrevPos = Input.mousePosition;
        //Debug.Log(mPosDelta);
        //Debug.Log(mPrevPos);
        //Debug.Log(transform.TransformDirection(Vector3.forward));

        //transform.localRotation = Quaternion.Euler(0, 5f, 0);

        //joint.transform.localRotation = Quaternion.Euler(0, 60, 0);
        ////mOffset = gameObject.transform.position - GetMouseWorldPos();

        ////mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

        //Vector3 value = GetMouseWorldPos() + mOffset;
        ////transform.position = GetMouseWorldPos() + mOffset;
        //joint.transform.localRotation = Quaternion.Euler(value);

        //float horizontal = Input.GetAxis("Horizontal");
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //doorRigid.AddForce(0, 40, 0, ForceMode.Impulse);
        //joint.transform.localRotation = Quaternion.Euler(0, 240, 0);
        //transform.localRotation = Quaternion.Euler(0, 240, 0);
        //transform.localRotation = Quaternion.Euler(Camera.main.transform.forward * 3f * Time.deltaTime);

        //doorRigid.AddForce(new Vector3(0, horizontal, 0));
        //doorRigid.AddForce(transform.forward * vertical, ForceMode.Acceleration);
        //doorRigid.AddForce(transform.right * horizontal, ForceMode.Acceleration);
    }
}
