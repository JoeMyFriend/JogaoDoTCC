using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public GameObject cameraObject;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cameraObject.transform.position += new Vector3 (0.0f, speed * Time.deltaTime, 0.0f);

		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene (0);
		}
	}
	void OnTriggerEnter2D(){
		SceneManager.LoadScene (0);
	}
}
