using UnityEngine;
using System.Collections;

public class Lobo : MonoBehaviour {

	public float intervaloAtaque;
	private float contagemIntervalo;
	private bool atacou;
	public float forcaEmpurrao;
	public int dano;

	public Animator anime;

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		var distancia = player.transform.position.x - transform.position.x;

		if(distancia > 0){
			transform.eulerAngles = new Vector2 (0, 0);
		}
		else{
			transform.eulerAngles = new Vector2 (0, 180);
		}
			
		if(atacou){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= intervaloAtaque){
				atacou = false;
				contagemIntervalo = 0;
			}
		}

	}
	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.tag == "Player"){

			anime.SetTrigger ("atacou");

			atacou = true;

			var vida = colisor.gameObject.transform.GetComponent<Vida> ();
			vida.perdeVida (dano);

			if (transform.eulerAngles.y == 0) {
				colisor.rigidbody.AddForce (new Vector2 (forcaEmpurrao, 0));
			} else {
				colisor.rigidbody.AddForce (new Vector2 (-forcaEmpurrao, 0));
			}




			Debug.Log ("colidiu");

		}
	}
}
