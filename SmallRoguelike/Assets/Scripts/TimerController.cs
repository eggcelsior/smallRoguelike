using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float startTime;
    public static TimerController instance;
    public float currentTime;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        /*string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("0");

        text.text = minutes + ":" + seconds;
        currentTime = (int)t;*/
    }
}
