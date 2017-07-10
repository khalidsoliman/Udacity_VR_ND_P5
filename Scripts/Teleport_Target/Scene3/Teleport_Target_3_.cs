using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Target_3_ : MonoBehaviour {
    public GameObject Trampoline;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("The ball is teleported");
            col.gameObject.transform.position = Trampoline.transform.position + new Vector3(0, 1, 0);
        }
    }
}
