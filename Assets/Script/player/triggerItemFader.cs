using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerItemFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemFader[] faders= collision.GetComponentsInChildren<itemFader>();
        if (faders.Length>0)
        {
            foreach (var item in faders)
            {
                item.fadeOut();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemFader[] faders = collision.GetComponentsInChildren<itemFader>();
        if (faders.Length > 0)
        {
            foreach (var item in faders)
            {
                item.fadeIn();
            }
        }
    }
}
