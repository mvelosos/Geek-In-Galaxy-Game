using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}


		if(Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				Ray ray = cam.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit))
				{
					GameObject objeto = hit.transform.gameObject;

					switch(touch.phase)
					{
					case TouchPhase.Began:
						objeto.SendMessage("OnTouchDown", SendMessageOptions.DontRequireReceiver);
						break;

					case TouchPhase.Ended:
						objeto.SendMessage("OnTouchUp", SendMessageOptions.DontRequireReceiver);
						break;

					case TouchPhase.Moved:
						objeto.SendMessage("OnTouchMoved", SendMessageOptions.DontRequireReceiver);
						break;

					case TouchPhase.Stationary:
						objeto.SendMessage("OnTouchStay", SendMessageOptions.DontRequireReceiver);
						break;

					case TouchPhase.Canceled:
						objeto.SendMessage("OnTouchCanceled", SendMessageOptions.DontRequireReceiver);
						break;



					}
				}
			}
		}
	}
}
