using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text counterText;
    public Text txtEndTime;
    private float StartTime;
    private float EndTime;
    private bool finished = false;

    public Canvas CanvasTimer;
    public Canvas CanvasTimerEnd;

    void Start()
    {
        CanvasTimer.enabled = false;
        CanvasTimerEnd = CanvasTimerEnd.GetComponent<Canvas>();
        CanvasTimerEnd.enabled = false;
    }

    void OnTriggerEnter(Collider TriggerTime)
    {
        if (TriggerTime.CompareTag("Player"))
        {
            CanvasTimer.enabled = true;
            StartTime = Time.time;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (finished == true)
            return;

        float t = Time.time - StartTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        counterText.text = minutes + ":" + seconds;
    }

    void Finished()
    {
        CanvasTimer.enabled = false;
        CanvasTimerEnd.enabled = true;
        EndTime = Time.time;
        txtEndTime.text = "Twój czas to: " + EndTime;
    }
}
