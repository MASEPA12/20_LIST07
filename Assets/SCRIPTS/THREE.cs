using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class THREE : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI valueText;

    private void Start()
    {
        valueText.text = $"VALUE: {value}";
    }
    void Update()
    {   //when the down arrow is cliked, value - 1
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            value--;
            valueText.text = $"VALUE: {value}";
        }
    }
}
