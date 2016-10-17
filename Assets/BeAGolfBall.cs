using UnityEngine;
using System.Collections;

public class BeAGolfBall : MonoBehaviour {

    public Transform tee;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.MovePosition(tee.position);
	}
	
	void Update () {
	
	}

    public void getHit(Vector3 force) {
        /*
         * This is a little different from the previous example:
         * We are not normalizing the force here; just blindly
         * accepting the force vector that we are given
         */
        print("got hit: " + force.ToString());
        rb.AddForce(force);
    }
}
