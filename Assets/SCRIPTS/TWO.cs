using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TWO : MonoBehaviour
{
    private int time = 0;
    public TextMeshProUGUI timeText;
    void Start()
    {
        StartCoroutine(counter2());
    }

    private IEnumerator counter2()
    {   //it displays the seconds 
        while (true)
        {
            timeText.text = ($"TIME: {time}");
            time++;
            yield return new WaitForSeconds(1);
        }
    }

}
