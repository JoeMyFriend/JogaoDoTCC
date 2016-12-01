using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject player;

	public Animator anime;

	public Rigidbody2D 	playerRigidBody;


	public float forceJump;
	public float speed;
	public int maxSpeed;

	// Velocidade no pulo
	public float speedInJump;


	public bool jump;
	public bool run;

	//Verifica o Chao
	public LayerMask whatIsGround;
	public bool grounded;
	public Transform groundCheck;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && grounded) {
			playerRigidBody.AddForce (transform.up * forceJump);
			jump = true;

		}
		if(Input.GetAxisRaw("Horizontal") > 0 && grounded){
			//playerRigidBody.AddForce (new Vector2((speed) * Time.deltaTime, 0));
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			run = true;
			playerRigidBody.transform.eulerAngles = new Vector2 (0, 0);
		}

		if(Input.GetAxisRaw("Horizontal") < 0 && grounded){
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


		if(Input.GetButtonUp("Horizontal")){
			run = false;
		}

		if(Input.GetKeyDown(KeyCode.O)){
			Destroy (player);
			Debug.Log("Chegou aqui");
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);

		anime.SetBool ("run", run);
	

	}
		
}