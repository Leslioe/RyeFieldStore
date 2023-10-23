using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchBounds : MonoBehaviour
{
    //Todo:切换场景后使用
    private void Start()
    {
        switchConfinerShape();
    }
    private void switchConfinerShape()
    {
        PolygonCollider2D confinerShape = GameObject.FindGameObjectWithTag("boundsConfiner").GetComponent<PolygonCollider2D>();
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        confiner.m_BoundingShape2D = confinerShape;
        //下面这个方法在每次切换场景的时候用于清楚边界缓存
        confiner.InvalidatePathCache();
    }
}
