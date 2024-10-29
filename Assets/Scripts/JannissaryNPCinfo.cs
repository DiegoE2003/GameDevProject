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
    [SerializeField] AnimationStateChangerNPC animation;
    //[SerializeField] int killCounter = 0;
    [Header("AI Information & Player Reference")]
    [SerializeField] PlayerInfo targetPlayer;
    delegate void AIState();
    AIState currentState;

    // Start is called before the first frame update
    void Start(){
        ChangeState(MoveState);
    }
    // Update is called once per frame
    void Update(){
            AITick();
    }
    void DeadState(){
        return;
    }
    void MoveState(){
        moveTowardPlayer(targetPlayer.transform.position);
    }
    void AITick(){
        currentState();
    }
    void ChangeState(AIState newState){
        currentState = newState;
    }
    private void moveTowardPlayer(Vector3 goalPos){
        goalPos.z = 0;
        Debug.Log(goalPos);
        Vector3 direction = goalPos - transform.position;
        Move(direction.normalized);
    }
    private void Move(Vector3 new_movement){
        Debug.Log("Moving");
        transform.position += new_movement * NPCspeed * Time.deltaTime;
    }
     void OnTriggerEnter2D(Collider2D other){
        if(totalHealth == 50){
            isDead = true;
            //Debug.Log("calling ChangeAnimationStateNPC");
            animation.ChangeAnimationStateNPC("Death");
            Debug.Log("changing ai state");
            ChangeState(DeadState); //set ai state to deadstate which does nothing
            Destroy(this.gameObject,3.0f);
            //killCounter++;  //keep track of kills
        }
        if(other.CompareTag("Sword") && totalHealth > 50.0f){
            
            if(other.offset.y >= 0.05){
                Debug.Log("Invalid hit");
            }
            else{
                //Debug.Log("Sword hit Janissary");
                totalHealth -= 50;
                currHealth = totalHealth;
            }
        }
    }
}
