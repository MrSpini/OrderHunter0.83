using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwapButons : MonoBehaviour 
{
	public Image Field;
	public Sprite Sprites_1, Sprites_2;
	public Text Texts;

	void OnMouseDown()
	{
		FieldClickDown ();
	}

	void OnMouseUp()
	{
		FieldClickUP ();
	}

	protected void FieldClickDown()
	{
		Field.color = new Color32 (37, 37, 37, 230);
		Texts.color = new Color32 (183, 183, 183, 255);
		switch (Sprites_1.name) 
		{
			case "order white":
				GetComponent <SpriteRenderer> ().sprite = Sprites_2;
				break;
		}
	}

	protected void FieldClickUP()
	{
		Field.color = new Vector4 (255,255,255,255);
		Texts.color = new Color32 (112, 130, 253, 255);	
		switch (gameObject.name) 
		{
			case "Sprites_2":
				GetComponent <SpriteRenderer> ().sprite = Sprites_1;
				break;
		}
	}
}
