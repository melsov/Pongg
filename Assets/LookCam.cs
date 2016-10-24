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

    private void setOffset() {
        offset = transform.position - target.position;
    }

    public void goToTarget() {
        if (target == null) {
            throw new System.Exception("Hey! No target for look cam to go to");
        }

        transform.position = target.position + offset;

    }
}
