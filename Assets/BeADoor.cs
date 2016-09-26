using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeADoor : MonoBehaviour {

    public Transform openSprite;
    public Transform closedSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	public void getClicked() {
        if(closedSprite.gameObject.activeSelf) {
            closedSprite.gameObject.SetActive(false);
            openSprite.gameObject.SetActive(true);
        } else {
            print("go next scene");
            SceneManager.LoadScene("Inside");
        }
    }
    
}
