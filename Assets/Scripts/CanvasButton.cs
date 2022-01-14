using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("_Scene_Start");
    }
}
