using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MFarm.Invetory
{
    public class InventoryUi : MonoBehaviour
    {
        [Header("��קͼƬ")]
        public Image dragItem;

        [Header("��ұ���ui")]
        [SerializeField] private GameObject bagUI;
        private bool bagOpend;
        [SerializeField] private SlotUI[] playerSlots;
        private void OnEnable()//�������¼�
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
        /// �򿪱���ui��button�����¼�
        /// </summary>
        public void OpenBagUI()
        {
            bagOpend = !bagOpend;
            bagUI.SetActive(bagOpend);
        }
        /// <summary>
        /// ����slot����ѡ��
        /// </summary>
        /// <param name="index">���</param>
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
