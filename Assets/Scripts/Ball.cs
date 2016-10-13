using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        Vector3 startDirection = Quaternion.Euler(0f, 0f, Random.Range(-65f, 65f)) * Vector3.right * 4f;
        if (Random.value > .5f) {
            startDirection *= -1f;
        }
        GetComponent<Rigidbody>().AddForce(startDirection, ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	public void Update () {
	
	}
}
