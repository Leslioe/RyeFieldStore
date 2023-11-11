using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class TimeUi : MonoBehaviour
{
    public RectTransform dayNightIamge;
    public RectTransform clockParent;
    public Image seasonImage;
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI timeText;
    public Sprite[] seasonSptites;
    private List<GameObject> clockBlocks = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < clockParent.childCount; i++)
        {
            clockBlocks.Add(clockParent.GetChild(i).gameObject);
            clockParent.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        EventHandler.GameMinuteEvent += OnGameMinuteEvent;
        EventHandler.GameDateEvent += OnGameDateEvent;
    }
    private void OnDisable()
    {
        EventHandler.GameMinuteEvent -= OnGameMinuteEvent;
        EventHandler.GameDateEvent -= OnGameDateEvent;
    }

    private void OnGameMinuteEvent(int minute, int hour)
    {
        timeText.text = hour.ToString("00") + ":" + minute.ToString("00");
    }

    private void OnGameDateEvent(int hour, int day, int month, int year, Season season)
    {
        dataText.text = year + "年" + month.ToString("00") + "月" + day.ToString("00") + "日";
        seasonImage.sprite = seasonSptites[(int)season];
        SwitchHour(hour);
        DayNightImageRotate(hour);
    }/// <summary>
    /// 根据时间切换小时块
    /// </summary>
    /// <param name="hour"></param>
    private void SwitchHour(int hour)
    {
        int index = hour / 4;
        if (index==0)
        {
            foreach (var item in clockBlocks)
            {
                item.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < clockBlocks.Count; i++)
            {
                if (i<index+1)
                {
                    clockBlocks[i].SetActive(true);
                }
                else
                {
                    clockBlocks[i].SetActive(false);
                }
            }
        }
    }
    private void DayNightImageRotate(int hour)
    {
        var target = new Vector3(0, 0, hour * 15-90);
        dayNightIamge.DORotate(target, 1f, RotateMode.Fast);
    }
}
