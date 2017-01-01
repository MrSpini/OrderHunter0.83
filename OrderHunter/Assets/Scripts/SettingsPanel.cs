using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour 
{
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	private int g;

	public GameObject spritD;
	public Sprite sprit1;
	public Sprite sprit2;
	public Sprite sprit3;
	public Text Texticon;

	public Image ImagAvatar;
	public Image ImagAvatar2;
	public Text Acc, Email, VK, FaceBook;
	public float minSwipeDistY;

	public float minSwipeDistX;

	private Vector2 startPos;

	IEnumerator Start() {

		string url = "https://deti-online.com/img/raskraska-lico-devushki.jpg";

		WWW www = new WWW(url);

		yield return www;
		Renderer renderer = GetComponent<Renderer>();


		ImagAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
		ImagAvatar2.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

		//ImagAvatar.GetComponent<Image> ().sprite
		Acc.text="+"+PlayerPrefs.GetString ("phone").ToString();
		Email.text=PlayerPrefs.GetString ("email").ToString();
		//Acc.text=PlayerPrefs.GetString ("phone").ToString();
		//Acc.text=PlayerPrefs.GetString ("phone").ToString();
		g = 1;
		minSwipeDistX=150;
	}

	void MoveRight ()
	{
		switch (g)
		{
		case 1:
			spritD.GetComponent<Image> ().sprite = sprit3;
			Texticon.text = "Пригласи друга";
			Panel2.SetActive (false);
			Panel1.SetActive (false);
			g = 3;
			Panel3.SetActive (true);
			return;
		case 2:
			spritD.GetComponent<Image> ().sprite = sprit1;
			Texticon.text = "Профиль";
			Panel3.SetActive (false);
			Panel2.SetActive (false);
			g = 1;
			Panel1.SetActive (true);
			return;
		case 3:
			spritD.GetComponent<Image> ().sprite = sprit2;
			Texticon.text = "Статистика";
			Panel3.SetActive (false);
			Panel1.SetActive (false);
			g = 2;
			Panel2.SetActive (true);
			return;
		}
	}

	void MoveLeft ()
	{
		switch(g)
			{
		case 1:
			spritD.GetComponent<Image> ().sprite = sprit2;
			Texticon.text = "Статистика";
			Panel1.SetActive (false);
			Panel3.SetActive (false);
			g = 2;
			Panel2.SetActive (true);
			return;
		case 2:
			spritD.GetComponent<Image> ().sprite = sprit3;
			Texticon.text = "Пригласи друга";
			Panel1.SetActive (false);
			Panel2.SetActive (false);
			g = 3;
			Panel3.SetActive (true);
			return;
		case 3:
			spritD.GetComponent<Image> ().sprite = sprit1;
			Texticon.text = "Профиль";
			Panel3.SetActive (false);
			Panel2.SetActive (false);
			g = 1;
			Panel1.SetActive (true);
			return;
		}
	}
	void Update ()
	{
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];



			switch (touch.phase) {

			case TouchPhase.Began:

				startPos = touch.position;
				break;



			case TouchPhase.Ended:
				
				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX)
				{

					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);

					if (swipeValue > 0) 
					{
						//right swipe
						MoveRight();
					}
					else
					{
						//left swipe
						MoveLeft();
					}
				}
				break;
			}
		}
	}
}
