using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_3_ : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(4, 5, 6, ForceMode.Impulse);
            Debug.Log("The Ball is forced");
        }
        
    }
}
