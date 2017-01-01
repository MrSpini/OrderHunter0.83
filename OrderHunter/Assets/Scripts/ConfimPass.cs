using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfimPass : MonoBehaviour
{	
	public InputField Pass;
	public InputField PassConfim;
	public Text Error;

	protected string password;
	protected string password_confim;
	bool answer = true;

	void Update () 
	{
		password = Pass.text.ToString ();
		password_confim = PassConfim.text.ToString ();

		answer = Comparison (password, password_confim);
			
		if (answer == false)
			{
				Error.color = new Color (Error.color.r, Error.color.g, Error.color.b, 255);
			}
			else
				{
					Error.color = new Color (Error.color.r, Error.color.g, Error.color.b, 0);
				}
	}

	private bool Comparison(string pass, string confim)
	{	
			if (pass == confim) answer = true;
		 		else answer = false;

		return answer;
	}


}
