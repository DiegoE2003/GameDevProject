using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class randomNumberGenerator : MonoBehaviour
{
    // [SerializeField] List<int> randomList;
    // [SerializeField] List<float> newList;
    // [SerializeField] int randomNum;
    // [SerializeField] int sum;
    // Start is called before the first frame update
    // void Start()
    // {   
    //     int length = Random.Range(1,6);
    //     // GenerateList(length);
    // }
    // public void GenerateList(int length){
    //     Debug.Log("Length of list: " + length);
    //     randomList = new List<int>(length); 
    //     for(int i = 0; i < length; i++){
    //         randomNum = Random.Range(1,11);
    //         randomList.Add(randomNum);
    //         sum += randomList[i];
    //         Debug.Log("List value at index: " + i + "," + randomList[i]);
    //     }
    //     Debug.Log("Sum of values of list: " + sum);
    //     Debug.Log("Size of list: " + randomList.Count);
    //     float halfLength = length / 2.0f;
    //     float ratio = halfLength / sum;
    //     Debug.Log("Half of size of list: " + halfLength);
    //     Debug.Log("Ratio of halfLength/length: " + ratio);

    //     newList = new List<float>(length);
    //     float newSum = 0.0f;
    //     for(int i = 0; i < length; i++){
    //         newList.Add(ratio*randomList[i]);
    //         Debug.Log("Value of newList at index: " + i + "," + newList[i]);
    //         newSum += newList[i];
    //     }
    //     Debug.Log("Final sum: " + newSum);
    // }
}
