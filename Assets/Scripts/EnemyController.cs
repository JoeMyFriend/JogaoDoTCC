﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Animator anime;
	public Transform enemyTransform;
	public float speed;


	private float tempoNaDirecao;
	public float duracaoDirecao;
	public bool direcao;
	public float forcaEmpurrao;

	public bool run;

	public int dano;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

		if (direcao) {
			transform.eulerAngles = new Vector2 (0, 0);
		} else {
			transform.eulerAngles = new Vector2 (0, 180);
		}
		enemyTransform.Translate (Vector2.right * speed * Time.deltaTime);

		tempoNaDirecao += Time.deltaTime;
		run = true;

		if(tempoNaDirecao >= duracaoDirecao){
			tempoNaDirecao = 0;
			direcao = !direcao;
		}

		anime.SetBool ("run", run);
	}

	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {

			anime.SetTrigger ("atack");

			var vida = colisor.gameObject.transform.GetComponent<Vida> ();

			vida.perdeVida (dano);

			if (transform.eulerAngles.y == 0) {
				colisor.rigidbody.AddForce (new Vector2 (forcaEmpurrao, 0));
			} else {
				colisor.rigidbody.AddForce (new Vector2 (-forcaEmpurrao, 0));
			}
				
		}
	}
}
