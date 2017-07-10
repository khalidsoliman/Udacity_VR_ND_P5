using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_1_Script : MonoBehaviour {
    public SteamVR_TrackedObject leftcontroller ;
    public SteamVR_Controller.Device leftdevice;

    public List<Button> allButtons ;
    public int i = 0;
    public static bool check = true ;

    // Use this for initialization
    void Start () {
        //foreach (Transform child in transform)
        //{
        //    allButtons.Add(child.gameObject.GetComponent<Button>());
        //}
        leftcontroller = GetComponent<SteamVR_TrackedObject>();
        
    }
	
	// Update is called once per frame
	void Update () {
        leftdevice = SteamVR_Controller.Input((int)leftcontroller.index);


        if (leftdevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && check)
        {
            if (i < allButtons.Count)
            {
                if (i > 0)
                {
                    allButtons[i - 1].gameObject.SetActive(false);

                }
                allButtons[i].gameObject.SetActive(true);
                Debug.Log(i + "before i++");
                i++;
                Debug.Log(i + "after i++");
                if (i == allButtons.Count)
                {
                    check = false;
                    i = 0;
                    Debug.Log(i + "if ");
                    //allButtons[5].gameObject.SetActive(false);
                }
                Debug.Log(allButtons.Count - 1 + "allButtons.Count - 1");
                //allButtons[i].gameObject.SetActive(false);

            }
        }
        if (leftdevice.GetTouchDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (i == 5|| !check)
            {
                SteamVR_LoadLevel.Begin("Level-1-");
            }
            check = true;
            allButtons[5].gameObject.SetActive(false);
            
           
        }

        //if (i < 0)
        //{
        //    allButtons[i].gameObject.SetActive(false);
        //    i++;
        //    if (i > allButtons.Count - 1)
        //    {
        //        i = 0;
        //    }
        //    allButtons[i].gameObject.SetActive(true);
        //}

    }
}
