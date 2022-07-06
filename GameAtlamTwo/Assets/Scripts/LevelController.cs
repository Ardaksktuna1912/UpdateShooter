using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject startmenu;
    public bool gameactive = false;
    public static LevelController Current;
    public int currentlevel;
    //public GameObject loadnextlevel;
    void Start()
    {
        Current = this;
        currentlevel = PlayerPrefs.GetInt("currentlevel");


        if (currentlevel >= 6)
        {
            currentlevel = 0;
        }



        if (SceneManager.GetActiveScene().name != "Level " + currentlevel)
        {
            SceneManager.LoadScene("Level " + currentlevel);

        }


    }
    public void Startgame()
    {
        CharacterMove.Current.ChangeSpeed(CharacterMove.Current.currentrunningspeed);
        startmenu.SetActive(false);
        Time.timeScale = 1f;
        gameactive = true;
    }


    void Update()
    {
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level " + (currentlevel + 1));
    }
    public void FinishGame()
    {
        PlayerPrefs.SetInt("currentlevel", currentlevel + 1);
        gameactive = false;
    }
    public void GameReturn()
    {
        SceneManager.LoadScene("Level " +(0));
        gameactive = false;
    }
}
