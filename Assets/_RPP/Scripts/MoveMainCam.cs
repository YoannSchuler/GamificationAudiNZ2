using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMainCam : MonoBehaviour
{
    public Transform camTransform, camDestination;
    public Text speedText;
    public float[] futureSpeedValues;
    int currentSpeedValue = 0;
    public float[] futureDeltaValues;
    int currentDeltaValue = 0;
    public float camSpeed = 1.5f, maxSpeed = 5f, maxDelta = 0.5f;
    public bool isAccelerating, isChangingSpeed = false;   

    void Start()
    {
        camTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        speedText.text = "" + ((short)camSpeed*2); 
        camTransform.position = Vector3.MoveTowards(camTransform.position, camDestination.position, camSpeed*Time.deltaTime);

        if (isAccelerating && camSpeed <= maxSpeed)
        {
            camSpeed = Mathf.MoveTowards(camSpeed, maxSpeed, maxDelta * Time.deltaTime);
        }

        if(!isAccelerating && camSpeed >= 0)
        {
            camSpeed = Mathf.MoveTowards(camSpeed, 0f, maxDelta * Time.deltaTime);
        }

        if(isChangingSpeed && camSpeed != maxSpeed)
        {
            camSpeed = Mathf.MoveTowards(camSpeed, maxSpeed, maxDelta * Time.deltaTime);
        }
        else
        {
            isChangingSpeed = false;
        }
    }

    [SerializeField] void StartAcceleration()
    {
        isAccelerating = true;
    }

    [SerializeField] void StopAcceleration()
    {
        isAccelerating = false;
    }

    public void ChangeCurrentSpeed()
    {
        isChangingSpeed = true;
    }

    public void ChangeDelta()
    {
        maxDelta = futureDeltaValues [currentDeltaValue];
        currentDeltaValue ++;
    }

    public void ChangeMaxSpeed()
    {
        maxSpeed = futureSpeedValues[currentSpeedValue];
        currentSpeedValue++;
    }
}
