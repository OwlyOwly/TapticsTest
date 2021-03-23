using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using Kuhpik;

public class AdmobAds : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private string appID, rewardedAdID;

    private void Start()
    {
        appID = "ca-app-pub-8031020776871928~6802399658";
        rewardedAdID = "ca-app-pub-3940256099942544/5224354917";
        MobileAds.Initialize(initStatus => { });
        RequestRewardedAd();
        Debug.Log("ads initialized");
    }

    public void RequestRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdID);

        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;


        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);

        
    }

    public void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        Debug.Log("clicked");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Bootstrap.GetSystem<TimerSystem>().AddBonusTime();
    }
}
