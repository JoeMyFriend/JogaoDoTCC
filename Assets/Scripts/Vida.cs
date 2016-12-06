using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour {

	public GameObject vida;
	public int maxVida;
	public int vidaAtual;

	// Use this for initialization
	void Start () {
		vidaAtual = maxVida;
		vida.GetComponent<GUIText> ().color = Color.green;
		vida.GetComponent<GUIText> ().text = "HP: " + vidaAtual + "/" + maxVida;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if(Input.GetMouseButtonDown(0)){
			perdeVida (20);
			Debug.Log ("Clicou");
		}
		*/
	}

	public void perdeVida(int dano){
		vidaAtual -= dano;

		if(vidaAtual <= 0){
			SceneManager.LoadScene (0);
		}

		if((vidaAtual * 100 / maxVida) < 30){
			vida.GetComponent<GUIText> ().color = Color.red;
		}

		vida.GetComponent<GUIText> ().text = "HP: " + vidaAtual + "/" + maxVida;

	}

	public void recuperaVida(int recupera){
		vidaAtual += recupera;
		if(vidaAtual > maxVida){
			vidaAtual = maxVida;
		}
		if((vidaAtual * 100 / maxVida) >=30){
			vida.GetComponent<GUIText> ().color = Color.green;
		}

		vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
	}


		
}
