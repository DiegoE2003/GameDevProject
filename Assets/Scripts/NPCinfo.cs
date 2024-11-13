using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class NPCinfo : MonoBehaviour
{
    [Header("Health Information")]
    [SerializeField] float currHealth; //current health of NPC as it takes damage
    [SerializeField] float totalHealth = 100.0f; //the beginning health of NPC
    [SerializeField] bool isDead = false; //if the NPC dies
    [Header("Movement Information")]
    [SerializeField] float NPCspeed = 5.0f; //how fast the NPC moves across the field
    [Header("Animation Information")]
    //[SerializeField] AnimationStateChangerNPC animation;
    [Header("HealthBar Information")]
    [SerializeField] HealthBar bar;
    [SerializeField] enemyAI ai;
    [SerializeField] double value = 0.5;
    void Start(){
        currHealth = totalHealth;
    }
     void OnTriggerEnter2D(Collider2D other){
      
        if(other.CompareTag("Sword")){
            
            if(other.offset.y >= 0.05 || other.offset.y >= 0.04){
                Debug.Log("Invalid hit");
            }
            else{
                Debug.Log("Sword hit NPC");
                TakeDamage(50);
            }
        }
     }
    private void Die(){
        
        isDead = true;
        //animation.ChangeAnimationStateNPC("Death");
        ai.ChangeState("DeadState");
    }
    private void TakeDamage(int damage){
       
        currHealth -= damage;
        bar.updateHealthBar(value);
        if(currHealth <= 0 && !isDead){
            Die();
        }
        else{
            Debug.Log("Npc is forced back");
        }

    }
    public float getNPCspeed(){
        return NPCspeed;
    }
    public bool returnDeath(){
        return isDead;
    }
}
