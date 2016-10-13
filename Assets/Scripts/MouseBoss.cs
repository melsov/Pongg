using UnityEngine;
using System.Collections;
using System;

public class MouseBoss : MonoBehaviour {

	void Start () {
	
	}
	
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0)) {
            findClickable();
        }
	}

    private void findClickable() {
        RaycastHit rch;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rch)) {
            Transform thing = rch.transform;
            print("i found a " + thing.name);
        }
    }
}
