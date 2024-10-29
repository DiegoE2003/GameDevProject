using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChangerNPC : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentStateNPC = "Idle";

     void Start(){
        
    }
     public void ChangeAnimationStateNPC(string newState, float speed = 1){
        //Debug.Log("What the sigma called this?");
        animator.speed = speed;
        //Debug.Log("Bruh yyyyyyy?");
        currentStateNPC = newState;
        animator.Play(currentStateNPC);
    }
}
