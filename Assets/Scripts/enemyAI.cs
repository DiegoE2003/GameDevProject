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
    [Header("Attack Parameters")]
    [SerializeField] private float attackRange = 0.2f; // Distance within which the AI attacks the player
    [SerializeField] GameObject body;
    int tick;
    float stateTime;
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
            tick++;
            stateTime += Time.deltaTime;
    }
    void AttackState(){
        //Debug.Log("attack state");
        if(tick == 1){
            animation.ChangeAnimationStateNPC("Attack");
        }
        if(stateTime > 3){
            ChangeState("MoveState");
        }
    }
    void IdleState(){
        //Debug.Log("idle state");
        animation.ChangeAnimationStateNPC("Idle");
    }
    void DeadState(){
        if(tick == 1){
            Debug.Log("playing death animaton!");
            animation.ChangeAnimationStateNPC("Death");
        }
        //return;
    }
    void MoveState(){
        //Debug.Log("move state");
        float distanceToPlayer = Vector3.Distance(transform.position, currentPlayerPos);
        if (distanceToPlayer <= attackRange)
        {
            Debug.Log("distnacetoplayer <= attackRange");
            ChangeState("AttackState");
        }
        else{
            moveTowardPlayer(currentPlayerPos);
        }
    }
    void AITick(){
        currentState();
    }
    public void ChangeState(string state){
        tick = 0;
        stateTime = 0;
        Debug.Log(tick);
        Debug.Log(stateTime);
        if(string.Equals(state,"DeadState")){
            Debug.Log("Chaning state to death state");
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
        if (new_movement.x > 0) // Moving in +x direction
        {
            body.transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
        }
        else
        {
            body.transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
        }
    }
}

