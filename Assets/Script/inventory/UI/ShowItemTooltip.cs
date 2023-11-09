using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MFarm.Invetory
{
    [RequireComponent(typeof(SlotUI))]
    public class ShowItemTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private SlotUI slotUI;
        private InventoryUi inventoryUi => GetComponentInParent<InventoryUi>();
        private void Awake()
        {
            slotUI = GetComponent<SlotUI>();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (slotUI.itemAmount != 0)
            {//为什么不在这里直接引入itemtoollip去调用方法，而是在slotui里去定义
                inventoryUi.itemToolLip.gameObject.SetActive(true);
                inventoryUi.itemToolLip.SetupToolTip(slotUI.itemDetails, slotUI.slotType);
                inventoryUi.itemToolLip.transform.position = transform.position + Vector3.up * 60;
            }
            else
            {
                inventoryUi.itemToolLip.gameObject.SetActive(false);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            inventoryUi.itemToolLip.gameObject.SetActive(false);
        }
       
        // Start is called before the first frame update

    }
}
