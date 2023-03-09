using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FIVE : MonoBehaviour
{
    //color
    private Renderer _color;

    //points && lives
    private int points = 0;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    private int lives = 3;
    
    //checkers
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

        //we desactivte the gameOverPanel unitil game over is true
        gameOverPanel.SetActive(false);
    }
   
    private IEnumerator positionChange()
    {   
        //we check if the plyayer has already cliked the ball (in order to avoid multiple points)
        if (canClik == true)
        {
            //meanwhile is not game over
            while (lives>0)
            {
                canClik = true;

                //restart the blue color
                _color.material.color = Color.blue;

                //random pos
                Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                transform.position = randomPos;

                //if OnMouseDown is not executed...
                if (hasCliked == false)
                {
                    lives--;
                    livesCounter();
                    GameOver();
                }

                //if the player hasn't clicked in all this time...
                hasCliked = false;

                yield return new WaitForSeconds(2);

            }
        }
    }

    private void OnMouseDown()
    {
        //if the player cliks (and it didn't clik befor) change color, +1 point, update score text and play a soud
        if (canClik==true && gameObject.CompareTag("ball"))
        {
            _color.material.color = Color.green;
            points++;
            pointsText.text = ($"POINTS: {points}");

            //sona un renovet
            _audioSource.PlayOneShot(_sound);

            hasCliked = true;

            //finally, the player can't clik anymore until the loop is reloaded
            canClik = false;
        }
    }

    private void GameOver()
    {
        //when the lives are over, game over
        if(lives <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
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

}
