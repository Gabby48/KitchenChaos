using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraBackwards,
    }

    [SerializeField] private Mode mode;

    // Update is called once per frame
    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);

                break;
            case Mode.LookAtInverted:
                Vector3 Cameradir = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + Cameradir);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraBackwards:
                transform.forward = -Camera.main.transform.forward;
                break;

        }
    }


}
