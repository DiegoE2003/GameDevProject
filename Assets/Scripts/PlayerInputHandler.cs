using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Player and Animation References")]
    [SerializeField] PlayerInfo Player;
    [Header("Animation Information")]
    [SerializeField] AnimationStateChanger animation;
     [Header("Rotation Settings")]
     [SerializeField] float zRotation = 180;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            movement+=new Vector3(0,1,0);
        }
        if(Input.GetKey(KeyCode.A)){
            movement+=new Vector3(-1,0,0);
        }
        if(Input.GetKey(KeyCode.S)){
            movement+=new Vector3(0,-1,0);
        }
        if(Input.GetKey(KeyCode.D)){
            movement+=new Vector3(1,0,0);
        }
        if(Input.GetMouseButtonDown(0)){
            animation.ChangeAnimationState("Attack State");
        }
        if(Input.GetKeyDown(KeyCode.F)){
            zRotation = Player.transform.rotation.y;
            Player.RotateZ(zRotation);
        }

        Player.Move(movement);
    }
}
