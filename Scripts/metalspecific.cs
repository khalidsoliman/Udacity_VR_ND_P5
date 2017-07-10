using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalspecific : MonoBehaviour {

    public GameObject ball;

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
        if (col.gameObject.CompareTag("Ball"))
        {
            rigidbody.AddForce(0, 0, -2f, ForceMode.Impulse);
            //Debug.Log("The Ball is forced");
        }

    }
}
