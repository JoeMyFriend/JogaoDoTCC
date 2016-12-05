using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VoltaMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Joystick1Button9)){
			SceneManager.LoadScene(0);
		}

	}
}
