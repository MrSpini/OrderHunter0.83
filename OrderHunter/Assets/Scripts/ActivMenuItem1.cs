using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class ActivMenuItem1 : MonoBehaviour 
{ 
	public Image Field; 
	public GameObject ImagSprit;
	public Sprite Sprites_1, Sprites_2; 
	public Text Texts; 

	void OnMouseDown() 
	{ 
		Field.color = new Color32 (37, 37, 37, 230); 
		Texts.color = new Color32 (183, 183, 183, 255); 
		if (ImagSprit.GetComponent <SpriteRenderer> ().sprite.name == "sawitcher_off")
		{
			ImagSprit.GetComponent <SpriteRenderer> ().sprite = Sprites_1;
		} 
		else
		{
			ImagSprit.GetComponent <SpriteRenderer> ().sprite = Sprites_2;
		}
	} 

	void OnMouseUp() 
	{ 
		Field.color = new Vector4 (255,255,255,255); 
		Texts.color = new Color32 (112, 130, 253, 255); 
	} 
} 