using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RegistrationText : MonoBehaviour
{
	void OnMouseDown()
	{
		SceneManager.LoadScene ("Registration");
	}
}
