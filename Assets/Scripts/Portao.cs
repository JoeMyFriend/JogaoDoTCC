using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portao : MonoBehaviour {

	public Rigidbody2D player;
	public int proximaFase;
	public GameObject dialogo;
	private string fala;

	public float duracaoPausa;
	public float contagemIntervalo;

	public static bool colidiu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(colidiu){
			contagemIntervalo += Time.deltaTime;
			if(contagemIntervalo >= duracaoPausa){
				SceneManager.LoadScene (proximaFase);
				contagemIntervalo = 0;
				colidiu = false;

			}
		}
	}

	void OnTriggerEnter2D(Collider2D colisor){

		colidiu = true;
		if (colisor.gameObject.tag == "Player") {

			PlayerPrefs.SetInt ("faseSalva", proximaFase);

			if(proximaFase == 2){
				dialogo.GetComponent<GUIText> ().text = Falas.fala1;
			}
			if (proximaFase == 3) {
				dialogo.GetComponent<GUIText> ().text = Falas.fala2;
			}


			//Debug.Log (PlayerPrefs.HasKey("faseSalva"));

		}
	}
}
