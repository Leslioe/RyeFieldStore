using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchBounds : MonoBehaviour
{
    //Todo:�л�������ʹ��
    private void Start()
    {
        switchConfinerShape();
    }
    private void switchConfinerShape()
    {
        PolygonCollider2D confinerShape = GameObject.FindGameObjectWithTag("boundsConfiner").GetComponent<PolygonCollider2D>();
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        confiner.m_BoundingShape2D = confinerShape;
        //�������������ÿ���л�������ʱ����������߽绺��
        confiner.InvalidatePathCache();
    }
}
