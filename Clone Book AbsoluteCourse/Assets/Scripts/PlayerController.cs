using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 80;

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Transform playerTransform;
    private Vector3 moveDirection;  // 벡터 노말라이즈 해야된다.(대각이동)
    

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        moveDirection = Vector3.forward * v + Vector3.right * h;
        playerTransform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.Self);
        playerTransform.Rotate(Vector3.up * r * rotateSpeed * Time.deltaTime, Space.Self);
    }
}
