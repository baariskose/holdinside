using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public GameObject winPanel,quitPanel;
    public  List<GameObject> counterBalls;
    public List<GameObject> balls;
    int counter;
    int musicCounter = 0;
    public bool isWin = false;
    AudioSource audioSource;
    public AudioClip winGame;
    GameOverController overController;
    bool isSoundPlayed;
    public Button musicButton;
    public Sprite[] sprites;
    bool isMusicOn;
    public Text timeText;
    public float time;

    // Start is called before the first frame update
    void Start()
    {

        counterBalls.AddRange(GameObject.FindGameObjectsWithTag("CounterBall"));
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        audioSource = GameObject.FindGameObjectWithTag("Script").GetComponent<AudioSource>();
        overController = GameObject.FindGameObjectWithTag("Engel").GetComponent<GameOverController>();
        counter = counterBalls.Count;
        isWin = false;
        isSoundPlayed = false;
        if (PlayerPrefs.GetInt("music") == 0)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (counterBalls.Count <= 0)
        {
            if(overController.isGameOver == false)
            {
                isWin = true;
                if (isSoundPlayed == false)
                {
                    audioSource.PlayOneShot(winGame);
                    isSoundPlayed = true;
                }
                winPanel.SetActive(true);
            }
           
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            isMusicOn = true;
            audioSource.mute = false;
            musicButton.image.sprite = sprites[0];
            audioSource.mute = false;
        }
        else
        {
            isMusicOn = false;
            audioSource.mute = true;
            musicButton.image.sprite = sprites[1];
            audioSource.mute = true;
        }
        time -= Time.deltaTime;
        if(timeText != null)
        {
            timeText.text = time.ToString("F0");
            if(time <= 0)
            {
                overController.isGameOver = true;
                time = 0;
            }
        }
       

    }
   public  void BallDelete(GameObject ball)
    {
        counterBalls.Remove(ball);
       
    }
    public void nextLevel()
    {
        PlayerPrefs.SetInt("Level", int.Parse(SceneManager.GetActiveScene().name)+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitPanelActive()
    {
        quitPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        quitPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void musicOnOff()
    {
        musicCounter++;
        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicCounter = 0;
        }
        if (musicCounter % 2 == 1)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }
    }


}
