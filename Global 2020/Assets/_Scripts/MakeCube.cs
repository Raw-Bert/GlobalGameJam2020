using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlantFactory;

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

        if (spawnPlant && last == null)
        {
            //myPool.SpawnObject(pot);
            Debug.Log(transform.position);
            Vector3 pos = new Vector3(2, 1, 2);


            
            
            Tuple<GameObject, PlantFactory.PlantProblem> flower_problem = PlantFactory.Instance.CreatePlant();
            GameObject new_go = flower_problem.Item1;
            PlantFactory.PlantProblem problem = flower_problem.Item2;




            last = new_go;
            last.transform.parent = parent.transform;
            last.transform.parent = parent.transform;
            spawnPlant = false;
            Debug.Log(spawnPlant);
            plantCount++;
            test.GetComponent<Pot>().plantFixed = false;
            Debug.Log(plantCount);
        }

        if (spawnPlant && last.GetComponent<Pot>().plantFixed)
        {

            //myPool.SpawnObject(pot);
            Debug.Log(transform.position);
            Vector3 pos = new Vector3(2, 1, 2);

            
            Tuple<GameObject, PlantFactory.PlantProblem> flower_problem = PlantFactory.Instance.CreatePlant();
            GameObject new_go = flower_problem.Item1;
            PlantFactory.PlantProblem problem = flower_problem.Item2;

 
            last = new_go;
            last.transform.parent = parent.transform;
            last.transform.parent = parent.transform;
            spawnPlant = false;
            Debug.Log(spawnPlant);
            plantCount++;
            test.GetComponent<Pot>().plantFixed = false;
            Debug.Log(plantCount);
            //PlantFactory.MakeCube(type, pos, Quaternion.identity);
            //spawnTime = Time.time;

        }

    }
}