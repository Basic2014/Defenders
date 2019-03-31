using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;

    private bool gamePaused = false;
	
	
	void Update () {
		

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }

        if(gamePaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);                

        }
        if(!gamePaused)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        
	}

    public void ResumeGame()
    {
        gamePaused = false;
    }


    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
#endif
    }

   
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }



}
