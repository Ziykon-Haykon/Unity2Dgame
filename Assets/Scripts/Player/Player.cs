using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    [SerializeField] private float speed = 5f;

    private float minMovingSpeed = 0.1f;
    private bool IsRunning = false;




    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += Player_OnPlayerAttack;
    }

    private void Player_OnPlayerAttack(object sender, EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }

    private void Update()
    {
        Vector2 InputVector = GameInput.Instance.GetMoveVector();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    private void HandleMovement()
    {
        Vector2 InputVector = GameInput.Instance.GetMoveVector();
        // Normalize the input vector to ensure consistent speed in all directions
        InputVector.Normalize();
        rb.MovePosition(rb.position + InputVector * (speed * Time.deltaTime));

        if (Mathf.Abs(InputVector.x) > minMovingSpeed || Mathf.Abs(InputVector.y) > minMovingSpeed)
        {
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }

    }

    public bool isRunning()
    {
        return IsRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 PlayerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return PlayerScreenPosition;
    }
}
