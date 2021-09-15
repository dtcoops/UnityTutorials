using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    [SerializeField]
    Transform hoursPivot2, minutesPivot2, secondsPivot2;

    const float hoursToDegrees = -30f;
    const float minutesToDegrees = -6f;
    const float secondsToDegrees = -6f;

    private void Update()
    {
        // Digital style
        /*
        var time = DateTime.Now;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(hoursToDegrees * time.Hour));
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(minutesToDegrees * time.Minute));
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(secondsToDegrees * time.Second));
        */

        // Analog
        DateTime timeUTC = DateTime.UtcNow;
        DateTime time = timeUTC.ToLocalTime();
        
        TimeSpan localTime = time.ToLocalTime().TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(hoursToDegrees * localTime.TotalHours));
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(minutesToDegrees * localTime.TotalMinutes));
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(secondsToDegrees * localTime.TotalSeconds));

        // Implement multiple clocks
        TimeSpan utcTime = DateTime.UtcNow.TimeOfDay;
        hoursPivot2.localRotation = Quaternion.Euler(0f, 0f, (float)(hoursToDegrees * utcTime.TotalHours));
        minutesPivot2.localRotation = Quaternion.Euler(0f, 0f, (float)(minutesToDegrees * utcTime.TotalMinutes));
        secondsPivot2.localRotation = Quaternion.Euler(0f, 0f, (float)(secondsToDegrees * utcTime.TotalSeconds));

        //DateTime test2 = new DateTime() + time;
        //Debug.Log(utcTime);

    }
}
