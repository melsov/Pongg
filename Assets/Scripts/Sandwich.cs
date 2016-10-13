using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Sandwich : MonoBehaviour {

    public Vector3 direction = new Vector3(1f, 1f, 0f);
    public float force = 500f;
    private Rigidbody rb;

    public delegate void HitStringray();
    public HitStringray hitStingray;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        launch();
	}
	
	void Update () {
	
	}

    public void launch() {
        rb.AddForce(direction.normalized * force);
        rb.AddTorque(new Vector3(0f, 0f, 100f));
    }

    public void OnTriggerEnter(Collider other) {
        print("enter");
        hitStingray.Invoke();
    }
}
