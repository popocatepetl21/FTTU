using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            PlayerPrefs.SetInt("deaths", 0);
        }
    }
}
