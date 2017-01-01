using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapLoad : MonoBehaviour
{
    public string load;

    void OnMouseDown()
    {
        SceneManager.LoadScene (load);
    }
             
}
