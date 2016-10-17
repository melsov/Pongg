using UnityEngine;
using System.Collections;
using System;

public class LookCam : MonoBehaviour {

    public Transform target;
    private Vector3 offset;

	void Start () {
        setOffset();
	}

    private void setOffset() {
        offset = target.position - transform.position;
    }

    public void goToTarget() {
        if (target == null) {
            throw new System.Exception("Hey! No target for look cam to go to");
        }

        transform.position = target.position + offset;
        
    }
}
