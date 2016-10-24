using UnityEngine;
using System.Collections;

public class HoleBeacon : MonoBehaviour {

    private Renderer ren;
    public Color scoreColor = Color.green;

    void Start () {
        ren = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void acknowledge() {
        ren.material.color = scoreColor;
    }

    public void OnTriggerEnter(Collider other) {
        print("i found a " + other.name);
    }
}
