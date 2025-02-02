using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float movementSpeedMultiplier = 1.5f;
    public float dashSpeed = 1.05f;

    private bool isDashing = false;
    public float dashCooldownDuration = 5.0f;

    private Rigidbody2D rb;
    private Vector2 vectorMovement;

    // Test purpose props
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        vectorMovement.x = Input.GetAxisRaw("Horizontal");
        vectorMovement.y = Input.GetAxisRaw("Vertical");

        Run();
        StartCoroutine(Dash());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vectorMovement * movementSpeed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprite.color = Color.yellow;
            movementSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprite.color = Color.white;
            movementSpeed /= 2;
        }
    }

    IEnumerator Dash()
    {
        // When space bar is clicked, give a brief boost of speed
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            movementSpeed *= dashSpeed;
            sprite.color = Color.blue;
            isDashing = true;

            yield return new WaitForSeconds(0.3f);

            movementSpeed /= dashSpeed;
            sprite.color = Color.white;
            DashCoolDown();
        }

        // Indicate that dashing is happening through changing the demo players color to blue
        // Then, create a system that after the player dashed, they have to wait two seconds before using again
    }

    private void DashCoolDown()
    {
        float timer = 0f;

        while (dashCooldownDuration > timer) 
        {
            timer += Time.fixedDeltaTime;
            Debug.Log(timer);
        }

        isDashing = false;
    }

}
