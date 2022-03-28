using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobInterstitial : MonoBehaviour
{
    private InterstitialAd interstitial;
    GameOverController overController;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        overController = GameObject.FindGameObjectWithTag("Engel").GetComponent<GameOverController>();
        RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4931702315582966/6744787076";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            if (overController.isGameOver)
            {
                Debug.Log("asdas" + PlayerPrefs.GetInt("gameovercounter"));
                if(PlayerPrefs.GetInt("gameovercounter") % 3 == 0)
                {
                    this.interstitial.Show();
                }
             
            }
         
        }
    }
}
