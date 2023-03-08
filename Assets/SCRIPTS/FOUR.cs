using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOUR : MonoBehaviour
{
    public int numberOfTimes;

    void Start()
    {
        StartCoroutine("positionChange");
    }

    private IEnumerator positionChange()
    {   //i is equal to variable editable from the inspector, meanwhile i= numberOfTimes, i will decrease a number
        for (int i=numberOfTimes; i>0 ;i--)
        {
            //we create a random position every time
            Vector3 randomPos = new Vector3(Random.Range(-5, 20), Random.Range(-5, 20), Random.Range(-5, 20));
            //change the position of the GO for the random position
            transform.position = randomPos;
            //print the position of the console
            Debug.Log($"{randomPos}");
            //wait 2 second after repeat the loop
            yield return new WaitForSeconds(2);
        }
    }
}
