using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> spawnSpots;
    public List<GameObject> objetos;
    public int startWait;
    public float spawnWait, spawnMostWait, spawnLeastWait;
    public bool stop;
    int randEnemy, randPosition;
    

    void Start()
    {
        StartCoroutine(waitSpawner());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSpots.Count == 0 ) {
            stop = true;
        }
        else {
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        }
        
    }

    IEnumerator waitSpawner()
    {

        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, objetos.Count - 1);
            randPosition = Random.Range(0, spawnSpots.Count - 1);

            Instantiate(objetos[randEnemy], spawnSpots[randPosition].position, Quaternion.identity);

            spawnSpots.Remove(spawnSpots[randPosition]);
            objetos.Remove(objetos[randEnemy]);

            yield return new WaitForSeconds(spawnWait);
        }


    }
}
