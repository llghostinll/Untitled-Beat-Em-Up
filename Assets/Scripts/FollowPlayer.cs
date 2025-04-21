using System;
using TreeEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    public float movementSpeed = 1f;

    SpriteRenderer _sr;
    Rigidbody2D _rb;
    public float _distFromTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        _distFromTarget = Mathf.Sign(target.transform.position.x - transform.position.x);
        Flip();
    }

     void Flip()
     {
        GameObject attackPoint = GameObject.Find("Attack Point");

        if (_distFromTarget == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            return;
        }

        if (_distFromTarget == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            return;
        }
     }

}


