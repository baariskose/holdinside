using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
     AudioSource audioSource;
    bool isMusicOn;
    int counter = 0;
    public Button musicButton;
    public Sprite[] sprites;
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward* Time.deltaTime*35, Space.World);
        if (PlayerPrefs.GetInt("music") == 0)
        {
            isMusicOn = true;
            audioSource.mute = false;
            musicButton.image.sprite = sprites[0];
        }
        else
        {
            isMusicOn = false;
            audioSource.mute = true;
            musicButton.image.sprite = sprites[1];
        }
    }
    public void play()
    {
       
        SceneManager.LoadScene(1);
    }
    public void musicOnOff()
    {
        counter++;
        if (PlayerPrefs.GetInt("music") == 1)
        {
            counter = 0;
        }
        if(counter %2 == 1)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }
    }
}
