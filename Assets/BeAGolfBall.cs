using UnityEngine;
using System.Collections;
using System;

public class BeAGolfBall : MonoBehaviour {

    public Transform tee;
    private Rigidbody rb;
    public HoleBeacon hole;

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

        StartCoroutine(trackTrajectory()); //start a coroutine
    }

/*
 * Coroutine Example:
 * Coroutine, in Unity, are like mini Update functions. Mini because they start when you ask them to
 * and (usually) end at some point.
 * They are useful when you want to track the progress of something
 * where the something will take an unknown amount of time.
 * 
 * In this case, we want to do something when the ball stops moving:
 *   
 * Wait for a short time to make sure that the ball started moving
 * While the ball still has some velocity, wait for a short time
 * Now that the ball is mostly not moving, tell the camera to re-align to the ball  
 *  */
    private IEnumerator trackTrajectory() 
    {
        yield return new WaitForSeconds(.1f);
        while(rb.velocity.sqrMagnitude > 1.0) 
        {
            yield return new WaitForSeconds(.1f);
        }
        //the ball more or less stopped
        //make it fully stop
        rb.velocity = Vector3.zero;
        LookCam lc = Camera.main.GetComponent<LookCam>();
        lc.goToTarget();
    }

    public void OnTriggerEnter(Collider other) {
        HoleBeacon hb = other.GetComponent<HoleBeacon>();

        if (hb) {
            hb.acknowledge();
        }
        
    }
}
