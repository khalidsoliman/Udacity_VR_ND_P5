using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_1_ : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(-2, 2, 2, ForceMode.Impulse);
            Debug.Log("The Ball is forced");
        }
        
    }
}
