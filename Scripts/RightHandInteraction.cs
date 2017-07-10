using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInteraction : MonoBehaviour {
    private SteamVR_TrackedObject controller;
    public SteamVR_Controller.Device device;

  

    public float throwForce = 1.5f;
    public static bool holdingBall = false;

    public Vector3 ballPosition;

    //Swipe
    private float swipeSum;
    private float touchLast;
    private float touchCurrent;
    private float distance;
    private bool hasSwipedBackwards;
    private bool hasSwipedForwards;
    public ObjectMenuManager objectMenuManager;





    // Use this for initialization
    void Start () {

        controller = GetComponent<SteamVR_TrackedObject>();
       
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)controller.index);
        
        

            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //SteamVR_LoadLevel.Begin("Scene2");
                touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;
            }

            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;
                distance = touchCurrent - touchLast;
                touchLast = touchCurrent;
                swipeSum += distance;
                if (!hasSwipedForwards)
                {
                    if (swipeSum > .5f)
                    {
                        swipeSum = 0;
                        SwipeUp();
                        hasSwipedForwards = true;
                        hasSwipedBackwards = false;
                    }
                }

                if (!hasSwipedBackwards)
                {
                    if (swipeSum < -.5f)
                    {
                        swipeSum = 0;
                        SwipeDown();
                        hasSwipedBackwards = true;
                        hasSwipedForwards = false;
                    }
                }

            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                swipeSum = 0;
                touchCurrent = 0;
                touchLast = 0;
                hasSwipedBackwards = false;
                hasSwipedForwards = false;
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                objectMenuManager.SpawnCurrentObject();
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                objectMenuManager.DestroyObject();
            }
        

    }

    //void SpawnObject()
    //{
        
    //}

    void SwipeUp()
    {
        objectMenuManager.Menuforwards();
        Debug.Log("Swiped Up");
    }
    void SwipeDown()
    {
        objectMenuManager.Menubackwards();
        Debug.Log("Swiped Down");
    }

    private void OnTriggerStay(Collider col)
    {
        
            if (col.gameObject.CompareTag("Ball"))
            {

                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ThrowBall(col);
                holdingBall = false;
            }
                else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    GrabBall(col);
                holdingBall = true;
                ballPosition = col.gameObject.transform.position;
            }
            //Debug.Log("Collision occurred_Ball");
        }
        if (col.gameObject.CompareTag("SpawnableBall"))
        {

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ThrowBall(col);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabBall(col);
            }
            //Debug.Log("Collision occurred_Ball");
        }


        if (col.gameObject.CompareTag("Object") || col.gameObject.CompareTag("Goal") || col.gameObject.CompareTag("Trampoline"))
            {
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                { 
                    ThrowObject(col);
                }
                else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    GrabObject(col);
                }
            }
            
        
        
    }
    void GrabBall(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(2000);
        //Debug.Log("You are touching down the trigger on the ball");
    }
    void ThrowBall(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.velocity = device.velocity * throwForce;
        rigidbody.angularVelocity = device.angularVelocity;
        //Debug.Log("You have released the trigger");
    }
    void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(500);
        Debug.Log("Holding the Object");
    }
    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.velocity = device.velocity * 0f ;
        rigidbody.angularVelocity = device.angularVelocity * 0f ;
        Debug.Log("Your Object Spawns");
    }
}
