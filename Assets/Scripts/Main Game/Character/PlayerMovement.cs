using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    //Public Defined
    public float moveSpeed = 5f;
    //public Canvas pauseMenu;
    public static bool GamePause = false;
    public GameObject PauseMenuBehaviour;
    public Vector2 LastMoveDirection { get; private set; }

    //Private Defined
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    //Calls at the start of being loaded on frame 1
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Stops the rotation of character
        rb.freezeRotation = true;
        //        pauseMenu.enabled = false;
        GamePause = false;
    }

    //Calls every frame change
    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //For Rigidbody, does Physics every frame; might be a bit overkill since update will do the same thing at the expense of not being a Rigidbody, we're essentially hunting rabbits with cannons
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection != Vector2.zero)
        {
            LastMoveDirection = moveDirection;
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //Starts a Pause from Gameplay
    public void PauseGame()
    {
        PauseMenuBehaviour.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        //pauseMenu.enabled = true;
        Debug.Log("PauseGame called");
    }
    

    //Starts a Resume from Pause
    public void Resume()
    {
        //pauseMenu.enabled = true;
        PauseMenuBehaviour.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        Debug.Log("Resume called");
    }
    //Sends the player to the Main Menu
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu loaded");
    }
}
