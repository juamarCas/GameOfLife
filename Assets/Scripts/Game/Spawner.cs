using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Transform spawnPos;
    GameObject objectToSpawn; 

    public Spawner(Transform spawnPos, GameObject objectToSpawn)
    {
        this.spawnPos = spawnPos;
        this.objectToSpawn = objectToSpawn; 
    }

    public GameObject Spawn()
    {
        GameObject obj = Instantiate(objectToSpawn, spawnPos.transform.position, spawnPos.transform.rotation);
        return obj; 
    }
}
