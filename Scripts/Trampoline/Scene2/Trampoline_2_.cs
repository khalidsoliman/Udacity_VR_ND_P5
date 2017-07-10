using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_2_ : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(-3, 5, 2, ForceMode.Impulse);
            Debug.Log("The Ball is forced");
        }
        
    }
}
