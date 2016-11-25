using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour {
	
	
	public GameObject player;

	public Animator anime;

	public Rigidbody2D 	playerRigidBody;


	public float forceJump;
	public float speed;

	public float speedInJump;

	// Correr
	public bool run;


	// Ataque
	public bool atacou;
	public float duracaoParadoNoAtaque;
	private float contagemIntervalo;

	public LayerMask whatIsGround;
	public bool grounded;
	public Transform groundCheck;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetAxisRaw("Horizontal") > 0 && grounded && !atacou){
			//playerRigidBody.AddForce (new Vector2((speed) * Time.deltaTime, 0));
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			run = true;
			playerRigidBody.transform.eulerAngles = new Vector2 (0, 0);
		}

		if(Input.GetAxisRaw("Horizontal") < 0 && grounded && !atacou){
			//playerRigidBody.AddForce (new Vector2((speed) * Time.deltaTime * -1, 0));
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			run= true;
			playerRigidBody.transform.eulerAngles = new Vector2 (0, 180);
		}


		if(Input.GetAxisRaw("Horizontal") > 0 && !grounded){
			//playerRigidBody.AddForce (new Vector2((speedInJump) * Time.deltaTime, 0));
			transform.Translate(Vector2.right * speedInJump * Time.deltaTime);
			run = true;
			playerRigidBody.transform.eulerAngles = new Vector2 (0, 0);
		}

		if(Input.GetAxisRaw("Horizontal") < 0 && !grounded){
			//playerRigidBody.AddForce (new Vector2((speedInJump) * Time.deltaTime * -1, 0));
			transform.Translate(Vector2.right * speedInJump * Time.deltaTime);
			run= true;
			playerRigidBody.transform.eulerAngles = new Vector2 (0, 180);
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			playerRigidBody.AddForce (transform.up * forceJump);
		}


		if(Input.GetButtonUp("Horizontal")){
			run = false;
		}
			
		// Atacar

		if(Input.GetButtonDown("Fire1")){
			anime.SetTrigger ("atacou");
			atacou = true;

		}

		if(atacou){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= duracaoParadoNoAtaque){
				atacou = false;
				contagemIntervalo = 0;
			}
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);

		anime.SetBool ("run", run);

		anime.SetBool ("jump", !grounded);
	
	}
}
