using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public Transform player;

	private float	 Playerx; 
	private float	 Playery; 

	private float    yCam; //y da camera

	public	float    ajusteX;
	public	float    ajusteY;

	public	float 	 transition;

	public  bool	 comLerp;
	public  bool     seguirY;

	//LIMITADOR DA CAMERA

	public Transform  LE;
	public Transform  LD;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;

	}

	// Update is called once per frame
	void LateUpdate () {

		Playerx = player.position.x; // a cada frame pega a posição x do personagem (player)
		Playery = player.position.y;

		yCam = transform.position.y; //y da camera

		if(seguirY)
		{
			yCam = Playery + ajusteY; 
		}


		if(Playerx > LE.position.x  && Playerx < LD.position.x)
		{

			if(comLerp)
			{
				transform.position = Vector3.Lerp(transform.position, new Vector3(Playerx, yCam, transform.position.z), transition);
			}
			else
			{
				transform.position = new Vector3(Playerx + ajusteX, yCam, transform.position.z);
			}

		}
		else
		{
			if(comLerp && transform.position.x > LE.position.x  && transform.position.x < LD.position.x)
			{
				transform.position = Vector3.Lerp(transform.position, new Vector3(Playerx, yCam, transform.position.z), transition);

			}

		}
	}
}
