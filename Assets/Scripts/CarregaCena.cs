using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarregaCena : MonoBehaviour {


	public void StartScene(int level){
		SceneManager.LoadScene(level);
	}
		
	public void LoadScene(){
		Debug.Log (PlayerPrefs.HasKey("faseSalva"));
		if(PlayerPrefs.HasKey("faseSalva")){
			Debug.Log (PlayerPrefs.HasKey("faseSalva"));
			SceneManager.LoadScene (PlayerPrefs.GetInt("faseSalva"));
		}
	}

	public void QuitScene(){
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


		
}
