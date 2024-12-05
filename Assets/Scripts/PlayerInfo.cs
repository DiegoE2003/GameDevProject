using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    [Header("Player health & speed Information")]
    [SerializeField] float Health = 100.0f;
    [SerializeField] float speed = 5.0f;
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
    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("enemySword")){
           
            if(Health == 50){
                Destroy(gameObject);
                SceneManager.LoadScene("MainMenu");
            }
            else if(other.offset.y == -0.06 || other.offset.x == 0.35){
                Debug.Log("taking damage");
                Health -= 50.0f;
            }
            else{
                Debug.Log("Bruh");
            }
        }

    }
}
