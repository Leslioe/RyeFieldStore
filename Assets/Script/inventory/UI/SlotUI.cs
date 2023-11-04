using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MFarm.Invetory {
    public class SlotUI : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        //��ʵ����Ϸ�����У�������ק��ʽ��ȡ������ͨ����ǩ���ȷ�����ȡ��Ч��Ҫ��
        [Header("�����ȡ")]//header��Ϊ��inspector���ڸ����
        [SerializeField] private Image slotImage;//ʹ��˽�б����ܹ���inspector���ڱ���ֵ
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] public Image slotHeightLight;
        [SerializeField] private Button button;
        [Header("��������")]
        public SlotType slotType;
        public bool isSelected;
        //��Ʒ��Ϣ
        public ItemDetails itemDetails;
        public int itemAmount;
        public int slotIndex;
        private InventoryUi inventoryUi => GetComponentInParent<InventoryUi>();
        /// <summary>
        /// ��slot����Ϊ��
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
            slotImage.enabled =false;
            button.interactable = false;
           
        }
        public void updateSlot(ItemDetails item, int amount)
        {
            itemDetails = item;
            slotImage.sprite = itemDetails.itemIcon;
            itemAmount = amount;
            amountText.text = amount.ToString();
            button.interactable = true;
            slotImage.enabled =true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (itemAmount==0)
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
            Debug.Log(eventData.pointerCurrentRaycast.gameObject);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (itemAmount!=0)
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

