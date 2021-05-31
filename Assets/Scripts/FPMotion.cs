using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMotion : MonoBehaviour
{
    public ConstantForce gravity;

    public GameObject playerCamera; // need to be connected to real object in Unity
    private CharacterController controller;
    private float speed = 5f;
    private float rx = 0f, ry;
    private float angularSpeed = 5f;


    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();// get player controller

    }


    // Update is called once per frame
    void Update()
    {

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);

        float dx, dz, dy;
        //mouse to rotate player
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        //use Clampf to limit the sight angles


        // runs on player
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;

        transform.localEulerAngles = new Vector3(0, ry, 0); //sets new orientation of player
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0); //sets new orientation of camera
                                                                         // keyboard
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Horizontal means 'A' or 'D'
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Vertical means 'W' or 'S'
        dy = transform.position.y;

        Vector3 motion = new Vector3(dx, -1, dz);// in local coordinates
        motion = transform.TransformDirection(motion); // in Global coordinates
        controller.Move(motion);

    }
}
