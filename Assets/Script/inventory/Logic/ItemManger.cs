using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Invetory
{
    public class ItemManger : MonoBehaviour
    {
        public Item itemPrefab;
        private Transform itemParent;

      
        private void OnEnable()
        {
            EventHandler.InstanceItemScense += OnInstantiateItemSence;
            EventHandler.afterSceneUnloadEvent += OnafterSceneUnloadEvent;
        }
        private void OnDisable()
        {
            EventHandler.InstanceItemScense -= OnInstantiateItemSence;
            EventHandler.afterSceneUnloadEvent -= OnafterSceneUnloadEvent;
        }

        private void OnafterSceneUnloadEvent()
        {
            itemParent = GameObject.FindWithTag("ItemParent").transform;
        }

        /// <summary>
        /// 在指定坐标生成物体
        /// </summary>
        /// <param name="Id">物品坐标</param>
        /// <param name="pos">时间坐标</param>
        private void OnInstantiateItemSence(int Id, Vector3 pos)
        {
            var item = Instantiate(itemPrefab, pos, Quaternion.identity, itemParent);
            item.itemID = Id;
        }
    }

}
