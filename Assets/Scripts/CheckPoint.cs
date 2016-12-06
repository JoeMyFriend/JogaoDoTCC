using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public Animator anime;
	public int proximaFase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D colisor){
		if (colisor.gameObject.tag == "Player") {

			PlayerPrefs.SetInt ("faseSalva", proximaFase);

			anime.SetTrigger ("relou");


			//Debug.Log (PlayerPrefs.HasKey("faseSalva"));

		}
	}

}
