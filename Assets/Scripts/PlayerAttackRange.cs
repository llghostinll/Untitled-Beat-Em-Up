using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    public bool isInAttackRange = false;
    public float weaponRange = 1f;
    public Transform attackPoint;
    public LayerMask playerLayer; 
    public float weaponDamage = 1f;

    private bool timerActive = false;
    private float timer = 0f;
    public float timeLimit;

    Animator _animator;
    public AudioSource m_CloverOuch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        m_CloverOuch = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isInAttackRange)
        {
            StartCoroutine(DamageAnimation());
        }
    }

    IEnumerator DamageAnimation()
    {
        _animator.SetBool("isEnemyAttack", true);
        yield return new WaitForSeconds(0.50f);
        _animator.SetBool("isEnemyAttack", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<FollowPlayer>().enabled = false;
            isInAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<FollowPlayer>().enabled = true;
            isInAttackRange = false;
        }
    }

    public void DealEnemyPunchDamage()
    {
        if (!isInAttackRange) return;

        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, weaponRange, playerLayer);
        if (enemy != null) 
        {
            m_CloverOuch.Play();
            enemy.GetComponent<HealthSystem>().DecereaseHealth(weaponDamage);
        }

    }

    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }

    void Timer()
    {
        if (!timerActive) return;

        timer += Time.fixedDeltaTime;
        if (timer >= timeLimit)
        {
            Debug.Log("Punch Combo Over");
            timerActive = false;
        }
    }
}



