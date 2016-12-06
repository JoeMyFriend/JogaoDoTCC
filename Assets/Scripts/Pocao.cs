using UnityEngine;
using System.Collections;

public class Pocao : MonoBehaviour {

	public int life;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.tag == "Player"){

			var vida = colisor.gameObject.transform.GetComponent<Vida> ();

			vida.recuperaVida (life);
			Destroy (gameObject);
		}

	}

}
