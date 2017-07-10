using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Body_4_ : MonoBehaviour {
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0 , 0 ,0) ;
            col.gameObject.GetComponent<Rigidbody>().AddForce(2, 8, 0, ForceMode.Impulse);
            //Debug.Log("The Ball is forced");
        }

    }
}
