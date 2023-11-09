using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverride : MonoBehaviour
{
    private Animator[] animators;
    public SpriteRenderer holdItem;
    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
    }

}
