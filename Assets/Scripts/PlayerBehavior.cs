using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D bc;
    Vector2 MoveVector;
    [SerializeField] float MoveSpeed = 20f, JumpForce = 50f, MaxSpeed = 10f;
    PlayerControls controls;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MoveVector = controls.Player.Move.ReadValue<Vector2>();
        if (MoveVector == new Vector2(0, 0))
        {
            anim.SetBool("Running", false);
        }
        else if (MoveVector.x > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("Running", true);
        }
        else
        {
            spriteRenderer.flipX = true;
            anim.SetBool("Running", true);
        }

        if (controls.Player.Jump.WasPerformedThisFrame())
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        anim.SetBool("isGrounded", IsGrounded());
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(MoveVector * MoveSpeed);
        if (rb.velocity.x > MaxSpeed)
        {
            rb.velocity = new(MaxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -MaxSpeed)
        {
            rb.velocity = new(-MaxSpeed, rb.velocity.y);
        }
    }

    [SerializeField] LayerMask platform;

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(bc.bounds.center.x, bc.bounds.center.y - 0.2f), bc.size * 0.8f, 0, Vector2.down, 0.1f, platform);
        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
