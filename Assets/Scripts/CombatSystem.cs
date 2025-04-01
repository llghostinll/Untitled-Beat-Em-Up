using System.Collections;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private CapsuleCollider2D attackCollider;
    private SpriteRenderer sprite;
    private Animator animator;

    public float hitDurtation = 1f;
    public bool isUsingKick = false;

    public AnimationClip ani;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // attackCollider = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        /*
        attackCollider.enabled = false;
        sprite.enabled = false;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isUsingKick)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(Attack());
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine(Attack());
            }
        }
        */

        Punch();

    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J Hit");
            animator.Play("PunchOne");
        } 

    }

    private IEnumerator Attack()
    {

        attackCollider.enabled = true;
        sprite.enabled = true;

        yield return new WaitForSeconds(hitDurtation);

        attackCollider.enabled = false;
        sprite.enabled = false;
    }


}
