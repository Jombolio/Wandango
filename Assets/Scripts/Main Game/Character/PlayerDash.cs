using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    //Public Defined
    public float dashSpeed = 20f; // Dash speed
    public float dashDuration = 0.2f; // How long to dash
    public float dashCooldown = 10f; // Cooldown Time


    //Private Defined
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer;
    private float cooldownTimer;
    private TrailRenderer trail;

    //Calls at the start of being loaded on frame 1
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        cooldownTimer = dashCooldown;
        trail.time = dashDuration;
    }

    //Calls every frame change
    void Update()
    {
        if(!isDashing) {
            trail.emitting = false;
        } else {
            trail.emitting = true;
        }
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
