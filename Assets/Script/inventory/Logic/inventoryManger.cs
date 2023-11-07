using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{

    public class inventoryManger : Singleton<inventoryManger>
    {
        [Header("��������")]
        public ItemDataList_SO itemDataList_SO;
        [Header("��������")]
        public InventoryBag_SO playerBag;
        private void Start()
        {
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }
        public ItemDetails GetItemDetails(int ID)//���get��������item.csʹ�������ڵ�ͼ��������
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }
        public void AddItem(Item item, bool toDestory)//add������pickup��ʹ�ã�ʵ��Ϊ���������������
        {
            //�����Ƿ��п�λ�������Ѿ��и�����
            var index = GetItemIndexInBag(item.itemID);

            AddItemAtIndex(item.itemID, index, 1);
            Debug.Log(item.itemDetails.itemID + item.itemDetails.itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
            //����ui
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }
        /// <summary>
        /// ��鱳���Ƿ��п�λ
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
        /// ȥѰ�ұ�������ͬ������±�
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
       /// player������Χ�ڽ������壬�����ﶩ����event handler����¼�
       /// </summary>
       /// <param name="fromIndex">��ʼ���</param>
       /// <param name="targetIndex">Ŀ�����</param>
        public void SwapItem(int fromIndex, int targetIndex)//������slot ui�õ����±�ȥȡ������
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
