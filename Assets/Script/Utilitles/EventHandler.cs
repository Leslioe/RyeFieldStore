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
}
