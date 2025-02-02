using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float movementSpeedMultiplier = 1.5f;
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vectorMovement * movementSpeed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprite.color = Color.red;
            movementSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprite.color = Color.white;
            movementSpeed /= 2;
        }
    }

}
