using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public bool isMovingRight = true;

    private Rigidbody2D _rb;
    private Vector2 _vectorMovement;
    private Vector2 _startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 5.0f)
        {
            transform.position += new Vector3(movementSpeed * Time.fixedDeltaTime, 0, 0);        
        } else
        {
            transform.position += new Vector3(-movementSpeed * Time.fixedDeltaTime, 0, 0);
        }

    }

    void HandleMovement()
    {
        if(transform.position.x > 5.0f && isMovingRight)
        {
            transform.position += new Vector3(movementSpeed * Time.fixedDeltaTime, 0, 0);
        }
    }
}
