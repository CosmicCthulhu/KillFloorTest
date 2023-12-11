using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour

{
    private Rigidbody rb;
    private Transform cameraTransform;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 100.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0.0f, vertical);

        // Move the character
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the character
        float angle = Input.GetAxis("Turn");
        transform.Rotate(new Vector3(0.0f, angle * rotateSpeed * Time.deltaTime, 0.0f));

        // Look towards the camera direction
        transform.LookAt(cameraTransform.position);
    }
}