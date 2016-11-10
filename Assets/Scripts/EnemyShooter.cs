using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

	public float intervaloAtaque;
	private float contagemIntervalo;
	private bool atacou;
	public float distaciaAtaque;

	public Animator anime;

	public GameObject player;
	public GameObject ataque;

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

		if(!atacou && Mathf.Abs(distancia) <= distaciaAtaque){
			anime.SetTrigger ("atacou");
			Instantiate (ataque, transform.position, transform.rotation);
			atacou = true;
		}

		if(atacou){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= intervaloAtaque){
				atacou = false;
				contagemIntervalo = 0;
			}
		}

	}
}
