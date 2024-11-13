using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camerFollow : MonoBehaviour
{   
    [Header("Player Transform Information")]
    [SerializeField] Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y,-10);
    }
}