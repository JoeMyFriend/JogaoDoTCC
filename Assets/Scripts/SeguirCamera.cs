using UnityEngine;
using System.Collections;

public class SeguirCamera : MonoBehaviour {

	private Transform mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 novaPosicao = new Vector3 (mainCamera.position.x, mainCamera.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.time);
	}
}
