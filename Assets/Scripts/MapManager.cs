using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1()
    {   
        //Debug.Log("Going to lvl1");
        SceneManager.LoadScene("Battlefield"); 
    }
    public void Level2(){
        //Debug.Log("Going to lvl2");
        SceneManager.LoadScene("Battlefield2");
    }
    public void GoBackMenu(){
        //Debug.Log("Going back to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}