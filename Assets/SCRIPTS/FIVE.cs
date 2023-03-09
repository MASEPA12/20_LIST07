using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FIVE : MonoBehaviour
{
    private int numberOfTimes = 50; //no se quantes vegades li he de posar, sinos se me petarà
    
    //color
    private Renderer _color;

    //points && lives
    private int points = 0;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;
    private int lives = 3;
 
    private bool canClik = true;
    private bool hasCliked = true;

    //sound
    public AudioClip _sound;
    private AudioSource _audioSource;

 

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _color = gameObject.GetComponent<Renderer>();
        StartCoroutine("positionChange");
    }
   
    private IEnumerator positionChange()
    {   //i is equal to variable editable from the inspector, meanwhile i= numberOfTimes, i will decrease a number

        //hasCliked = true; //evitar es bug q mos lleva una vida a lo principi

        if (canClik == true)
        {
            for (int i = numberOfTimes; i > 0; i--)
            {
                //hasCliked = true;
                canClik = true;
                //mos aseguram que es color és blau a nes principi
                _color.material.color = Color.blue;

                //random pos
                Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                transform.position = randomPos;

                Debug.Log($"hasclicked:{hasCliked}, canClik:{canClik}");

                //si on mouse dwn no es executat...
                if (hasCliked == false)
                {
                    Debug.Log("HASOTIJATBE");
                    lives--;
                    livesCounter();
                    GameOver();
                    //fer que surti Game over en gran--> aquella pared blanca
                }

                //si en tot aquest temps no ha pitjat, sa variable per si sola ja se posa false
                hasCliked = false;

                //esperandu
                yield return new WaitForSeconds(2);

            }
        }
    }

    private void OnMouseDown()
    {
        //si pitj un pic i no havi pitjat abans, canvia color, suma 1 punt, update text i ja no puc pitjar més
        if (canClik==true && gameObject.CompareTag("ball"))
        {
            _color.material.color = Color.green;
            points++;
            pointsText.text = ($"POINTS: {points}");

            //sona un renovet
            _audioSource.PlayOneShot(_sound);

            hasCliked = true;
            canClik = false;

            Debug.Log($"hasclicked:{hasCliked}, canClik:{canClik}");    

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
