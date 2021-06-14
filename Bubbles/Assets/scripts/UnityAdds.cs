using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdds : MonoBehaviour,IUnityAdsListener
{
    private string _gameID = "4007651";
    private string _bannerID = "Banner";
    private string _interstitialID = "Interstitial";
    private string _rewardedVideoID = "rewardedVideo";
   // public GameObject watchRewarded, showInterstitial;
    public bool testMode;
    void Start()
    {
        Advertisement.Initialize(_gameID,testMode);
        Advertisement.AddListener(this);
    }
    public void ShowInterstitial()
    {
        if(Advertisement.IsReady(_interstitialID))
        {
            Advertisement.Show(_interstitialID);
        }
    }
    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideoID);
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    public void OnUnityAdsReady(string placementID)
    {
        if(placementID==_rewardedVideoID)
        {
           // watchRewarded.interactable = true;
        }
        if(placementID==_interstitialID)
        {
            //showInterstitial.interactable = true;
        }
        if(placementID==_bannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(_bannerID);
        }
    }
    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if(placementID==_rewardedVideoID)
        {
            if(showResult==ShowResult.Finished)
            {
                GetReward();
            }
            else if(showResult==ShowResult.Skipped)
            {
                GameManager.gm.revived = true;
                GameManager.gm.advertisePanel.SetActive(false);
                GameManager.gm.GameOver();
            }
            else if(showResult==ShowResult.Failed)
            {
                GetReward();
            }
        }
    }
    public void OnUnityAdsDidError(string message)
    {

    }
    public void OnUnityAdsDidStart(string placementID)
    {

    }
    public void GetReward()
    {
        GameManager.gm.ShowAdvertise();
    }
}
