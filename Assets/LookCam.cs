using UnityEngine;
using System.Collections;
using System;

public class LookCam : MonoBehaviour {

    public Transform target;
    private Vector3 offset;
    public Vector3 lookOffset = new Vector3(0f, 4f, 0f);

	void Start () {
        setOffset();
	}

    private BeAGolfBall getGolfBall() {
        return target.GetComponent<BeAGolfBall>();
    }

    private HoleBeacon getHoleBeacon() {
        return getGolfBall().hole;
    }

    private void setOffset() {
        offset = transform.position - target.position;
    }

    private Vector3 holeToBall() {
        return getGolfBall().transform.position - getHoleBeacon().transform.position;
    }

    public void goToTarget() {
        if (target == null) {
            throw new System.Exception("Hey! No target for look cam to go to");
        }

        Vector3 off = offset;
        /*
         * TODO: align off with holeToBall direction
         */
        transform.position = target.position + off;
    }

    public void Update() {
        goToTarget();
        lookSomewhere();
    }

    private void lookSomewhere() {
        Vector3 hole = getHoleBeacon().transform.position;
        Vector3 lk = hole - transform.position;
        Quaternion look = Quaternion.LookRotation(lk);
        transform.rotation = look;
    }
}
