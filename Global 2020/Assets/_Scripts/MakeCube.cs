using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    public int plantCount;
    private int type;
    private float x;
    private float z;
    public bool spawnPlant = true;
    private static ObjectPool myPool;
    float spawnTime = 0;
    //public GameObject testEmpty;
    public GameObject test;

    public bool plantfixed = false;

    void start()
    {
        myPool = ObjectPool.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        //Press F to make a random cube to random position

        if (spawnPlant == true)
        {
            spawnPlant = false;
            //myPool.SpawnObject(pot);
            Debug.Log(transform.position);
            type = Random.Range(1, 8);
            Vector3 pos = new Vector3(2, 1, 2);
            Instantiate(test, transform.position, transform.rotation);
            
            //PlantFactory.MakeCube(type, pos, Quaternion.identity);
            //spawnTime = Time.time;
            
        }

        if (plantfixed == true)
        {
            plantCount++;
            spawnPlant = true;
            plantfixed = false;
        }
    }
}