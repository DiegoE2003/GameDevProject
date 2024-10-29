using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] PlayerInfo Player;
    [SerializeField] float zRotation = 180;
    [Header("Animation Information")]
    [SerializeField] AnimationStateChanger animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            //Debug.Log("Pressed Space key!");
            animation.ChangeAnimationState("Attack State");
            //animation.ChangeAnimationState("Idle");
        }
        if(Input.GetKeyDown(KeyCode.F)){
            zRotation = Player.transform.rotation.y;
            Player.RotateZ(zRotation);
        }

        Player.Move(movement);
    }
}
