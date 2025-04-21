using TMPro;
using UnityEngine;

public class TimerLogic : MonoBehaviour
{
    public TextMeshProUGUI countdownTimer;
    public float intialTime = 0f;
    public float remainingTime;
    public int sec;

    private void Awake()
    {
        remainingTime = intialTime;
    }

    private void Update()
    {
       remainingTime += Time.deltaTime;

       int minutes = Mathf.FloorToInt(remainingTime / 60);
       int seconds = Mathf.FloorToInt(remainingTime % 60);

        sec = seconds;

       countdownTimer.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }
}
