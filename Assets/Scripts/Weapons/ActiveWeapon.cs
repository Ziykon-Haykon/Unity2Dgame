using Unity.Mathematics;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public static ActiveWeapon Instance { get; private set; }

    [SerializeField] private Sword sword;

    private void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        RotateToMouse();
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }

    private void RotateToMouse()
    {
        Vector3 mouseScreenPosition = GameInput.Instance.GetMousePosition();
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 direction = (mouseWorldPosition - Player.Instance.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Зеркалирование по Y, если угол больше 90 или меньше -90
        if (angle > 90f || angle < -90f)
            transform.localScale = new Vector3(1, -1, 1);
        else
            transform.localScale = Vector3.one;
    }
}
