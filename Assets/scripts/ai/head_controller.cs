using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_controller : MonoBehaviour
{
    public Transform playerTransform;
    public Transform headBoneTransform; // Assign the bone representing the head in the inspector.
    public float maxRotationAngle = 60f;
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        if (headBoneTransform != null)
        {
            // Rotate the head bone to the left constantly.
            Quaternion rotation = Quaternion.Euler(0f, -rotationSpeed * Time.deltaTime, 0f);
            headBoneTransform.rotation *= rotation;
        }
    }
}
