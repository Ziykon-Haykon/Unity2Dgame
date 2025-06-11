using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMoveVector()
    {
        Vector2 InputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return InputVector.normalized; // Normalize to ensure consistent speed
    }
}
