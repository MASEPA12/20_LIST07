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
            Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            //change the position of the GO for the random position
            transform.position = randomPos;
            //wait 2 second after repeat the loop
            yield return new WaitForSeconds(2);
        }
    }
}
