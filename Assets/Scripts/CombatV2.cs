using UnityEngine;
using System.Collections;

public class CombatV2 : MonoBehaviour
{
    Animator _animator;

    // Timer Properties
    private bool timerActive = false;
    private float timer = 0f;
    public float timeLimit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PunchComboIntiate();
    }

    void PunchComboIntiate()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(!timerActive)
            {
                StartCoroutine(PunchOne());
            } else
            {
                StartCoroutine(PunchTwo());
            }
        }

        Timer();
    }

    IEnumerator PunchOne()
    {
        _animator.SetBool("isPunchOne", true);
        timerActive = true;
        timer = 0f;
        yield return new WaitForSeconds(0.75f);
        _animator.SetBool("isPunchOne", false);
    }

    IEnumerator PunchTwo()
    {
        _animator.SetBool("isPunchOne", false);
        _animator.SetBool("isPunchTwo", true);
        timerActive = false;
        yield return new WaitForSeconds(0.75f);
        _animator.SetBool("isPunchTwo", false);
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
