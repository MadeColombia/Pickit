using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputField playerName;
    public dataManager DataManager;
    
    public void PlayGame()
    {
        
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playerName.text = DataManager.data.name;
        DataManager.save();
    }

    public void returnMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }


 }
