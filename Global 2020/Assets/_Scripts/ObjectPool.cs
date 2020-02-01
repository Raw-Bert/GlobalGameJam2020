using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Create class for simple pool
    [System.Serializable]
    public class Pool
    {
        //Name of the pool
        public string tag;
        //Type of 3D model in this pool
        public GameObject prefab;
        //Number of models contain in this pool
        public int size;
    }

    //Create a singleton to make sure the pool only create one time
    #region Singleton

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    //Create the list of pools which could manipulate inside Unity
    public List<Pool> pools;

    //Create a dictionary to help save all information of pools
    public Dictionary<string, Queue<GameObject>> poolDict;

    // Start is called before the first frame update
    void Start()
    {
        //assign poolDict to a dictionaty that contain a name and a pool
        poolDict = new Dictionary<string, Queue<GameObject>>();

        //put all pools into pool dictionary
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject ob = Instantiate(pool.prefab);
                ob.SetActive(false);
                objectPool.Enqueue(ob);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }

    //using certain pool inside the pool dictionary to spawn object
    public GameObject SpawnObject(string tag, Vector3 pos, Quaternion rot)
    {
        //Check if the tag exist in the dictionary
        if (!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist!");
            return null;
        }


        //Take off the first object of pool's queue
        GameObject objectGoSpawn = poolDict[tag].Dequeue();
        objectGoSpawn.SetActive(true);
        objectGoSpawn.transform.position = pos;
        objectGoSpawn.transform.rotation = rot;
        objectGoSpawn.tag = tag;

        //Put this object to the end of pool's  queue
        //poolDict[tag].Enqueue(objectGoSpawn);

        //Return this game obeject
        return objectGoSpawn;
    }
    public void DespawnObject(GameObject present)
    {
        present.SetActive(false);
        poolDict[present.tag].Enqueue(present);
    }

}