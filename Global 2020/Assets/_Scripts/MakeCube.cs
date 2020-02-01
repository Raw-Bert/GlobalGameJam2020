using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    public int cubeCount;
    private int type;
    private float x;
    private float z;
    public bool spawnPlant = false;

    private bool brokenStem = false;
    //private bool brokenPot = false;
    //private bool brokenPot = false;

    float spawnTime = 0;

    // Update is called once per frame
    void Update()
    {
        //Press F to make a random cube to randome position
        
        if (spawnPlant == true)
        {
            spawnPlant = false;
            Debug.Log(transform.position);
            type = Random.Range(1, 8);

            Vector3 pos = new Vector3(2, 1f, 2);
            PlantFactory.MakeCube(type, pos, Quaternion.identity);
            spawnTime = Time.time;
            cubeCount++;

            if (cubeCount == 10)
            {
                Debug.Log("You've spawned 10 cubes! wow");
            }
        }
    }
}