using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	private Player Player;
	public string botao;


	public bool carregarPlayer;

	// Use this for initialization
	void Start () {

		if(carregarPlayer)
		{
			Player = FindObjectOfType(typeof(Player)) as Player;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTouchDown()
	{
		switch(botao)
		{
			case "Jump":
			if(carregarPlayer)
			{
				Player.Pular();
			}
			break;

			case "Attack":
			if(carregarPlayer)
			{
				Player.Atacar();
			}
			break;


			case "Play":
			Application.LoadLevel("game");
			break;

			case "Credits":
			Application.LoadLevel("credits");
			break;

			case "voltar":
			Application.LoadLevel("menu");
			break;

			case "congrats":
			Application.LoadLevel("congrats");
			break;
			
			case "Direita":
			if(carregarPlayer)
			{
				Player.DireitaDown();
			}
			break;

			case "Esquerda":
			if(carregarPlayer)
			{
				Player.EsquerdaDown();
			}
			break;
		}

	}

	public void OnTouchUp()
	{
		switch(botao)
		{
		case "Direita":
			if(carregarPlayer)
			{
				Player.DireitaUp();
			}
			break;

		case "Esquerda":
			if(carregarPlayer)
			{
				Player.EsquerdaUp();
			}
			break;
		}
	}

	public void OnTouchMoved()
	{

	}

	public void OnTouchStay()
	{
		
	}

	public void OnTouchCanceled()
	{

	}
}
