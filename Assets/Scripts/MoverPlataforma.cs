using UnityEngine;
using System.Collections;

public class MoverPlataforma : MonoBehaviour {

	public float Speed;
	public float mudarDirecao;
	private float timeTemp;

	// Use this for initialization
	void Start () {

	
	}

	// Update is called once per frame
	void Update () {

		float y = transform.position.y;
		y += Speed*Time.deltaTime;

		timeTemp += Time.deltaTime;
		if(timeTemp >= mudarDirecao)
		{
			timeTemp = 0;
			Speed *= -1;
		}

		transform.position = new Vector3(transform.position.x, y, transform.position.z);



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
