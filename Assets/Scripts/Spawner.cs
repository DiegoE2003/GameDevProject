using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject JanissaryNPC;
    [SerializeField] float spawnTime = 2.0f;
    //[SerializeField] List<int> maxEnemyWave = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        //initalizeWaves();
        spawnNPCObjects();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // private void initalizeWaves(){
    //     maxEnemyWave.Add(10);
    // }
    private void spawnNPC(){
            Vector3 spawnPos = new Vector3(-8,Random.Range(-3f,3f),-0.52f);
            GameObject newEnemy = Instantiate(JanissaryNPC,spawnPos, Quaternion.identity);
            newEnemy.transform.localScale = new Vector3(4.6f, 4.5f, 1f);
    }
     void spawnNPCObjects(){
        StartCoroutine(SpawnNPCRoutine());
        IEnumerator SpawnNPCRoutine(){
        int counter = 0;
        int i = 0;
        while(i < 1){
            counter = 0;
                while (counter < 5) 
                {
                    //Debug.Log("Spawning Enemy");
                    yield return new WaitForSeconds(spawnTime);
                    spawnNPC();
                    counter++;
                }
            i++;
            }
        }
    }
}
