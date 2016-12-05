using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speedX;
	public float speedY;
	private float offsetX;
	private float offsetY;

	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		offsetX += speedX * Time.deltaTime;
		offsetY += speedY * Time.deltaTime;

		currentMaterial.SetTextureOffset ("_MainTex", new Vector2(offsetX, offsetY));
	}
}
