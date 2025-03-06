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
            Boost();
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }
    void Rotate()
    {
        rb2d.AddTorque(-playerXInput * torqueAmount);
    }
    void Boost()
    {
        surfaceEffector2D.speed = playerYInput > 0 ? boostSpeed : baseSpeed;
    }
    void OnMove(InputValue value)
    {
        playerYInput = value.Get<Vector2>().y;
        playerXInput = value.Get<Vector2>().x;
    }
}
