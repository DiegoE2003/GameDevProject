using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    [Header("Toggle & musicPlayer references")]
    [SerializeField] Toggle m_Toggle;
    [SerializeField] MusicPlayerHandler musicPlayer;
    public void MusicOnOrOff(){
        
        musicPlayer.makePrefab();
        
        if(m_Toggle.isOn){  
            Debug.Log("toggle on");
            musicPlayer.playMusicOnAwake(true);
        }
        else if(!m_Toggle.isOn){
            Debug.Log("toggle is not on");
           musicPlayer.playMusicOnAwake(false);
        }

    }
    public void GoBack(){
        SceneManager.LoadScene("MainMenu");
    }
}
