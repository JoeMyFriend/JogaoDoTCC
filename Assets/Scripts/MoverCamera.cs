using UnityEngine;
using System.Collections;

public class MoverCamera : MonoBehaviour {

	public GameObject cameraObject;
	public float speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		cameraObject.transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
	}

	void OnTriggerEnter2D(){
		speed *= -1;
	}


}
