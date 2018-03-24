using UnityEngine;
using System.Collections;

public class PlataformaCai : MonoBehaviour {

	public float duracaoCair;
	private float tempo;
	private bool pisou;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(pisou)
		{
			tempo += Time.deltaTime;

			if(tempo >= duracaoCair)
			{
				gameObject.AddComponent<Rigidbody2D>();
				Destroy(gameObject,1f);
			}
		}
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Player")
		{
			pisou = true;
		}
	}
}
