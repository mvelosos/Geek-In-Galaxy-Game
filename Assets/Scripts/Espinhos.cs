using UnityEngine;
using System.Collections;

public class Espinhos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
