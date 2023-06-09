using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerComponent : MonoBehaviour
{
    public DataManagerScript dataManager;
    public TransientDataScript transientData;

    public int yearNumber;
    public int weekNumber;
    public int monthNumber;
    public int dayOfMonthNumber;
    public int dayOfWeekNumber;
    public float timeOfDayNormalised;

    private string years;
    private string ordinal;
    public string[] weekdayArray = new string[] { "Lunden", "Martiden", "Mercuiden", "Ioviden", "Venerden", "Saturiden", "Solden" };
    public string calendarOutputText;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        dataManager.timeOfDay += (Time.deltaTime / 300 * transientData.timeFlowSpeed) * Time.timeScale;

        yearNumber = (int)Mathf.Round((int)dataManager.totalGameDays / 336);

        monthNumber = (int)Mathf.Round((int)dataManager.totalGameDays / 28) % 12 + 1;

        weekNumber = dataManager.totalGameDays / 7 % 4 + 1;

        dayOfMonthNumber = (dataManager.totalGameDays % 28) + 1;

        dayOfWeekNumber = (dataManager.totalGameDays % 7);

        if (dataManager.timeOfDay > 1)
        {
            dataManager.timeOfDay = 0;
            dataManager.totalGameDays++;
        }

        timeOfDayNormalised = Mathf.Round(dataManager.timeOfDay * 24);

        if (dayOfMonthNumber == 1 || dayOfMonthNumber == 21)
            ordinal = "st";
        else if (dayOfMonthNumber == 2 || dayOfMonthNumber == 22)
            ordinal = "nd";
        else if (dayOfMonthNumber == 3 || dayOfMonthNumber == 23)
            ordinal = "rd";
        else if (dayOfMonthNumber >= 4)
            ordinal = "th";

        if (yearNumber == 1)
            years = "year";
        else
            years = "years";

        if (timeOfDayNormalised > 12)
        {
            calendarOutputText = $"{(DayOfWeek)dayOfWeekNumber}, {timeOfDayNormalised - 12} pm on the {dayOfMonthNumber}{ordinal}\nWeek {weekNumber} of month {monthNumber}\n{yearNumber} {years} in business";
        }
        else if (timeOfDayNormalised < 1)
        {
            calendarOutputText = $"{(DayOfWeek)dayOfWeekNumber}, 12 pm on the {dayOfMonthNumber}{ordinal}\nWeek {weekNumber} of month {monthNumber}\n{yearNumber} {years} in business";
        }
        else
        {
            calendarOutputText = $"{(DayOfWeek)dayOfWeekNumber}, {timeOfDayNormalised} am on the {dayOfMonthNumber}{ordinal}\nWeek {weekNumber} of month {monthNumber}\n{yearNumber} {years} in business";
        }

        //UPDATE CHANGES IN TRANSIENT DATA SCRIPT
        transientData.weekDay = (DayOfWeek)dayOfWeekNumber;
        transientData.date = dayOfMonthNumber;
        transientData.month = monthNumber;
        transientData.year = yearNumber;
    }
}
