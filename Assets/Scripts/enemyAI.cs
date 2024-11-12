using System.Collections;
using System.Collections.Generic;
using AOT;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    [Header("AI Information & AnimationNPC reference")]
    [SerializeField] NPCinfo npc;
    [SerializeField] AnimationStateChangerNPC animation;
    delegate void AIState();
    AIState currentState;
    AIState newState;
    Vector3 currentPlayerPos;
    void Start(){
        ChangeState("MoveState");
    }
    public void updatePlayerPosition(Vector3 currentPos){
        currentPlayerPos = currentPos;
    }
    public void setPlayer(GameObject player){
        Vector3 goalPos = player.transform.position;
        currentPlayerPos = goalPos;
        moveTowardPlayer(goalPos);
    }
    void Update(){
            AITick();
    }
    void AttackState(){
        animation.ChangeAnimationStateNPC("Attack");
    }
    void IdleState(){
        animation.ChangeAnimationStateNPC("Idle");
    }
    void DeadState(){
        Debug.Log("playing death animaton!");
        animation.ChangeAnimationStateNPC("Death");
        //return;
    }
    void MoveState(){
        moveTowardPlayer(currentPlayerPos);
        //animation.changeAnimationStateNPC("Walk")
    }
    void AITick(){
        currentState();
    }
    public void ChangeState(string state){
        if(string.Equals(state,"DeadState")){
            newState = DeadState;
        }
        if(string.Equals(state,"MoveState")){
            newState = MoveState;
        }
        if(string.Equals(state,"IdleState")){
            newState = IdleState;
        }
        if(string.Equals(state,"AttackState")){
            newState = AttackState;
        }
        currentState = newState;
    }
    private void moveTowardPlayer(Vector3 goalPos){
        goalPos.z = 0;
        Vector3 direction = goalPos - transform.position;
        Move(direction.normalized);
    }
    public void Move(Vector3 new_movement){
        transform.position += new_movement * npc.getNPCspeed() * Time.deltaTime;

        // Rotate based on the direction of movement in the x-axis ***Chatgpt***
        if (new_movement.x > 0) // Moving in +x directiont
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
        }
    }
}

