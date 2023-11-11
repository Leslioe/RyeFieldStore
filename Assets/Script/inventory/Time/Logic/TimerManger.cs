using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManger : MonoBehaviour
{
    private int gameSecond, gameMinute, gameHour, gameDay, gameMouth, gameYear;
    private Season gameSeason = Season.´ºÌì;
    private int mouthInSeason = 3;
    public bool gameClockPause;
    private float tikTime;
    private void Awake()
    {
        NewGametime();
    }
    private void Start()
    {
        EventHandler.callGameDateEvent(gameHour, gameDay, gameMouth, gameYear, gameSeason);
        EventHandler.callGameMinuteEvent(gameMinute, gameHour);
    }
    private void Update()
    {
        if (!gameClockPause)
        {
            tikTime += Time.deltaTime;
            if (tikTime >= Settings.secondThreshold)
            {
                tikTime -= Settings.secondThreshold;
                updateGameTime();
            }
        }
        if (Input.GetKey(KeyCode.T))
        {
            for (int i = 0; i < 60; i++)
            {
                updateGameTime();
            }
        }
    }
    private void NewGametime()
    {
        gameSecond = 0;
        gameMinute = 0; gameHour = 7; gameDay = 1; gameMouth = 1; gameYear = 2022;

    }
    private void updateGameTime()
    {
        gameSecond++;
        if (gameSecond > Settings.secondHold)
        {
            gameMinute++;
            gameSecond = 0;
            if (gameMinute > Settings.minuteHold)
            {
                gameMinute = 0;
                gameHour++;
                if (gameHour > Settings.hourHold)
                {
                    gameDay++;
                    gameHour = 0;
                    if (gameDay > Settings.dayHold)
                    {
                        gameMouth++;
                        gameDay = 1;
                        if (gameMouth > 12)
                            gameMouth = 1;
                        mouthInSeason--;
                        if (mouthInSeason == 0)
                        {
                            mouthInSeason = 3;
                            int seasonNumber = (int)gameSeason; seasonNumber++;
                            if (seasonNumber > Settings.seasonHold)
                            {
                                seasonNumber = 0;
                                gameYear++;
                            }
                            gameSeason = (Season)seasonNumber;
                            if (gameYear > 9999)
                            {
                                gameYear = 2023;
                            }
                        }

                    }
                   
                }
                EventHandler.callGameDateEvent(gameHour, gameDay, gameMouth, gameYear, gameSeason);
            }
            EventHandler.callGameMinuteEvent(gameMinute, gameHour);
        }
        //  Debug.Log(gameSecond+"kongge"+gameMinute);
    }

}
