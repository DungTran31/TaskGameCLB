using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset; // xác định khoảng cách giữa camera và đối tượng target.
    [SerializeField] private float damping; // mức độ làm mềm của việc theo dõi

    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }

    /*
    public Transform target;
    public float followSpeed = 5f;
    public Vector3 offset;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // Tính toán vị trí mới cho camera
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Đặt vị trí mới cho camera
        transform.position = smoothedPosition;
    }
     */
}
