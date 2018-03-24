using UnityEngine;
using System.Collections;

public class PlataformaEspinho : MonoBehaviour {

	public float Speed;
	public float mudarDirecao;
	private float timeTemp;
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

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

}