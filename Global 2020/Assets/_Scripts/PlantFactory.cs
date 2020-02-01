using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;


public class PlantFactory : MonoBehaviour
{
    private ObjectPool myPool;

    public Transform spawnOrientation;

    [System.Serializable]
    public class PlantBottom
    {
        public string tag;

        //Only a single bottom is needed as the soil prefab must match the pot prefab

        public GameObject potNormal;
        public GameObject potBroken;

        public GameObject soilNormal;
        public GameObject soilDry;
        public GameObject soilNeedsFertalizer;
    }

    [System.Serializable]
    public class PlantStem
    {
        public string tag;

        public GameObject stemNormal;
        public GameObject stemLimp;
        public GameObject stemBroken;
    }

    [System.Serializable]
    public class PlantHead
    {
        public string tag;
     
        public GameObject headNormal;
        public GameObject headPetalMissing;
    }


    public List<PlantBottom> plantBottoms = new List<PlantBottom>();
    public List<PlantStem> plantStems;
    public List<PlantHead> plantHeads;

    // Start is called before the first frame update
    void Start()
    {
        myPool = ObjectPool.Instance;
        
        int instances = 20;

        foreach (PlantBottom pb in plantBottoms){
            if (pb is null)
                Debug.Log("NULL");
                //continue;

            ObjectPool.Pool _pool = new ObjectPool.Pool(pb.tag + "_pot_normal", pb.potNormal, instances);

            Debug.Log(_pool.size);
            Debug.Log(myPool.name);
            

            if (_pool is null)
                Debug.Log("NULL2");
                //continue;

            myPool.AddPool(_pool);
            myPool.AddPool(new ObjectPool.Pool(pb.tag + "_pot_broken", pb.potBroken, instances));
            myPool.AddPool(new ObjectPool.Pool(pb.tag + "_soil_normal", pb.soilNormal, instances));
            myPool.AddPool(new ObjectPool.Pool(pb.tag + "_soil_dry", pb.soilDry, instances));
            myPool.AddPool(new ObjectPool.Pool(pb.tag + "_soil_needs_fertilizer", pb.soilNeedsFertalizer, instances));
        }

        foreach (PlantStem ps in plantStems)
        {
            myPool.AddPool(new ObjectPool.Pool(ps.tag + "_stem_normal", ps.stemNormal, instances));
            myPool.AddPool(new ObjectPool.Pool(ps.tag + "_stem_limp", ps.stemLimp, instances));
            myPool.AddPool(new ObjectPool.Pool(ps.tag + "_stem_broken", ps.stemBroken, instances));
        }

        foreach (PlantHead ph in plantHeads)
        {
            myPool.AddPool(new ObjectPool.Pool(ph.tag + "_head_normal", ph.headNormal, instances));
            myPool.AddPool(new ObjectPool.Pool(ph.tag + "_head_petal_missing", ph.headPetalMissing, instances));
        }

        /*
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
        */
    }

    public enum HeadState
    {
        normal,
        missing_petals,
    }

    public enum StemState
    {
        normal,
        limp,
        broken,
    }
    public enum PotState
    {
        normal,
        broken,
    }

    public enum SoilState
    {
        normal,
        dry,
        discolored,
    }

    public enum PlantProblem
    {
        thirsty,
        broken_pot,
        bumped,
        plant_too_large,
        malnourished,
        infestation,
        sick,
        romantic_owner,
    }

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new System.Random().Next(v.Length));
    }

    private PlantProblem GenerateProblem()
    {
        return RandomEnumValue<PlantProblem>();
    }


    private Tuple<HeadState, StemState, PotState, SoilState> AttributeBuilder(PlantProblem problem)
    {
        //Tuple<HeadState, StemState, PotState, SoilState> plant_state;

        switch (problem){
            case PlantProblem.thirsty:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.normal, SoilState.normal);
            
            case PlantProblem.broken_pot:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.bumped:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.plant_too_large:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.malnourished:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.infestation:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.sick:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            case PlantProblem.romantic_owner:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.broken, SoilState.normal);

            default:
                return new Tuple<HeadState, StemState, PotState, SoilState>
                    (HeadState.normal, StemState.normal, PotState.normal, SoilState.normal);
        }

    }

    public GameObject CreatePlant()
    {
        PlantProblem problem = GenerateProblem();
        Tuple<HeadState, StemState, PotState, SoilState> attributes = AttributeBuilder(problem);


        //Pull data from the generated tuple
        HeadState ehead = attributes.Item1;
        StemState estem = attributes.Item2;
        PotState epot = attributes.Item3;
        SoilState esoil = attributes.Item4;



        GameObject plant_parent;
        GameObject plant_top;
        GameObject plant_stem;
        GameObject plant_head;
        GameObject plant_bottom;

        plant_parent = new GameObject();

        plant_top = new GameObject();
        plant_top.transform.parent = plant_parent.transform;

        plant_stem = new GameObject();
        plant_stem.transform.parent = plant_top.transform;

        plant_head = new GameObject();
        plant_head.transform.parent = plant_top.transform;

        plant_bottom = new GameObject();
        plant_bottom.transform.parent = plant_parent.transform;
        
        return plant_parent;
    }


}

