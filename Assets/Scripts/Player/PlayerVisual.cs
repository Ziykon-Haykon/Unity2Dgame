using UnityEngine;
using UnityEngine.InputSystem;
using Platformer2D.Utils;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.isRunning());
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePosition = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();

        if (mousePosition.x > playerPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
