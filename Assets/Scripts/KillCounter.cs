using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Update is called once per frame
    public void updateKillCounter(int counter){
        text.text = "Kill Counter: " + counter.ToString();
    }
}
