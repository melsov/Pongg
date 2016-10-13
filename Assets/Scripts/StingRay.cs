using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class StingRay : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float bobSpeed = 1f;

    [SerializeField]
    private float bobHeight = 1f;
    private Vector3 startPos;

    public UnityAction notifySandwich;

	void Start () {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
	}

	void FixedUpdate () {
        Vector3 pos = rb.position;
        pos.y = startPos.y + bobHeight * Mathf.Sin(Mathf.PI * bobSpeed * Time.fixedTime);
        rb.MovePosition(pos);
    }

    public void gotASandwich() {
        print("i got a sandwich");
        bobHeight += 3;
    }
}
