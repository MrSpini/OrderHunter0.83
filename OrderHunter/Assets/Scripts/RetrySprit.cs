using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetrySprit : MonoBehaviour
{
	void OnMouseDown()
	{
		SceneManager.LoadScene ("Registration");
	}
}
