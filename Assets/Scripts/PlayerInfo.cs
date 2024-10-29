using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] float Health;
    [SerializeField] float speed = 5.0f;

    void Awake(){
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector3 movement){
        transform.position += movement * speed * Time.deltaTime;
    }
    public void RotateZ(float zCurrentRotation){ 
        if(zCurrentRotation == 180){
            transform.Rotate(0,0,0);
        }
        else{
            transform.Rotate(0,180,0);
        }
    }
    public Vector3 getCurrentPosition(){
        return transform.localPosition;
    }
}
