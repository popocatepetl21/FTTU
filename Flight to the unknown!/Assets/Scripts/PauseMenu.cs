using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Menu;
    bool isPaused;
    private void Start() 
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(!isPaused)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                Time.timeScale = 0f;
                Menu.SetActive(true);
            }
        }
        else if(isPaused)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = false;
                Time.timeScale = 1f;
                Menu.SetActive(false);
            }
        }
        
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);   
    }
    
}