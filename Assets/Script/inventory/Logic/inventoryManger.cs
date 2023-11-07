using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{

    public class inventoryManger : Singleton<inventoryManger>
    {
        [Header("物体数据")]
        public ItemDataList_SO itemDataList_SO;
        [Header("背包数据")]
        public InventoryBag_SO playerBag;
        private void Start()
        {
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }
        public ItemDetails GetItemDetails(int ID)//这个get方法会在item.cs使用用于在地图生成物体
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }
        public void AddItem(Item item, bool toDestory)//add方法在pickup中使用，实现为背包物体添加数据
        {
            //背包是否有空位，或者已经有该物体
            var index = GetItemIndexInBag(item.itemID);

            AddItemAtIndex(item.itemID, index, 1);
            Debug.Log(item.itemDetails.itemID + item.itemDetails.itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
            //更新ui
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }
        /// <summary>
        /// 检查背包是否还有空位
        /// </summary>
        private bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == 0)
                {
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// 去寻找背包中相同物体的下标
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private int GetItemIndexInBag(int Id)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == Id)
                {
                    return i;
                }

            }
            return -1;
        }
        private void AddItemAtIndex(int ID, int index, int amount)
        {
            if (index == -1 && CheckBagCapacity())
            {
                var item = new InventoryItem { itemID = ID, itemAmount = amount };
                for (int i = 0; i < playerBag.itemList.Count; i++)
                {
                    if (playerBag.itemList[i].itemID == 0)
                    {
                        playerBag.itemList[i] = item;
                        break;
                    }

                }
            }
            else
            {
                int currenAmount = playerBag.itemList[index].itemAmount + amount;
                var item = new InventoryItem { itemID = ID, itemAmount = currenAmount };
                playerBag.itemList[index] = item;
            }
        }
       /// <summary>
       /// player背包范围内交换物体，在这里订阅了event handler里的事件
       /// </summary>
       /// <param name="fromIndex">起始序号</param>
       /// <param name="targetIndex">目标序号</param>
        public void SwapItem(int fromIndex, int targetIndex)//根据在slot ui得到的下标去取得数据
        {
            InventoryItem currentItem = playerBag.itemList[fromIndex];
            InventoryItem targetItem = playerBag.itemList[targetIndex];
            if (targetItem.itemID != 0)
            {
                playerBag.itemList[fromIndex] = targetItem;
                playerBag.itemList[targetIndex] = currentItem;
            }
            else
            {
                playerBag.itemList[targetIndex] = currentItem;
                playerBag.itemList[fromIndex] = new InventoryItem();
            }
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);

        }
    }
    
}
