using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagUrl : MonoBehaviour {


	public Image img;

	IEnumerator Start() {

		string url = "https://deti-online.com/img/raskraska-lico-devushki.jpg";

		WWW www = new WWW(url);

		yield return www;
		Renderer renderer = GetComponent<Renderer>();


		img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
	}


	void Update () {
		
	}
}

