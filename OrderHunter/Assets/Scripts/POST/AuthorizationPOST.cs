using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using UnityEngine.UI;
using LitJson;
using System.Text;
using UnityEngine.SceneManagement;

public class AuthorizationPOST : MonoBehaviour 
{
	private string ServerName = "http://app-labs-crawlers.ru";
	private string PostPath = "/app/auth/registration";

	public InputField Phone;
	public InputField Email;
	public InputField FirstName;
	public InputField LastName;
	public InputField City;

	public Text Result;

	public GameObject Sprites;
	public GameObject ButtonOK;
	public GameObject ResultText;
	public GameObject Waiting;
	public GameObject ADRegistration;
	public GameObject ADButton;
	public GameObject ADName;
	public GameObject ADLastName;
	public GameObject ADMail;
	public GameObject ADCity;
	public GameObject ADQuestion;
	public GameObject ADPhone;
	public GameObject ADBack;
	public GameObject ADIcons;
	public GameObject Registration;

	private string JsonString; 
	private JsonData itemData;

	private int sooth = 1;
	private float tiltAngle = 10f;

	void Update()
	{
		float tiltAroundZ = Input.GetAxis ("Horizontal") * tiltAngle;
		float tiltAroundX = Input.GetAxis ("Vertical") * tiltAngle;
		Quaternion target = Quaternion.Euler (tiltAroundX, 0, tiltAroundZ);
		Sprites.transform.rotation = Quaternion.Slerp (Sprites.transform.rotation, target, Time.deltaTime * sooth);
	}

	public void MouseDown()
	{	
		StartCoroutine (WaiterDeactive());
		string URLpath = ServerName + PostPath;
		POST(URLpath);
		StartCoroutine (WaiterActive());
		StartCoroutine (WaiterAnswerUI ());

	}

	private  void POST (string URL)
	{ 
		try
		{
			using (var WebClient = new WebClient())
			{		
					var pars = new  NameValueCollection();

						pars.Add ("phone", Phone.text.ToString());
						pars.Add ("email", Email.text.ToString());
						pars.Add ("first_name", FirstName.text.ToString());
						pars.Add ("last_name", LastName.text.ToString());
						pars.Add ("city", City.text.ToString());
						
					var response = WebClient.UploadValues(URL, pars);
					string parse = Encoding.Default.GetString(response);

					JsonString = parse;
					itemData = JsonMapper.ToObject(JsonString);
				}
			}
		catch{}
	}
		
	public void OK()
	{
		SceneManager.LoadScene ("Enter");
	}

	private void Deactiv()
	{
		ADRegistration.SetActive (false);
		ADButton.SetActive (false);
		ADName.SetActive (false);
		ADLastName.SetActive (false);
		ADMail.SetActive (false);
		ADCity.SetActive (false);
		ADQuestion.SetActive (false);
		ADPhone.SetActive (false);
		ADBack.SetActive (false);
		ADIcons.SetActive (false);
		Waiting.SetActive (true);
		Registration.SetActive (true);
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

	private void Activ()
	{
			ADRegistration.SetActive (true);
			ADButton.SetActive (true);
			ADName.SetActive (true);
			ADLastName.SetActive (true);
			ADMail.SetActive (true);
			ADCity.SetActive (true);
			ADQuestion.SetActive (true);
			ADPhone.SetActive (true);
			ADBack.SetActive (true);
			ADIcons.SetActive (true);
			Waiting.SetActive (false);
			Registration.SetActive (false);
	}

	private void AnswersUI()
	{
		ADRegistration.SetActive (false);
		ADButton.SetActive (false);
		ADName.SetActive (false);
		ADLastName.SetActive (false);
		ADMail.SetActive (false);
		ADCity.SetActive (false);
		ADQuestion.SetActive (false);
		ADPhone.SetActive (false);
		ADBack.SetActive (false);
		ADIcons.SetActive (false);
		Waiting.SetActive (false);
		Registration.SetActive (false);
		ResultText.SetActive (true);
	}

	private void Retry()
	{
		Sprites.SetActive (true);
		Sprites.transform.rotation = Quaternion.Euler (0,0, 180f);
	}

	protected void Result_and_Exceptions ()
	{
        try
        {
		switch(itemData["result"].ToString())
		{
		case "1002":
			Result.text = "Введите номер телефона";
			Retry ();
			break;
		case "1003":
			Result.text = "Введите адрес электронной почты";
			Retry ();
			break;
		case "1006":
			Result.text = "Укажите город";
			Retry ();
			break;
		case "1008":
			Result.text = "Длинна имени не может быть менее двух символов";
			Retry ();
			break;
		case "1009":
			Result.text = "Не удалось зарегестрировать пользователя";
			Retry ();
			break;
		case "1011":
			Result.text = "Название города не может быть менее двух символов";
			Retry ();
			break;
		case "1012":
			Result.text = "Пользователь с такой почтой и телефоном уже существует";
			Retry ();
			break;
		case "1016":
			Result.text = "Поле пинкода не может быть пустым";
			Retry ();
			break;
		case "1017":
			Result.text = "Пинкод должен состоять из 4х символов";
			Retry ();
			break;
		case "1018":
			Result.text = "Подтверждение пин кода не удалось";
			Retry ();
			break;
		case "1019":
			Result.text = "Неизвестная ошибка";
			Retry ();
			break;
		case "1035":
			Result.text = "Неизвестная ошибка, не удалось зарегистрировать пользователя";
			Retry ();
			break;
		case "1047":
			Result.text = "Укажите город";
			Retry ();
			break;
		case "1048":
			Result.text = "Длинна города не может быть менее двух символов";
			Retry ();
			break;
		case "1054":
			Result.text = "Не корректные символы в поле - Имя";
			Retry ();
			break;
		case "1055":
			Result.text = "Не корректные символы в поле - Фамилия";
			Retry ();
			break;
		case "1056":
			Result.text = "Не корректные символы в поле - Город";
			Retry ();
			break;
		case "200":
			Result.text = "Регистрация успешно завершена";
			ButtonOK.SetActive (true);
			break;
		}
        }
        catch{
            if (JsonString == null)
            {
                Result.color = new Color32(255, 132, 132, 255);
                Result.text = "Нет сети";
                ButtonOK.SetActive(true);
            }
            else
                Result.color = new Color32(255,255,255,255);
        }
	}
}
