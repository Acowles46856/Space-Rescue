using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float tiltAmount = 12f;
    public float tiltSpeed = 5f;

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            // Forward
            if (Keyboard.current.wKey.isPressed ||
                Keyboard.current.upArrowKey.isPressed)
            {
                input.y += 1;
            }

            // Backward
            if (Keyboard.current.sKey.isPressed ||
                Keyboard.current.downArrowKey.isPressed)
            {
                input.y -= 1;
            }

            // Left
            if (Keyboard.current.aKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed)
            {
                input.x -= 1;
            }

            // Right
            if (Keyboard.current.dKey.isPressed ||
                Keyboard.current.rightArrowKey.isPressed)
            {
                input.x += 1;
            }
        }

        // 8-direction movement
        Vector3 movement = new Vector3(input.x, 0f, input.y).normalized;

        transform.Translate(
            movement * moveSpeed * Time.deltaTime,
            Space.World
        );

        // Smooth banking/tilting
        float targetTilt = -input.x * tiltAmount;

        Quaternion targetRotation =
            Quaternion.Euler(0f, 0f, targetTilt);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            tiltSpeed * Time.deltaTime
        );

        // Reset if player falls off map
        if (transform.position.y < -5f)
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}