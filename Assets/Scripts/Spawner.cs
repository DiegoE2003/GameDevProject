using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs Information")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject npc;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;
    //[SerializeField] HealthBar slider; //***HEALTH BAR***
    [Header("Spawn Time Information")]
    [SerializeField] float spawnTime = 2.0f;
    [SerializeField] int randNumX;
    [Header("Enemy Wave Information")]
    [SerializeField] List<int> maxEnemyWave = new List<int>(3);
    [Header("List of ai's")]
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] List<string> enemyType = new List<string>(); //if there's time include different enemy types
    [Header("Physics Stuff")]
    [SerializeField] float separationDistance = 1.0f; // Minimum desired distance between ai's
    [SerializeField] Vector3 separationForce; 
    [Header("Kill Counter Information")]
    [SerializeField] int killCounter;
    [SerializeField] KillCounter kc;

    // Start is called before the first frame update
    void Start()
    {
        initalizeWaves();
        spawnNPCObjects();
    }
    void Update() //***Used Chatgpt to add force between each ai so as to not merge together***
    {
        foreach(GameObject ai in returnEnemies())
        {      
            if (ai != null) // Ensure the AI is not null before proceeding
            {
                enemyAI aiScript = ai.GetComponent<enemyAI>();
                if (aiScript != null)
                {
                    bool temp = aiScript.GetComponent<NPCinfo>().returnDeath(); 
                    if (temp)  // If NPC is dead
                    {
                        Destroy(ai, 3.0f); // Destroy the GameObject directly, with a delay if necessary
                        killCounter++;
                        kc.updateKillCounter(killCounter);
                        //Debug.Log("ai is dead! killCounter: " + killCounter);
                        removeEnemyFromList(ai);
                    }
                    else
                    {
                        aiScript.updatePlayerPosition(Player.transform.position);
                        
                        Vector3 separationForce = Vector3.zero;

                        foreach (GameObject otherAI in returnEnemies()){
                            if (otherAI != ai)  // Skip itself
                            {
                                float distance = Vector3.Distance(ai.transform.position, otherAI.transform.position);

                                if (distance < separationDistance)
                                {
                                    Vector3 awayFromNeighbor = ai.transform.position - otherAI.transform.position;
                                    separationForce += awayFromNeighbor.normalized / distance;
                                }
                            }
                        }
                        // Apply movement with separation force for the current AI
                        aiScript.Move(separationForce.normalized);
                    }
                }
                else{
                    Debug.Log("Ai does not exist");
                    continue;
                }
            }
        }
    }
    private void initalizeWaves(){
        maxEnemyWave.Add(5);
        maxEnemyWave.Add(10);
        maxEnemyWave.Add(15);
    }
    private void spawnNPC(){
        int randomInt = Random.Range(0, 4);  // Generates 0 or 3 so enemy can spawn all around player in random places
        if(randomInt == 0){
            randNumX = -15;
            Vector3 spawnPos = new Vector3(randNumX,Random.Range(-3f,3f),0);
            GameObject newEnemy = Instantiate(npc,spawnPos, Quaternion.identity);
            GameObject newEnemy2 = Instantiate(npc2,spawnPos, Quaternion.identity);
            enemies.Add(newEnemy); 
            enemies.Add(newEnemy2);
            newEnemy.GetComponent<enemyAI>().setPlayer(Player);
            newEnemy2.GetComponent<enemyAI>().setPlayer(Player);
        }
        if(randomInt == 1){
            randNumX = 15;
            Vector3 spawnPos = new Vector3(randNumX,Random.Range(-3f,3f),0);
            GameObject newEnemy = Instantiate(npc,spawnPos, Quaternion.identity);
            enemies.Add(newEnemy); //adding new enemy clone to list
            newEnemy.GetComponent<enemyAI>().setPlayer(Player);
        }
         if(randomInt == 2){
            randNumX = 7;
            Vector3 spawnPos = new Vector3(Random.Range(-11f,11f),randNumX,0);
            GameObject newEnemy = Instantiate(npc,spawnPos, Quaternion.identity);
            GameObject newEnemy3 = Instantiate(npc3,spawnPos, Quaternion.identity);
            enemies.Add(newEnemy); //adding new enemy clone to list
            enemies.Add(newEnemy3);
            newEnemy.GetComponent<enemyAI>().setPlayer(Player);
            newEnemy3.GetComponent<enemyAI>().setPlayer(Player);
        }
         if(randomInt == 3){
            randNumX = -7;
            Vector3 spawnPos = new Vector3(Random.Range(-11f,11f),randNumX,0);
            GameObject newEnemy = Instantiate(npc,spawnPos, Quaternion.identity);
            enemies.Add(newEnemy); //adding new enemy clone to list
            newEnemy.GetComponent<enemyAI>().setPlayer(Player);
        }
    }
     void spawnNPCObjects(){
        StartCoroutine(SpawnNPCRoutine());
        IEnumerator SpawnNPCRoutine(){
        int counter = 0;
        int i = 0;
        while(i < 3){
            counter = 0;
                while (counter < maxEnemyWave[i]) 
                {
                    yield return new WaitForSeconds(spawnTime);
                    spawnNPC();
                    counter++;
                }
            yield return new WaitForSeconds(0.20f);
            i++;
            }
        }
    }
     public List<GameObject> returnEnemies(){
        return enemies;
    }
    public void removeEnemyFromList(GameObject currentEnemy){

        for(int i = 0; i < enemies.Count; i++){
            //Debug.Log("iterating over enemies list: i #: " + i);
            if(currentEnemy == enemies[i]){
                //Debug.Log("Removing object from list");
                enemies.RemoveAt(i);
                break;
            }
        } 
    }
}
