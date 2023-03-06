using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONE : MonoBehaviour
{
    private int amountOfCubes;
    private float randomScale;
    private GameObject cube;

    private void Start()
    {
        amountOfCubes = Random.Range(0, 30);
        while (amountOfCubes > 0)
        {
            Instantiate();
        }
    }

    private Vector3 randomPos()
    {
       position new Vector3 (Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        return 
    }
}
