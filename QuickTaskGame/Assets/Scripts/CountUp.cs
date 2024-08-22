using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class CountUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI count;
    [SerializeField]
    private float speed = 1;

    private float timeDisplay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            timeDisplay = timeDisplay + Time.deltaTime * speed;
            int minutes = Mathf.FloorToInt(timeDisplay / 60);
            int seconds = Mathf.FloorToInt(timeDisplay % 60);
            count.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
