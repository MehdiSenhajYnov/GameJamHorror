using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AnimationCurve openDoorSpeed;
    public float curTimer = 0;
    public float openTime = 1;
    
    public bool isInteracting = false;
    public float targetTime = -1;
    
    public float openDegree = 90;
    public float closeDegree = 0;
    
    public DoorState doorState = DoorState.Close;

    public bool testInteract = false;
    
    public float curDegree = 0;

    public void Interact()
    {
        if (isInteracting)
        {
            return;
        }
        isInteracting = true;
        if (doorState == DoorState.Open)
        {
            targetTime = 0;
        }
        else
        {
            targetTime = openTime;
        }
    }
    
    public float t;
    // Update is called once per frame
    void Update()
    {
        if (testInteract)
        {
            testInteract = false;
            Interact();
        }
        
        if (isInteracting)
        {
            if (nearlyEqual(targetTime,openTime,0.00001f))
            {
                Debug.Log("Opening");
                curTimer += Time.deltaTime;
                t = curTimer / openTime;
                curDegree = Mathf.Lerp(closeDegree,openDegree,openDoorSpeed.Evaluate(t));
                transform.localEulerAngles = new Vector3(0,curDegree,0);
                if (curTimer >= openTime)
                {
                    doorState = DoorState.Open;
                    isInteracting = false;
                    curTimer = 0;
                }
            }
            else
            {
                Debug.Log("Closing");
                curTimer += Time.deltaTime;
                t = 1-(curTimer / openTime);
                curDegree = Mathf.Lerp(closeDegree, openDegree,openDoorSpeed.Evaluate(t));
                transform.localEulerAngles = new Vector3(0,curDegree,0);
                if (curTimer >= openTime)
                {
                    doorState = DoorState.Close;
                    isInteracting = false;
                    curTimer = 0;
                }
            }
        }
    }
    
    public bool nearlyEqual(float a, float b, float epsilon) {
        return Mathf.Abs(a - b) < epsilon;
    }
}

public enum DoorState
{
    Open,
    Close,
}
