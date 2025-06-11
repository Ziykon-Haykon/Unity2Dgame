using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5f;


    


    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    private void Update()
    {

        Vector2 InputVector = GameInput.Instance.GetMoveVector();
        // Normalize the input vector to ensure consistent speed in all directions
        InputVector.Normalize();
        rb.MovePosition(rb.position + InputVector * (speed * Time.deltaTime));


    }
}
