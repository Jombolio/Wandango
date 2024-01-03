using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    //Public Defined
    public float dashSpeed = 20f; // INPUT_REQUIRED {specify dash speed value}
    public float dashDuration = 0.2f; // INPUT_REQUIRED {specify dash duration value}
    public float dashCooldown = 10f; // INPUT_REQUIRED {specify dash cooldown value}

    //Private Defined
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer;
    private float cooldownTimer;

    //Calls at the start of being loaded on frame 1
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        cooldownTimer = dashCooldown;
    }

    //Calls every frame change
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer >= dashCooldown && !isDashing)
            StartCoroutine(Dash());

        if (cooldownTimer < dashCooldown)
            cooldownTimer += Time.deltaTime;
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        playerMovement.enabled = false;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = new Vector2(playerMovement.LastMoveDirection.x * dashSpeed, playerMovement.LastMoveDirection.y * dashSpeed);
            yield return null;
        }

        rb.velocity = Vector2.zero;
        isDashing = false;
        playerMovement.enabled = true;
        cooldownTimer = 0f;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public float CooldownPercentage()
    {
        return cooldownTimer / dashCooldown;
    }
}
