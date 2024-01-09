using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("StartScene");
    }
}
