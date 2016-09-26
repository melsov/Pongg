using UnityEngine;
using System.Collections;

public class BeAHouse : MonoBehaviour {

    public ParticleSystem smoke;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            toggleSmoke();
        }
    }

    public void toggleSmoke() {
        smoke.gameObject.SetActive(!smoke.gameObject.activeSelf);
    }
}
