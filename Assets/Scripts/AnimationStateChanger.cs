using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{   
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";
    void Start(){
        ChangeAnimationState("Idle");
    }

    public void ChangeAnimationState(string newState, float speed = 1){
        animator.speed = speed;
        
        if(currentState == newState){
            //Debug.Log("Bruh");
            animator.Play("Idle");
            animator.Play(newState,0,0.0f);
        }
        currentState=newState;
        //Debug.Log(currentState + "Playing new Animation");
        animator.Play(currentState);
        
    }
}
