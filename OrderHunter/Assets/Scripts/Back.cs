using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
	void OnMouseDown()
	{
		SceneManager.LoadScene ("Authorization");
	}
}
