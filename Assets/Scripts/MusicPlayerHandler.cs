using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerHandler : MonoBehaviour
{   
   [SerializeField] GameObject musicPlayerPrefab;
   public void makePrefab(){
    GameObject musicBox = Instantiate(musicPlayerPrefab,Vector3.zero, Quaternion.identity);
   }
   public void playMusicOnAwake(Boolean trueOrFalse){

        if(trueOrFalse){
            Debug.Log("Setting play on awake to be true");
            musicPlayerPrefab.GetComponent<AudioSource>().playOnAwake = true;
        }
        if(!trueOrFalse){
            Debug.Log("Setting play on awake to be false");
            musicPlayerPrefab.GetComponent<AudioSource>().playOnAwake = false;
        }

   }
}
