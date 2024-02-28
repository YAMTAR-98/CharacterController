using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] spawnPoints;
    public int SpawnCount;
    int lenght;

    private void Start() {
        spawnPoints = GetComponentsInChildren<Transform>();
        lenght = spawnPoints.Length;
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn(){
        while(true){
            yield return new WaitForSeconds(10f);
            
            SpawnCount++;
            for(int i = 0; i < SpawnCount; i++){
                int point = Random.Range(0, lenght - 1);

                Instantiate(Enemy, spawnPoints[point].transform.position, Quaternion.identity);
            }
        }
    }
}
