using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private float cameraHeight = 10f;


    private void LateUpdate()
    {
        Vector3 desiredPosition = 
            new Vector3(
                target.position.x, 
                target.position.y + cameraHeight, 
                target.position.z);

        Vector3 smoothedPosition = 
            Vector3.Lerp(
                transform.position, 
                desiredPosition, 
                smoothSpeed);

        transform.SetPositionAndRotation(
            smoothedPosition, 
            Quaternion.Euler(90f, 0f, 0f));
    }
}
