using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpecific : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            
            col.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 2, ForceMode.Impulse);
            Debug.Log("The Ball is forced");
        }

    }
}
