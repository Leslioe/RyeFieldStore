using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MFarm.Invetory
{
    public class InventoryUi : MonoBehaviour
    {
        [Header("拖拽图片")]
        public Image dragItem;

        [Header("玩家背包ui")]
        [SerializeField] private GameObject bagUI;
        private bool bagOpend;
        [SerializeField] private SlotUI[] playerSlots;
        private void OnEnable()//订阅了事件
        {
            EventHandler.UpdateInventoryUI += OnUpdateInventoryUI;
        }
        private void OnDisable()
        {
            EventHandler.UpdateInventoryUI -= OnUpdateInventoryUI;
        }

     

        private void Start()
        {
            for (int i = 0; i < playerSlots.Length; i++)
            {
                playerSlots[i].slotIndex = i;
            }
            bagOpend = bagUI.activeInHierarchy;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                OpenBagUI();
            }
        }
        private void OnUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
        {
            switch (location)
            {
                case InventoryLocation.Player:
                    {
                        for (int i = 0; i < playerSlots.Length; i++)
                        {
                            if (list[i].itemAmount>0)
                            {
                                var item = inventoryManger.Instance.GetItemDetails(list[i].itemID);
                                playerSlots[i].updateSlot(item,list[i].itemAmount);
                            }
                            else
                            {
                                playerSlots[i].updateEmptySlot();
                            }
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// 打开背包ui，button调用事件
        /// </summary>
        public void OpenBagUI()
        {
            bagOpend = !bagOpend;
            bagUI.SetActive(bagOpend);
        }
        /// <summary>
        /// 更新slot高亮选择
        /// </summary>
        /// <param name="index">序号</param>
        public void UpdataSlotHightLight(int index)
        {
            foreach (var slot in playerSlots)
            {
                if (slot.isSelected&&slot.slotIndex==index)
                {
                    slot.slotHeightLight.gameObject.SetActive(true);
                }
                else
                {
                    slot.isSelected = false;
                    slot.slotHeightLight.gameObject.SetActive(false);
                }
            }
        }
    }
}
