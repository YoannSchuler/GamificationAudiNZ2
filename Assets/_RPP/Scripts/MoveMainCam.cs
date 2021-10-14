using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMainCam : MonoBehaviour
{
    public Transform camTransform, camDestination;
    public float camSpeed = 1.5f, maxSpeed = 5f, maxDelta = 0.5f;
    public bool isAccelerating;

    void Start()
    {
        camTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        camTransform.position = Vector3.MoveTowards(camTransform.position, camDestination.position, camSpeed*Time.deltaTime);

        if (isAccelerating && camSpeed <= maxSpeed)
        {
            camSpeed = Mathf.MoveTowards(camSpeed, maxSpeed, maxDelta * Time.deltaTime);
        }

        if(!isAccelerating && camSpeed >= 0)
        {
            camSpeed = Mathf.MoveTowards(camSpeed, 0f, maxDelta * Time.deltaTime);
        }
    }
}
