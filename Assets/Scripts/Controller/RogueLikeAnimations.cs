using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueLikeAnimations : MonoBehaviour
{
    protected Animator animator;
    protected RogueLikeCharacterController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<RogueLikeCharacterController>();
    }
}
