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
        /// ��ָ��������������
        /// </summary>
        /// <param name="Id">��Ʒ����</param>
        /// <param name="pos">ʱ������</param>
        private void OnInstantiateItemSence(int Id, Vector3 pos)
        {
            var item = Instantiate(itemPrefab, pos, Quaternion.identity, itemParent);
            item.itemID = Id;
        }
    }

}
