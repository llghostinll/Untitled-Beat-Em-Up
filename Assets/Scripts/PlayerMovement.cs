using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float movementSpeedMultiplier = 1.5f;
    public float dashSpeed = 1.05f;
    public float runSpeed = 2.0f;

    private bool isDashing = false;
    public float dashCooldown = 0.5f;

    private Rigidbody2D rb;
    private Vector2 vectorMovement;

    public bool isFacingRight = true;

    Animator animator;

    // Test purpose props
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vectorMovement.x = Input.GetAxisRaw("Horizontal");
        vectorMovement.y = Input.GetAxisRaw("Vertical");
        Flip();

        Run();
        StartCoroutine(Dash());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vectorMovement * movementSpeed * Time.fixedDeltaTime);

        float xVel = Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"));
        if (xVel > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //sr.color = Color.yellow;
            animator.SetBool("isRunning", true);
            movementSpeed *= runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //sr.color = Color.white;
            animator.SetBool("isRunning", false);
            movementSpeed /= runSpeed;
        }
    }

    IEnumerator Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            movementSpeed *= dashSpeed;
            sr.color = Color.blue;
            isDashing = true;

            yield return new WaitForSeconds(dashSpeed);

            movementSpeed /= dashSpeed;
            sr.color = Color.white;
            StartCoroutine(DashCooldown());
        }
    }

    IEnumerator DashCooldown()
    {
        while (isDashing)
        {
            sr.color = Color.cyan;
            yield return new WaitForSeconds(dashCooldown);
            sr.color = Color.white;
            isDashing = false;
            break;
        }
    }

private void Flip()
    {
        if (vectorMovement.x == -1 && isFacingRight)
        {
            isFacingRight = false;
            transform.Rotate(0, 180, 0);
            return;
        }

        if (vectorMovement.x == 1 && !isFacingRight)
        {
            isFacingRight = true;
            transform.Rotate(0, 180, 0);
            return;
        }

    }

}
