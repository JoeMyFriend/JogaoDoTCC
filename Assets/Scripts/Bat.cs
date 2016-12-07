using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	
	void OnTriggerEnter2D(){
		SceneManager.LoadScene (0);
	}
}
