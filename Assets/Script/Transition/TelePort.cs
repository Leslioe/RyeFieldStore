using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFarm.Transtion
{
    public class TelePort : MonoBehaviour
    {
        public string sceneTogo;
        public Vector3 positionTogo;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log(1);
                EventHandler.callTransitionEvent(sceneTogo, positionTogo);
            }
        }
    }
}
