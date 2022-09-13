using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : Interactable
{
    //[SerializeField] private Rigidbody doorRigid;
    [SerializeField] private HingeJoint joint;
    private Camera fpsCamera;

    private Vector3 mOffset;
    private float mZCoord;

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

        //RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.Log(ray);

        var v = Random.Range(-90f, 90f);

        joint.transform.localRotation = Quaternion.Euler(0, v, 0);
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
