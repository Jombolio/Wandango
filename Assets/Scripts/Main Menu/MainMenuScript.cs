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

    // Start is called before the first frame update
    void Start()
    {
        OptionsCanvas.enabled = false;
        MenuMusic.loop = true;
        MenuMusic.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButton()
    {
        SceneManager.LoadScene("game_Level1");
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
