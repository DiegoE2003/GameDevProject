using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RulesManager : MonoBehaviour
{
     // Start is called before the first frame update
    public void GoBack(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        //Debug.Log("Quit");
        Application.Quit();
    }
}
