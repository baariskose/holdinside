using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public  bool isGameOver;
    public  List<GameObject> balls;
    public GameObject gameOverPanel;
    AudioSource audioSource;
    public AudioClip gameoverSound;
    GameController gameController;
    bool isSoundPlayed;
    int gameoverCounter;
    // Start is called before the first frame update
    void Start()
    {
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        audioSource = GameObject.FindGameObjectWithTag("Script").GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("Script").GetComponent<GameController>();
        isSoundPlayed = false;
        gameoverCounter = PlayerPrefs.GetInt("gameovercounter");
    isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (isGameOver == true)
        {
            if(gameController.isWin == false)
            {
                gameOverPanel.SetActive(true);
                if (isSoundPlayed == false)
                {
                    audioSource.PlayOneShot(gameoverSound);
                    isSoundPlayed = true;
                    Time.timeScale = 0;
                }
            }
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            balls.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            if(balls.Count <= 0)
            {
                isGameOver = true;
                gameoverCounter++;
                PlayerPrefs.SetInt("gameovercounter", gameoverCounter);
            }
        }
        if(collision.gameObject.tag == "CounterBall")
        {
            isGameOver = true;
        }
    }
}
