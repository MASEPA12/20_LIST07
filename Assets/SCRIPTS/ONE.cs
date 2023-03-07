using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONE : MonoBehaviour
{
    private int amountOfCubes;
    private Vector3 randomScale;
    public GameObject cube;

    private void Start()
    {   //generate a random number of cubes
        amountOfCubes = Random.Range(1, 30);
        while (amountOfCubes > 0)
        {   //instance the cube with a random pos and a random scale 
            Instantiate(cube, randomPos(), transform.rotation);
            amountOfCubes--;
            randomScale = new Vector3(Random.Range(0.1f, 2), Random.Range(0.1f, 2), Random.Range(0.1f, 2)); 
            cube.transform.localScale = randomScale;
        }
    }

    private Vector3 randomPos()
    {
        return new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }
}


