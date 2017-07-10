using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Target : MonoBehaviour {

    public ObjectMenuManager trampoline;

    //public GameObject spawnableBall;
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("SpawnableBall"))
        {
            Debug.Log("The ball is teleported");
            col.transform.position = trampoline.trampolinePosition + new Vector3(0, 1, 0);
            
        }
    }
}
