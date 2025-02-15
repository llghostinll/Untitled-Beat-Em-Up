using System.Collections;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private CapsuleCollider2D attackCollider;
    private SpriteRenderer sprite;
    public float hitDurtation = 1f;
    public bool isUsingKick = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackCollider = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        attackCollider.enabled = false;
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
