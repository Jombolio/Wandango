using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Canvas OptionsCanvas;
    public AudioSource MenuMusic;
    public Scene MainMenu_Scene;
    public Scene TEST_Scene;
    public Scene CHS_FLOOR1_Scene;

    // Start is called before the first frame update
    void Start()
    {
        OptionsCanvas.enabled = false;
        MenuMusic.loop = true;
        MenuMusic.Play();
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButton()
    {
        SceneManager.LoadScene("CHS-TEST");
    }

    public void optionsButton()
    {
        OptionsCanvas.enabled = true;
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("lol, this quits the game");
    }

}
