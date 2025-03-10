using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float torqueAmount = 2f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    float playerXInput;
    float playerYInput;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    bool canBoost = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }
    void Update()
    {
        if (canMove)
        {
            Rotate();
            if (canBoost)
            {
                Boost();
            }
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }
    public void DisableBoost()
    {
        canBoost = false;
    }
    public void EnableBoost()
    {
        canBoost = true;
    }
    void Rotate()
    {
        rb2d.AddTorque(-playerXInput * torqueAmount);
    }
    void Boost()
    {
        surfaceEffector2D.speed = playerYInput > 0 ? boostSpeed : baseSpeed;
        surfaceEffector2D.forceScale = playerYInput > 0 ? (float)0.05 : (float)0.02;
    }
    public void Stop()
    {
        StartCoroutine(SlowDown());
    }
    IEnumerator SlowDown()
    {
        float duration = 1.5f; // Time in seconds to fully stop
        float startSpeed = surfaceEffector2D.speed;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            surfaceEffector2D.speed = Mathf.Lerp(startSpeed, 0, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        surfaceEffector2D.speed = 0; // Ensure it fully stops
    }
    void OnMove(InputValue value)
    {
        playerYInput = value.Get<Vector2>().y;
        playerXInput = value.Get<Vector2>().x;
    }
}
