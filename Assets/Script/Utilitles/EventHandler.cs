using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventHandler
{
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateInventoryUI;
    public static void CallUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        UpdateInventoryUI?.Invoke(location, list);
    }
    public static event Action<int, Vector3> InstanceItemScense;
    public static void CallInstanceItemScense(int ID, Vector3 pos)
    {
        InstanceItemScense?.Invoke(ID, pos);
    }
    public static event Action<ItemDetails, bool> ItemSelectEvent;
    public static void callItemSelectEvent(ItemDetails itemDetails,bool isSelected)
    {
        ItemSelectEvent?.Invoke(itemDetails, isSelected);
    }
    public static event Action<int, int> GameMinuteEvent;
    public static void callGameMinuteEvent(int minute,int hour)
    {
        GameMinuteEvent?.Invoke(minute, hour);
    }
    public static event Action<int, int, int, int, Season> GameDateEvent;
    public static void callGameDateEvent(int hour,int day,int month,int year,Season season)
    {
        GameDateEvent?.Invoke(hour, day, month, year, season);
    }
    public static event Action<string, Vector3> TransitionEvent;
    public static void callTransitionEvent(string sceneName,Vector3 pos)
    {
        TransitionEvent?.Invoke(sceneName, pos);
    }
    public static event Action BeforeSceneUnloadEvent;//场景卸载前需要执行的函数
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }
    public static event Action afterSceneUnloadEvent;//场景卸载后需要执行的函数
    public static void CallafterSceneUnloadEvent()
    {
        afterSceneUnloadEvent?.Invoke();
    }
    public static event Action<Vector3> movePosition;
    public static void CallmovePosition(Vector3 targetPosion)
    {
        movePosition?.Invoke(targetPosion);
    }
}
