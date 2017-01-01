using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInfo : MonoBehaviour {
	public GameObject Imag; 
	public Text Text; 

	public Sprite sprite1;
	public Sprite sprite2;
	// Use this for initialization
	void Start () {
		
	}

	void Update ()
	{
		if (Text.text == "") {
			Imag.GetComponent<Image> ().sprite = sprite1;
		} else 
		{
			Imag.GetComponent<Image> ().sprite = sprite2;
		}
	}
}
