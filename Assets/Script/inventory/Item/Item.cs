using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{
    public class Item : MonoBehaviour
    {
        public int itemID;
        private SpriteRenderer spriteRenderer;
        public ItemDetails itemDetails;
        private BoxCollider2D coll;
        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            coll = GetComponent<BoxCollider2D>();
        }
        private void Start()
        {
            if (itemID!=0)
            {

            }
            Init(itemID);//����ֻ��Ҫ��itemid��ֵ�����ֱ�ӳ�ʼ��
        }
        public void Init(int Id)
        {
            itemID = Id;
            itemDetails = inventoryManger.Instance.GetItemDetails(itemID);
            if (itemDetails!=null)
            {
                spriteRenderer.sprite = itemDetails.itemOnWorldSprite != null ? itemDetails.itemOnWorldSprite:itemDetails.itemIcon ;
                //�޸���ײ��ߴ��offset
                Vector2 newSize = new Vector2(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y);
                coll.size = newSize;
                coll.offset = new Vector2(0, spriteRenderer.sprite.bounds.center.y);
            }
        }
    }

}
