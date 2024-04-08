using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public GameObject sunLight;

    //Time Management
    public int hour = 6;
    public int minutes = 00;
    private float seconds = 0;
    public int timePassage = 1;
    private int savedTimePassage;

    //Time Display
    public string displayTime;
    public bool am = true;
    private float radius = 100;
    private float time;
    private float wholeTime;

    //Day Management
    public int curDay = 1;
    public int year = 1;
    public int totalDays = 1;
    private string[] days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    public string currentDay;
    public int dayValue = 0;
    public bool progressingDay = false;

    //Season Management
    private string[] seasons = new string[] { "Spring", "Summer", "Fall", "Winter" };
    public string currentSeason;
    private int seasonValue = 0;
    public int maxDayInSeason = 30;

    private void Start()
    {
        //Set Starter Season
        currentSeason = seasons[seasonValue];
        //Set Starter Day
        currentDay = seasons[dayValue];
    }

    private void Update()
    {
        //Sun Rotation
        wholeTime = (minutes / 60f) + hour;
        time = (wholeTime / 24f);
        //time = (hour / 24f);
        float sunAngle = time * 360 - 90;
        Vector3 midpoint = transform.position; midpoint.y -= 0.5f;
        sunLight.transform.position = midpoint + Quaternion.Euler(0, 0, sunAngle) * (radius * Vector3.right);
        sunLight.transform.LookAt(midpoint);

        //Time Display
        if (am)
        {
            if (hour != 0)
            {
                displayTime = (hour.ToString("00") + " : " + minutes.ToString("00") + " AM");
            }
            if (hour == 0)
            {
                int shownHour;
                shownHour = 12;
                displayTime = (shownHour.ToString("00") + " : " + minutes.ToString("00") + " AM");
            }
        }
        if (!am)
        {
            if (hour > 12)
            {
                int shownHour;
                shownHour = hour - 12;
                displayTime = (shownHour.ToString("00") + " : " + minutes.ToString("00") + " PM");
            }
            if (hour == 12)
            {
                displayTime = (hour.ToString("00") + " : " + minutes.ToString("00") + " PM");
            }
        }
        if (hour >= 12)
        {
            am = false;
        }
        else
        {
            am = true;
        }
        //Time Progression
        seconds += timePassage * Time.deltaTime;

        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }
        if (minutes >= 60)
        {
            minutes = 0;
            hour++;
        }
        if (hour >= 24)
        {
            hour = 0;
        }

        if (hour == 0 && minutes == 0 && progressingDay == false)
        {
            progressingDay = true;
            ProgressDay();
        }
        if (hour != 0 && minutes != 0 && progressingDay == true)
        {
            progressingDay = false;
        }

        //Season Management
        currentSeason = seasons[seasonValue];

        if (curDay > maxDayInSeason)
        {
            NextSeason();
        }

        //Day Management
        currentDay = days[dayValue];
    }

    void NextSeason()
    {
        curDay = 1;
        if (seasonValue == 3)
        {
            seasonValue = 0;
            year++;
        }
        else
        {
            seasonValue++;
        }
    }

    public void ProgressDay()
    {
        curDay++;
        totalDays++;

        if (dayValue == 6)
        {
            dayValue = 0;
        }
        else
        {
            dayValue++;
        }
    }

    public void PauseTimePassage()
    {
        savedTimePassage = timePassage;
        timePassage = 0;
    }

    public void ResumeTimePassage()
    {
        timePassage = savedTimePassage;
    }
}
