using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

	private Animator 	anime;
	private Rigidbody2D playerRB;



	public static float 		movimentoX; //Armazena movimento X
	public float 		speed; //velocidade

	public bool 		facingRight; //Se estiver virado pra direita set True

	public float 		Jump; //pulo

	public bool 		grounded; //Se pisar no chao set True
	public bool			wall; //Se colidir com algo set True

	public Transform  	groundCheck; //Verifica se está colidindo com o chão
	public LayerMask 	whatIsGround; //Verifica que layer é o chão

	private bool tomouDano;
	private bool spriteAtivo;
	public float imortalSegundos;
	private float tempTime;
	private float tempTime2;


	public static int life = 3;
	public Transform vida1;
	public Transform vida2;
	public Transform vida3;


	public Text coinTxt;
	public static int coin;


	private AudioSource som;
	public AudioClip JumpFX;
	public AudioClip CoinFX;

	private int andarDireita = 1;


	// Use this for initialization
	void Start () {
		life = 3;
		coin = 0;


		anime 	 = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D>();
		som		 = GetComponent<AudioSource>();
	}

	void Update()
	{
		coinTxt.text = coin.ToString();


		if(Input.GetButtonDown("Jump") && grounded==true)
		{
			Pular();
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
	

		//Verifica para que lado está olhando e vira
		if(movimentoX > 0 && !facingRight)
		{
			Flip();
		}
		if(movimentoX < 0 && facingRight)
		{
			Flip();
		}

		//Set animação de andar
		if(movimentoX != 0 && !wall)
		{
			anime.SetBool("walk", true);
		}
		else
		{
			anime.SetBool("walk", false);
		}

		if(Input.GetKey("m") && grounded==true)
		{
			Atacar();
		}
		else
		{
			anime.SetBool("attack", false);
		}

		anime.SetBool("grounded", grounded);

		movimentoX = Input.GetAxis("Horizontal");

		#if UNITY_EDITOR

		movimentoX = Input.GetAxis("Horizontal");


		if(!wall)
		{
			playerRB.velocity = new Vector2(movimentoX * speed, playerRB.velocity.y);
		}

		#endif

		//Se não estiver colidindo com algo o player recebe velocidade
		if(!wall)
		{


			/*
			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				DireitaDown();
			}

			if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			{
				DireitaUp();
			}

			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				EsquerdaDown();
			}

			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			{
				EsquerdaUp();
			}
			*/


			playerRB.velocity = new Vector2(movimentoX * speed, playerRB.velocity.y);
		}


		if(tomouDano)
		{
			float piscarEm = imortalSegundos / 12;
			tempTime2 += Time.deltaTime;

			if(tempTime2 >= piscarEm)
			{
				tempTime2 = 0;
				GetComponent<SpriteRenderer>().enabled = !spriteAtivo;
				spriteAtivo = !spriteAtivo;
			}


			tempTime += Time.deltaTime;
			if(tempTime >= imortalSegundos)
			{
				tomouDano = false;
				GetComponent<SpriteRenderer>().enabled = true;
			}
		}

		if(life > 3)
		{
			life = 3;
		}

		if(life == 2)
		{
			vida3.gameObject.SetActive(false);
		}
		if(life == 1)
		{
			vida2.gameObject.SetActive(false);
		}
		if(life == 0)
		{
			vida1.gameObject.SetActive(false);
		}

		if(life < 0)
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		Debug.Log(life);

	}

	// Inverte escala ao virar
	void Flip() 
	{
		facingRight	= !facingRight;
		Vector3 Scale = transform.localScale;
		Scale.x = Scale.x * -1;
		transform.localScale = Scale;

	}

	public void DireitaDown()
	{
		movimentoX = 1;
	}
	public void DireitaUp()
	{
		movimentoX = 0;
	}

	public void EsquerdaDown()
	{
		movimentoX = -1;
	}
	public void EsquerdaUp()
	{
		movimentoX = 0;
	}

	public void Pular()
	{
		if(grounded==true)
		{
		playerRB.AddForce(new Vector2(0, Jump));
		som.PlayOneShot(JumpFX);
		}
	}

	public void Atacar()
	{
		anime.SetBool("attack", true);
	}

	public void dano(int qtdDano)
	{
		if(!tomouDano)
		{
			life -= qtdDano;
			tomouDano = true;
			tempTime = 0;
			spriteAtivo = true;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "coin")
		{
			som.PlayOneShot(CoinFX);
			coin += 1;
			Destroy(col.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (!col.isTrigger && col.tag != "ignoreWall" && col.tag != "coin") 
		{
			wall = true;
		}
	}

	void OnTriggerExit2D()
	{
		wall = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.gameObject.tag == "Inimigo")
		{
			life -= 1;
		}
		if(col.collider.gameObject.tag == "Boss")
		{
			life -= 1;
		}

		if(col.collider.gameObject.tag == "Inimigo")
		{
			dano(0);
		}
		if(col.collider.gameObject.tag == "Boss")
		{
			dano(0);
		}

	}

	void OnCollisionStay2D(Collision2D col)
	{
		
	}

	void OnCollisionExit2D(Collision2D col)
	{
		
	}



}

