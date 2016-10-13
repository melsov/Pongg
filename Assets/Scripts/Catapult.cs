using UnityEngine;
using System.Collections;

public class Catapult : MonoBehaviour {

    public Sandwich originalSandwich;
    private float okToLaunchTimeSeconds;
    public float launchDownTimeSeconds = .5f;

	void Start () {
	
	}
	
	void FixedUpdate () {

        if (okToLaunchTimeSeconds < Time.fixedTime) {
            if (Input.GetKey(KeyCode.Space)) {
                okToLaunchTimeSeconds = Time.fixedTime + launchDownTimeSeconds;
                Sandwich sandwich = makeASandwich();
                sandwich.launch();
            }
        }
	}

    private Sandwich makeASandwich() {
        Sandwich sandwich = Instantiate<Sandwich>(originalSandwich);
        sandwich.GetComponent<Rigidbody>().position = transform.position;
        return sandwich;
    }
}
