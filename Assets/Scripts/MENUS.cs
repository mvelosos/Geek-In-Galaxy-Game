using UnityEngine;
using System.Collections;

public class MENUS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame()
	{
		Application.LoadLevel("game");
	}
		
	public void Credits()
	{
		Application.LoadLevel("credits");
	}

	public void Menu()
	{
		Application.LoadLevel("menu");
	}
}
