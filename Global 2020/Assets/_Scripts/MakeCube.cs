using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    public GameObject parent;
    public int plantCount;
    private int type;
    private float x;
    private float z;
    public bool spawnPlant = true;
    private static ObjectPool myPool;
    float spawnTime = 0;
    //public GameObject testEmpty;
    public GameObject test;
    public GameObject plant;

    private GameObject last;

    //public bool plantfixed = false;

    void start()
    {
        myPool = ObjectPool.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        //Press F to make a random cube to random position

        if (last == null)
        {
            //myPool.SpawnObject(pot);
            Debug.Log(transform.position);
            Vector3 pos = new Vector3(2, 1, 2);
            last = Instantiate(test, transform.position, transform.rotation);
            last.transform.parent = parent.transform;
            last.transform.parent = parent.transform;
            spawnPlant = false;
            Debug.Log(spawnPlant);
            //plantCount++;
            test.transform.GetChild(0).GetComponent<Pot>().plantFixed = false;
            Debug.Log(plantCount);
        }

        if (spawnPlant && last.transform.GetChild(0).GetComponent<Pot>().plantFixed)
        {

            //myPool.SpawnObject(pot);
            Debug.Log(transform.position);
            Vector3 pos = new Vector3(2, 1, 2);
            last = Instantiate(test, transform.position, transform.rotation);
            last.transform.parent = parent.transform;
            last.transform.parent = parent.transform;
            spawnPlant = false;
            Debug.Log(spawnPlant);
            plantCount++;
            test.transform.GetChild(0).GetComponent<Pot>().plantFixed = false;
            Debug.Log(plantCount);
            //PlantFactory.MakeCube(type, pos, Quaternion.identity);
            //spawnTime = Time.time;

        }

    }
}