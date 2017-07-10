using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public SteamVR_TrackedObject controller;
    public SteamVR_Controller.Device device;

    public float x;
    public float y;
    public float z;

    //Teleportation
    private LineRenderer laserLine;
    public GameObject teleportObj;
    public Vector3 teleportPlace;
    public GameObject player;
    public LayerMask laserMask;

    
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
        laserLine = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        x = teleportPlace.x;
        y = teleportPlace.y;
        z = teleportPlace.z;


        device = SteamVR_Controller.Input((int)controller.index);
        if (!RightHandInteraction.holdingBall)
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laserLine.gameObject.SetActive(true);
                teleportObj.SetActive(true);

                laserLine.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10, laserMask))
                {
                    teleportPlace = hit.point;
                    laserLine.SetPosition(1, teleportPlace);

                    teleportObj.transform.position = new Vector3(teleportPlace.x, teleportPlace.y + .5f, teleportPlace.z);
                    
                    //didTeleportWall = true;
                    //Debug.Log("The Wall");
                }
                else
                {
                    //teleportPlace = transform.position;
                    teleportPlace = new Vector3(transform.forward.x * 10 + transform.position.x, transform.forward.y * 10 + transform.position.y, transform.forward.z * 10 + transform.position.z);
                    RaycastHit GroundHit;
                    if (Physics.Raycast(teleportPlace, -Vector3.up, out GroundHit, 12, laserMask))
                    {
                        teleportPlace = new Vector3(transform.forward.x * 10 + transform.position.x, GroundHit.point.y, transform.forward.z * 10 + transform.position.z);
                        //didTeleportFloor = true;                
                    }
                    laserLine.SetPosition(1, transform.forward * 10 + transform.position);

                    teleportObj.transform.position = teleportPlace + new Vector3(0, 1, 0);
                    //Debug.Log("The Floor");
                }

            }
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {

                laserLine.gameObject.SetActive(false);
                teleportObj.SetActive(false);

                if (x <= 17f && x >= -25f && y <= 3f && z <= 17f && z >= -25f)
                {
                    player.transform.position = teleportObj.transform.position + new Vector3(1f, 0, 1f);
                }
                else
                {
                    player.transform.position = new Vector3(0, 1, 0);
                }
            }
        }
    }

}