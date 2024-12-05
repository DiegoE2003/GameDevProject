using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChangerNPC : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentStateNPC = "Idle";

    public void ChangeAnimationStateNPC(string newState, float speed = 1f){
    
        if (currentStateNPC == newState) return;

        animator.speed = speed;
        currentStateNPC = newState;
        animator.Play(currentStateNPC);
    }
}
