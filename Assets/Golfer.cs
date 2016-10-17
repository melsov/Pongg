using UnityEngine;
using System.Collections;
using System;

public class Golfer : MonoBehaviour {

    public BeAGolfBall golfBall;
    public Collider ground;
    private LineRenderer lr;
    public float baseSwingForce = 10;
    public float baseUpwardForce = 100f;

    void Start () {
        lr = GetComponent<LineRenderer>();
	}

	void Update () {
        drawLine();
        if(Input.GetKeyDown(KeyCode.Space)) {
            swing();
        }
	}

    private void swing() {
        Vector3 aim = getMouseLocationOnGround();
        Vector3 ballToTarget = aim - golfBall.transform.position;
        ballToTarget = ballToTarget / 2.0f;
        ballToTarget += Vector3.up * ballToTarget.magnitude * baseUpwardForce;
        float force = ballToTarget.magnitude * baseSwingForce;
        Vector3 finalForce = ballToTarget.normalized * force;
        golfBall.getHit(finalForce);
    }

    private void drawLine() {
        Vector3 aim = getMouseLocationOnGround();
        drawLineFromBallTo(aim);
    }

    private void drawLineFromBallTo(Vector3 to) {
        lr.SetPosition(0, golfBall.transform.position + Vector3.up);
        lr.SetPosition(1, to);
    }

    private Vector3 getMouseLocationOnGround() {

        RaycastHit rch;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out rch, float.MaxValue, LayerMask.GetMask("Ground"))) {

            Collider hitObject = rch.collider;
            return rch.point;

        }
        return Vector3.zero;
    }
}
