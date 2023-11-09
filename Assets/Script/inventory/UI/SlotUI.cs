using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MFarm.Invetory
{
    public class SlotUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
       
        //在实际游戏开发中，利用拖拽方式获取物体会比通过标签名等方法获取的效益要好
        [Header("组件获取")]//header是为了inspector窗口更简介
        [SerializeField] private Image slotImage;//使得私有变量能够在inspector窗口被赋值
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] public Image slotHeightLight;
        [SerializeField] private Button button;
        [Header("格子类型")]
        public SlotType slotType;
        public bool isSelected;
        //物品信息
        public ItemDetails itemDetails;
        public int itemAmount;
        public int slotIndex;
        private InventoryUi inventoryUi => GetComponentInParent<InventoryUi>();
        /// <summary>
        /// 将slot更新为空
        /// </summary>
        private void Start()
        {
            isSelected = false;
            if (itemDetails.itemID == 0)
            {
                updateEmptySlot();
            }
        }
        public void updateEmptySlot()
        {
            if (isSelected)
            {
                isSelected = false;
            }
            slotImage.enabled = false;
            amountText.text = string.Empty;
            slotImage.enabled = false;
            button.interactable = false;

        }
        public void updateSlot(ItemDetails item, int amount)
        {
            itemDetails = item;
            slotImage.sprite = itemDetails.itemIcon;
            itemAmount = amount;
            amountText.text = amount.ToString();
            button.interactable = true;
            slotImage.enabled = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (itemAmount == 0)
            {
                return;
            }
            isSelected = !isSelected;
            slotHeightLight.gameObject.SetActive(isSelected);
            inventoryUi.UpdataSlotHightLight(slotIndex);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            inventoryUi.dragItem.enabled = false;
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotUI>() == null)
                {
                    return;
                }
                var targetSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotUI>();
                int targetIndex = targetSlot.slotIndex;
                if (slotType == SlotType.Bag && targetSlot.slotType == SlotType.Bag)
                {
                    inventoryManger.Instance.SwapItem(slotIndex, targetIndex);//inventorymanger是静态的，通过instance去调用
                }
                inventoryUi.UpdataSlotHightLight(-1);
            }
            //else
            //{
            //    {
            //        if (itemDetails.canCarried)
            //        {
            //            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));//摄像机在z轴方向有一个初始默认值
            //            EventHandler.CallInstanceItemScense(itemDetails.itemID, pos);
            //        }

            //    }

            //}
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (itemAmount != 0)
            {
                inventoryUi.dragItem.enabled = true;
                inventoryUi.dragItem.sprite = slotImage.sprite;
                inventoryUi.dragItem.SetNativeSize();

                isSelected = true;
                inventoryUi.UpdataSlotHightLight(slotIndex);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            inventoryUi.dragItem.transform.position = Input.mousePosition;
        }
    }
}

