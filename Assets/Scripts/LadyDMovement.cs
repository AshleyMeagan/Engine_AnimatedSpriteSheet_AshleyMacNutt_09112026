using UnityEngine;

public class LadyDMovement : MonoBehaviour
{
[SerializeField] private float moveSpeed = 5f;

private Rigidbody2D rb;
private SpriteRenderer spriteRenderer;
private Animator animator;
private Vector2 moveInput;

private void Awake()
{
rb = GetComponent<Rigidbody2D>();
spriteRenderer = GetComponent<SpriteRenderer>();
animator = GetComponent<Animator>();
}

private void Update()
{
float horizontal = Input.GetAxisRaw("Horizontal");
float vertical = Input.GetAxisRaw("Vertical");

moveInput = new Vector2(horizontal, vertical).normalized;

animator.SetBool("IsMoving", moveInput != Vector2.zero);
FlipLadyD();
}

private void FixedUpdate()
{
rb.MovePosition(rb.position +
moveInput * moveSpeed * Time.fixedDeltaTime);
}

private void FlipLadyD()
{
// This bat artwork faces left by default.
if (moveInput.x > 0)
spriteRenderer.flipX = false;
else if (moveInput.x < 0)
spriteRenderer.flipX = true;
}
}