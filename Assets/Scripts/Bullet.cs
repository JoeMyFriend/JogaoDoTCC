using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float velocidade;
	public int dano;

	public Vida vida;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.tag == "Player"){
			vida.perdeVida(dano);
			Debug.Log ("Colidiu");
		}
		Destroy (gameObject);
	}
}
