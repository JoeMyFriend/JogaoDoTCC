using UnityEngine;
using System.Collections;

public class EnemyStalker : MonoBehaviour {

	public Animator anime;
	public GameObject player;

	public int dano;
	public float speed;
	public float forcaEmpurrao;

	public float distanciaSeguir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var distancia = player.transform.position.x - transform.position.x;

		if (distancia > 0 && Mathf.Abs(distancia) <= distanciaSeguir) {
			transform.eulerAngles = new Vector2 (0, 0);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} else if(distancia <= 0 && Mathf.Abs(distancia) <= distanciaSeguir) {
			transform.eulerAngles = new Vector2 (0,180);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}

	
	}
	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.tag == "Player"){
			
			anime.SetTrigger ("atacou");

			var vida = colisor.gameObject.transform.GetComponent<Vida> ();
			vida.perdeVida (dano);

			if (player.transform.eulerAngles.y == 0) {
				colisor.rigidbody.AddForce (new Vector2 (-forcaEmpurrao, 0));
			} else {
				colisor.rigidbody.AddForce (new Vector2 (forcaEmpurrao, 0));
			}




			Debug.Log ("colidiu");

		}
	}
}
