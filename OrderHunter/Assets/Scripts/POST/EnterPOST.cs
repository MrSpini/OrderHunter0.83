using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using LitJson;
using UnityEngine.SceneManagement;

public class EnterPOST : MonoBehaviour
{
	public InputField Phone;
	public InputField Password;

	private string ServerName = "http://app-labs-crawlers.ru";
	private string PostPath = "/app/auth/authorization";
	private string JsonString;
	private JsonData itemData;

	public GameObject Texts_1;
	public GameObject Texts_2;
	public GameObject Texts_3;
	public GameObject Sprites_1;
	public GameObject Sprites_2;
	public GameObject Sprites_3;
	public GameObject Phones;
	public GameObject Pass;
	public GameObject Buttons;
	public GameObject Wait;
	public GameObject Answer;

	public Text Answ;
    public string cookie;
    public void Login()
	{
		string URLpath = ServerName + PostPath;
		LoginPOST (URLpath);
		StartCoroutine (WaiterDeactive());
		StartCoroutine (WaiterActive());
		StartCoroutine (WaiterAnswerUI ());
		Debug.Log (JsonString);
        if (JsonString == null)
        {
            Answ.color = new Color32(255, 132, 132, 255);
            Answ.text = "Нет сети";
        }
        else
            Answ.color = new Color32(255,255,255,255);
	}

	private void LoginPOST(string Url)
	{
		try
		{
			using (var WebClient = new WebClient())
			{		
				var pars = new  NameValueCollection();
              //  WebClient.Headers.Add("Set-Cookie", Url);
				pars.Add ("phone", Phone.text.ToString());
				pars.Add ("password", Password.text.ToString());

				var response = WebClient.UploadValues(Url, pars);
				string parse = Encoding.Default.GetString(response);

				JsonString = parse;
				itemData = JsonMapper.ToObject(JsonString);
                var parseLaravel_session = WebClient.ResponseHeaders.Get("Set-cookie"); 
                string laravel_session = "laravel_session=";
                char[] simbol = {',', ';'};
                try
                {
                    if(parseLaravel_session.Contains(laravel_session))
                    {
                        string[] clearlaravel = parseLaravel_session.Split(simbol);
                        print(clearlaravel[5].Substring(16));
                        PlayerPrefs.SetString("Set-cookie", clearlaravel[5].Substring(16));
                    }   
                }
                catch{}
                print(PlayerPrefs.GetString("Set-cookie"));
            }

		}
		catch{}
	}

	private void Activ()
	{
		Texts_1.SetActive (true);
		Texts_2.SetActive(true);
		Sprites_1.SetActive (true);
		Sprites_2.SetActive (true);
		Sprites_3.SetActive (true);
		Phones.SetActive(true);
		Pass.SetActive(true);
		Buttons.SetActive(true);
		Wait.SetActive (false);
		Texts_3.SetActive (false);

	}

	private void Deactiv()
	{
		Texts_1.SetActive (false);
		Texts_2.SetActive(false);
		Sprites_1.SetActive (false);
		Sprites_2.SetActive (false);
		Phones.SetActive(false);
		Pass.SetActive(false);
		Buttons.SetActive(false);
		Sprites_3.SetActive (false);
		Wait.SetActive (true);
		Texts_3.SetActive (true);
		Answer.SetActive (false);
	}

	private void AnswersUI()
	{
		Answer.SetActive (true);
	}

	IEnumerator WaiterDeactive()
	{
		yield return new WaitForSeconds (0);
		Deactiv ();
	}

	IEnumerator WaiterActive()
	{
		yield return new WaitForSeconds (1.5f);
		Activ ();
	}

	IEnumerator WaiterAnswerUI()
	{
		yield return StartCoroutine (WaiterActive());
		Result_and_Exceptions ();
		AnswersUI ();
	}

	protected void Result_and_Exceptions ()
	{
        try
        {
		switch (itemData ["result"].ToString ()) 
		{
			case "1022":
				Answ.text = "Не правильный логин или пароль";
				break;
            case "200":
                PlayerPrefs.SetString("id", itemData["user"]["id"].ToString());
                PlayerPrefs.SetString("first_name", itemData["user"]["first_name"].ToString());
                PlayerPrefs.SetString("email", itemData["user"]["email"].ToString());
                PlayerPrefs.SetString("last_name", itemData["user"]["last_name"].ToString());
                PlayerPrefs.SetString("user_group", itemData["user"]["user_group"].ToString());
				//PlayerPrefs.SetString ("gender", itemData ["user"] ["gender"].ToString ());
                PlayerPrefs.SetString("city_id", itemData["user"]["city_id"].ToString());
                PlayerPrefs.SetString("phone", itemData["user"]["phone"].ToString());
                PlayerPrefs.SetString("avatar", itemData["user"]["avatar"].ToString());
				SceneManager.LoadScene ("Test_2");
				break;
     //      case null:

        //     break;
            }

        }
        catch{ }
	}

}