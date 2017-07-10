using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_2_2 : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            col.gameObject.GetComponent<Rigidbody>().AddForce(-3, 5, 0, ForceMode.Impulse);
            Debug.Log("The Ball is forced");
        }
        
    }
}
