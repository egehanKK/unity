using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Rewarded : MonoBehaviour {
	
	public string Rewarded_ID;
	
	RewardBasedVideoAd rewardBasedVideo;
	bool otomatik_ac=false;
	const float MAX_TİME = 3f;
	static float time_Rew =  0.4f;
	bool rewarded_yuklu=false;
	void Awake()
	{
		
	}
	void Start () {
		#if UNITY_ANDROID
		string appId = "ca-app-pub-3940256099942544~3347511713";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~3347511713";
		#else
		string appId = "unexpected_platform";
		#endif
		
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		
		rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
		rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
		rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
		rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
		rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
		rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
		rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
		// RewardBasedVideoAd is a singleton, so handlers should only be registered once.
		
		// Called when an ad request has successfully loaded.

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!rewarded_yuklu) {
			time_Rew -= Time.deltaTime;
			if (time_Rew <= 0) {
				RequestRewardBasedVideo ();
				time_Rew = MAX_TİME;
			}
		}
		if (otomatik_ac) {
			if (rewarded_yuklu) {
			 ShowRewardBasedVideo ();
			}
		}
	}
	
	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder().Build();
	}
	
	public void RequestRewardBasedVideo()
	{
		
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = Rewarded_ID;
		#elif UNITY_IPHONE
		string adUnitId = Rewarded_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
	}
	
	public  void ShowRewardBasedVideo()
	{
		if(rewardBasedVideo.IsLoaded())
		{
			rewardBasedVideo.Show();
			
		}
		else
		{
			otomatik_ac = true;
			rewarded_yuklu = false;
			Debug.Log("Yüklenemedi. \n");
		}
		
	}
	
	
	
	#region RewardBasedVideo callback handlers
	
	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		Debug.Log("Yüklendi. \n");
		rewarded_yuklu = true;
	}
	
	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("Yüklenemedi. \n");
		rewarded_yuklu = false;
	}
	
	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		Debug.Log("Açıldı. \n");
		otomatik_ac=false;
	}
	
	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		Debug.Log("Başladı. \n");
		otomatik_ac=false;
	}
	
	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		Debug.Log("Kapatıldı. \n");
		otomatik_ac=false;
		rewarded_yuklu = false;
	}
	
	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		otomatik_ac=false;
		Debug.Log("Ödül : " + type +"-" + amount +"\n");
		rewarded_yuklu = false;
	}
	
	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}
	void OnDestroy()
	{
		rewardBasedVideo.OnAdLoaded -= this.HandleRewardBasedVideoLoaded;
		rewardBasedVideo.OnAdFailedToLoad -= this.HandleRewardBasedVideoFailedToLoad;
		rewardBasedVideo.OnAdOpening -= this.HandleRewardBasedVideoOpened;
		rewardBasedVideo.OnAdStarted -= this.HandleRewardBasedVideoStarted;
		rewardBasedVideo.OnAdRewarded -= this.HandleRewardBasedVideoRewarded;
		rewardBasedVideo.OnAdClosed -= this.HandleRewardBasedVideoClosed;
		rewardBasedVideo.OnAdLeavingApplication -= this.HandleRewardBasedVideoLeftApplication;
	}
	#endregion
}
