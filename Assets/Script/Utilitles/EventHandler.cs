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
}
