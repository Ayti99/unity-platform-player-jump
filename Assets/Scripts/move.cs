using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
public InputActionAsset inputActionAsset;

private InputActionMap _inputActionMap;
private InputAction _move;
private InputAction _jump;

private Rigidbody rb;

[Header("Movement")]
public float moveSpeed = 5f;

[Header("Jump")]
public float jumpForce = 7f;

[Header("Ground Check")]
public float groundCheckDistance = 0.6f;

void Start()
{
    rb = GetComponent<Rigidbody>();

    _inputActionMap = inputActionAsset.FindActionMap("Player");

    _move = _inputActionMap.FindAction("Move");
    _jump = _inputActionMap.FindAction("Jump");

    _inputActionMap.Enable();
}

void Update()
{
    bool isGrounded = Physics.Raycast(
        transform.position,
        Vector3.down,
        groundCheckDistance
    );

    if (_jump.WasPressedThisFrame() && isGrounded)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

void FixedUpdate()
{
    Vector2 joystickmove = _move.ReadValue<Vector2>();

    Vector3 realmovement = new Vector3(
        joystickmove.x,
        0,
        joystickmove.y
    );

    rb.linearVelocity = new Vector3(
        realmovement.x * moveSpeed,
        rb.linearVelocity.y,
        realmovement.z * moveSpeed
    );
}

}