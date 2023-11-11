using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{
    public class ItemManger : MonoBehaviour
    {
        public Item itemPrefab;
        private Transform itemParent;

        private void Start()
        {
            itemParent = GameObject.FindWithTag("ItemParent").transform;
        }
        private void OnEnable()
        {
            EventHandler.InstanceItemScense += OnInstantiateItemSence;
        }
        private void OnDisable()
        {
            EventHandler.InstanceItemScense -= OnInstantiateItemSence;
        }

        private void OnInstantiateItemSence(int Id, Vector3 pos)
        {
            var item = Instantiate(itemPrefab, pos, Quaternion.identity, itemParent);
            item.itemID = Id;
        }
    }

}
