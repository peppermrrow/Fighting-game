using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalreflection : MonoBehaviour
{
    [SerializeField] private Transform playercamera; // Reference to the camera

    // Update is called once per frame
    void Update()
    {
        // Get the current y-axis rotation of the camera and apply it to the object's rotation
        Quaternion currentRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, playercamera.rotation.eulerAngles.y, currentRotation.eulerAngles.z);
    }
}
