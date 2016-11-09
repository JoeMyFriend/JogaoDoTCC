using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarregaCena : MonoBehaviour {


	public void LoadScene(int level){
		SceneManager.LoadScene(level);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


		
}
