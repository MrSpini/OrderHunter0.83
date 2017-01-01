using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Authorization : MonoBehaviour 
{
	public void LoadEnter(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void LoadRegistration(string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
