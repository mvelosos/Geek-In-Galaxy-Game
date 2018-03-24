using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform objeto;
	public float parallaxScale;
	public float suavizar;

	public Transform cam;
	public Vector3	previewCamPos;

	// Use this for initialization
	void Start () {
	
		previewCamPos = cam.position;

	}
	
	// Update is called once per frame
	void Update () {

		float movimento = (previewCamPos.x - cam.position.x) * parallaxScale;
		float target 	= objeto.position.x + movimento;
		Vector3 objPos	= new Vector3(target, objeto.position.y, objeto.position.z);

		objeto.position = Vector3.Lerp(objeto.position, objPos, suavizar*Time.deltaTime);

		previewCamPos = cam.position;
	
	}
}
