using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 720f;
    public Transform cam;
    public FloatingJoystick joystick; // Add this!

    private CharacterController controller;
    private Vector3 direction;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        Vector3 inputDirection = new Vector3(h, 0, v).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            direction = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(direction.normalized * speed * Time.deltaTime);
        }
    }
}
