using UnityEngine;
using System.Collections;

public class MoverVertical : MonoBehaviour {

	public float Speed;
	public float mudarDirecao;
	private float timeTemp;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		float x = transform.position.x;
		x += Speed*Time.deltaTime;

		timeTemp += Time.deltaTime;
		if(timeTemp >= mudarDirecao)
		{
			timeTemp = 0;
			Speed *= -1;
		}

		transform.position = new Vector3( x, transform.position.y, transform.position.z);



	}


	void OnCollisionStay2D(Collision2D col) 
	{
		if (col.gameObject.name == "Player") 
		{
			col.gameObject.transform.parent = transform;
		}
	}

	void OnCollisionExit2D(Collision2D col) 
	{
		if (col.gameObject.name == "Player") 
		{
			col.gameObject.transform.parent = null;
		}
	}

}
