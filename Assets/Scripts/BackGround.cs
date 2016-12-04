using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

	private Transform cameraVar;


	// Use this for initialization
	void Start () {
	
		cameraVar = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 novaPosicao = new Vector3 (cameraVar.position.x, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.time);
	}
}
