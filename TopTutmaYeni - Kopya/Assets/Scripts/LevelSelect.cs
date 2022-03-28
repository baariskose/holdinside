using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] pages;
    
    int pageCount;
    AudioSource audioSource;
  
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = (i + 1).ToString(); 
        }
        pageCount = 0;
        if(PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        PlayerPrefs.SetInt("Level", buttons.Length+1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < PlayerPrefs.GetInt("Level"))
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
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
        
    }
    public void NextPage()
    {
        if(pageCount < pages.Length-1)
        {
            pages[pageCount].SetActive(false);
            pageCount++;
            pages[pageCount].SetActive(true);
        }
      
    }
    public void PrevPage()
    {
        if(pageCount != 0)
        {
            pages[pageCount].SetActive(false);
            pageCount--;
            pages[pageCount].SetActive(true);
            
            
        }
       
    }
    public void LevelSelectClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        Debug.Log(name);
        SceneManager.LoadScene(int.Parse(name)+1);
    }
}
