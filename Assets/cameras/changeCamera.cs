using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    private CinemachineVirtualCamera follow;
    private CinemachineVirtualCamera lockin;


    private bool isCamera1Active = true;

    // Update is called once per frame
    void Update()
    {
        // Check for the Q key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Toggle between cameras
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        // Enable/disable the currently active camera
        camera1.SetActive(!isCamera1Active);
        camera2.SetActive(isCamera1Active);

 

        // Update the flag for the next toggle
        isCamera1Active = !isCamera1Active;
    }
}
