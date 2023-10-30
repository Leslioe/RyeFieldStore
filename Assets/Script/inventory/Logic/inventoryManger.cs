using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{
    public class inventoryManger : Singleton<inventoryManger>
    {
        public ItemDataList_SO itemDataList_SO;
        public ItemDetails GetItemDetails(int ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }
        public void AddItem(Item item, bool toDestory)
        {
            Debug.Log(item.itemDetails.itemID+item.itemDetails.itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
