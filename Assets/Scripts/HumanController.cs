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
	public float duracaoRolamento;
	private float contagemIntervalo;

	public LayerMask whatIsGround;
	public bool grounded;
	public Transform groundCheck;


	// Colisores
	public Transform colisor;
	public Transform colisorRolamento;

	// Rolar
	public bool roll;




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

		if (Input.GetButtonDown ("Jump") && grounded && !roll) {
			playerRigidBody.AddForce (transform.up * forceJump);
		}


		if(Input.GetButtonUp("Horizontal")){
			run = false;
		}
			
		// Atacar

		if(Input.GetButtonDown("Fire1") && !atacou && !roll){
			anime.SetTrigger ("atacou");
			atacou = true;

				if (player.transform.rotation.y == 0) {
					colisor.position = new Vector3 (colisor.position.x + 0.6f, colisor.position.y, colisor.position.z);
				} else{
					colisor.position = new Vector3 (colisor.position.x - 0.6f, colisor.position.y, colisor.position.z);
				}
				contagemIntervalo = 0;

		}

		if(atacou){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= duracaoParadoNoAtaque){
				atacou = false;
				contagemIntervalo = 0;


				if (player.transform.rotation.y == 0) {
					colisor.position = new Vector3 (colisor.position.x - 0.6f, colisor.position.y, colisor.position.z);
				} else{
					colisor.position = new Vector3 (colisor.position.x + 0.6f, colisor.position.y, colisor.position.z);
				}

			}
		}

		if(Input.GetButtonDown("Roll") && !roll && !atacou && grounded){
			roll = true;

			colisorRolamento.position = new Vector3 (colisorRolamento.position.x, colisorRolamento.position.y - 0.85f, colisorRolamento.position.z);
		}

		if(roll){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= duracaoRolamento){
				colisorRolamento.position = new Vector3 (colisorRolamento.position.x, colisorRolamento.position.y + 0.85f, colisorRolamento.position.z);
				roll = false;
				contagemIntervalo = 0;
			}
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);

		anime.SetBool ("run", run);

		anime.SetBool ("jump", !grounded);

		anime.SetBool ("roll", roll);
	
	}
	void OnTriggerEnter2D(Collider2D colisor){
		if (colisor.gameObject.tag == "Enemy") {
			Debug.Log ("Batendo no rapai");
			Destroy (colisor.gameObject);
		}
	}
}
