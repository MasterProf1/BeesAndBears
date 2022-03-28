using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScenes : MonoBehaviour
{
    public void ChangeScene(int scenesNumber) 
    {
        SceneManager.LoadScene(scenesNumber);
    }
    public void CloseApp() 
    {
        Application.Quit();
    }
}
