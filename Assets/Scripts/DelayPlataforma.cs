using UnityEngine;
using System.Collections;

public class DelayPlataforma : MonoBehaviour {

	private Animator anime;
	private float tempo;
	private int adicionar = 1;
	public int maximo;



	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator>();
		tempo = Time.deltaTime;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempo += (int) adicionar * Time.deltaTime;


		if(tempo >= maximo)
		{
			anime.SetBool("on", true);
		}
		else
		{
			anime.SetBool("on", false);
		}

		if(tempo >= maximo)
		{
			tempo = 1;
		}
	
	}
}
