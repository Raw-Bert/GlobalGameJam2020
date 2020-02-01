using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class PlantFactory : MonoBehaviour
{
    public GameObject soil;
    public GameObject soilDry;
    public GameObject stem;
    public GameObject stemBroken;
    public GameObject pot;
    public GameObject potBroken;
    public GameObject plantHead;

    public static Dictionary<int, Type> factoryDict;
    private static ObjectPool myPool;

    // Start is called before the first frame update
    void Start()
    {
        //assign cube type to static cube
        //initialize cube maker
        var factoryTypes = Assembly.GetAssembly(typeof(CubeMaker)).GetTypes().
            Where(myType => myType.IsClass && !myType.IsAbstract && myType.
            IsSubclassOf(typeof(CubeMaker)));

        factoryDict = new Dictionary<int, Type>();
        myPool = ObjectPool.Instance;

        foreach(var type in factoryTypes)
        {
            var tempCube = Activator.CreateInstance(type) as CubeMaker;
            factoryDict.Add(tempCube.Name, type);
        }
    }

    //use cube maker to make certain type cube at certain position with certain rotation
    public static CubeMaker MakeCube(int cubeType, Vector3 position, Quaternion rotation)
    {
        if(factoryDict.ContainsKey(cubeType))
        {
            Type type = factoryDict[cubeType];
            var cube = Activator.CreateInstance(type) as CubeMaker;
            cube.SpawnCube(position, rotation);
            return cube;
        }
        return null;
    }

    //Cube maker contain a function could spawn cube
    public abstract class CubeMaker
    {
        public abstract int Name { get; }
        public abstract void SpawnCube(Vector3 pos, Quaternion rot);
    }

    public class MakeSoil:CubeMaker
    {
        public override int Name => 1;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Soil", pos, rot);
        }
    }

    public class MakeDrySoil : CubeMaker
    {
        public override int Name => 2;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Dry Soil", pos, rot);
        }
    }

    public class MakeStem : CubeMaker
    {
        public override int Name => 3;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Stem", pos, rot);
        }
    }

    public class MakeBrokenStem : CubeMaker
    {
        public override int Name => 4;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Broken Stem", pos, rot);
        }
    }

    public class MakePot : CubeMaker
    {
        public override int Name => 5;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Pot", pos, rot);
        }
    }
     public class MakeBrokenPot : CubeMaker
    {
        public override int Name => 6;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Broken Pot", pos, rot);
        }
    }
    public class MakePlantHead : CubeMaker
    {
        public override int Name => 7;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Plant", pos, rot);
        }
    }


}