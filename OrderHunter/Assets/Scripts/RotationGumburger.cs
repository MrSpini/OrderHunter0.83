using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class RotationGumburger : MonoBehaviour
{
	private float smooth = 8f;
	private float tiltAngle = 10.0f;
	public GameObject Panel;
	public GameObject Background;

	public GameObject Anim_1;
	public GameObject Anim_2;

	int a = 0;
	//Backpanels bp = new Backpanels ();
	void Update()
	{		
		RotateGum (a);
	}

	 void OnMouseDown()
	{
		a += 180;
		switch(Panel.activeSelf)
		{
		case false:
				ActivUI ();
				break;

		case true:
				DeactivUI ();
				break;
		}
	}

	void RotateGum(int ist)
	{
		/*float tiltAroundZ = Input.GetAxis ("Horizontal") * tiltAngle;
		float tiltAroundX = Input.GetAxis ("Vertical") * tiltAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, tiltAroundZ+ist);
		transform.rotation = Quaternion.Slerp (this.transform.rotation, target, Time.deltaTime  * smooth);*/
	}
		
	protected void ActivUI()
	{
		Background.SetActive (true);
		Panel.SetActive (true);
		Anim_1.SetActive (true);
		Anim_2.SetActive (false);
	}

	protected void DeactivUI()
	{
		Background.SetActive (false);
		Panel.SetActive (false);
		Anim_1.SetActive (false);
		Anim_2.SetActive (true);
	}
}
