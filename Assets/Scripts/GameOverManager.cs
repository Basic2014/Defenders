using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject restart, mainMenu, quit;
    //public Timer timer;

    private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        if(playerHealth.currHealth<=0)
        {

            //timer.enabled = false;
            anim.SetTrigger("GameOver");
            restart.SetActive(true);
            mainMenu.SetActive(true);
            quit.SetActive(true);


        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();

        #endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
