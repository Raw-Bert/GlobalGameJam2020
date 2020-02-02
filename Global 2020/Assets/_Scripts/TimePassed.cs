using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    private Text countText;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        countText.text = "Time Passed: " + Mathf.Round(counter) + "s";
        
    }
}
