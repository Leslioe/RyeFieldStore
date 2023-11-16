using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverride : MonoBehaviour
{
    private Animator[] animators;
    public SpriteRenderer holdItem;
    [Header("各部分动画")]
    public List<AnimatorType> animatorTypes;
    public Dictionary<string, Animator> animatorNameDict = new Dictionary<string, Animator>();
    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
        foreach (var anim in animators)
        {
            animatorNameDict.Add(anim.name, anim);
        }
    }
    private void OnEnable()
    {
        EventHandler.ItemSelectEvent += OnItemSelectEvent;
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
    }
    private void OnDisable()
    {
        EventHandler.ItemSelectEvent -= OnItemSelectEvent;
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        holdItem.enabled = false;
        switchAnimator(PartType.None);
    }

    private void OnItemSelectEvent(ItemDetails itemDetails, bool isSelected)
    {
        //不同工具返回不同动画
        PartType currentType = itemDetails.itemType switch
        {
            ItemType.Seed => PartType.Carry,
            ItemType.Commodity => PartType.Carry,
            _ => PartType.None
        };
        if (isSelected==false)
        {
            currentType = PartType.None;
            holdItem.enabled = false;
        }
        else
        {
            if (currentType==PartType.Carry)
            {
                Debug.Log(itemDetails.itemID);
                holdItem.sprite = itemDetails.itemOnWorldSprite;
                holdItem.enabled = true;
            }
           
        }
        switchAnimator(currentType);
    }
    private void switchAnimator(PartType parttype)
    {
        foreach (var item in animatorTypes)
        {
            if (item.partType==parttype)
            {
                animatorNameDict[item.partName.ToString()].runtimeAnimatorController = item.overrideController;
            }
        }
    }
}
