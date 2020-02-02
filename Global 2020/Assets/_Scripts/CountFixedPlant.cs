using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountFixedPlant : MonoBehaviour
{
    public GameObject Spawner;
    private Text count;

    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int numberCount = Spawner.GetComponent<MakeCube>().plantCount;
        count.text = "" + numberCount;
    }
}
