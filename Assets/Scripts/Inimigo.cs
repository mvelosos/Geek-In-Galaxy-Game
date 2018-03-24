using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	public float velocidade;
	public bool direcao;
	public float duracaoDirecao;

	private float tempoNaDirecao;
	private Animator anime;

	private Player Player;
	public int danoCausado;

	private AudioSource som;
	public AudioClip AttackFX;



	// Use this for initialization
	void Start () {

		som = GetComponent<AudioSource>();
		Player = FindObjectOfType(typeof(Player)) as Player;
		anime = GetComponent<Animator>();
		
	
	}
	
	// Update is called once per frame
	void Update () {

		if(direcao)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}
		else
		{
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);

		tempoNaDirecao += Time.deltaTime;
		if(tempoNaDirecao >= duracaoDirecao)
		{
			tempoNaDirecao = 0;
			direcao = !direcao;
		}
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.gameObject.tag == "espada")
		{
			som.PlayOneShot(AttackFX);
			Destroy(gameObject);
			Player.life += 1;
		}
	}
}
