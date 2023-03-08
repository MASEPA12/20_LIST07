using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FIVE : MonoBehaviour
{
    private int numberOfTimes = 50; //no se quantes vegades li he de posar, sinos se me petarà
    private bool ballClicked =false;
    private Renderer _color;
    private int points = 0;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;
    private bool canClik = true;
    private int lives = 3;
    public AudioClip _sound;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _color = gameObject.GetComponent<Renderer>();
        StartCoroutine("positionChange");
    }
    private void Update()
    {
        /*if (clikedOut() == true)//gameObject.CompareTag("ball")
        {
            Debug.Log("HASOTIJATBE");
            lives--;
            livesCounter();
            GameOver();
            //fer que surti Game over en gran--> aquella pared blanca
        }*/
    }
    private IEnumerator positionChange()
    {   //i is equal to variable editable from the inspector, meanwhile i= numberOfTimes, i will decrease a number
        if(canClik == true)
        {
            for (int i = numberOfTimes; i > 0; i--)
            {
                canClik = true;
                //mos aseguram que es color és blau a nes principi
                _color.material.color = Color.blue;

                //random pos
                Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                transform.position = randomPos;
                //ebug.Log($"{randomPos}");

                
                //esperandu
                yield return new WaitForSeconds(2);
            }
        }
    }

    private void OnMouseDown()
    {
        //si pitj un pic i no havi pitjat abans, canvia color, sumar punts, update text i ja no puc pitjar més
        if (canClik==true && gameObject.CompareTag("ball"))
        {
            _color.material.color = Color.green;
            points++;
            pointsText.text = ($"POINTS: {points}");

            //sona un renovet
            _audioSource.PlayOneShot(_sound);

            canClik = false;

        }

    }

    private void GameOver()
    {
        if(lives <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    }


    private void livesCounter()
    {
        if(lives == 3)
        {
            livesText.text = ("LIVES: X X X");
        }
        if (lives == 2)
        {
            livesText.text = ("LIVES: X X");
        }
        if (lives == 1)
        {
            livesText.text = ("LIVES: X");
        }
        if (lives <= 0)
        {
            livesText.text = ("LIVES:");
        }
    }

    //si se pitja a algun lloc de sa pantalla en algun moment se posa true
    /*private bool clikedOut()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("DDDDDDDD");
            return true;
        }
        return false;
    }*/
}
