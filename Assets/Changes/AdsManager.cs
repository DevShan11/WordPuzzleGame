using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;
public class AdsManager : MonoBehaviour
{
	public static AdsManager Instance;
	private string appID = "ca-app-pub-8897330134048910~8384623726";
    //           ..........................AdsID.........................
    public string bannerID = "ca-app-pub-8897330134048910/4172602890";
    public String interstitialID = "ca-app-pub-8897330134048910/2454788625";
    public String rewardedID = "ca-app-pub-8897330134048910/7515543615";
	//            .........................AdsPosition.....................
	private AdPosition SmallbannerPosition = AdPosition.Bottom;
	//            .........................Ad View..........................
	private BannerView SmallBannerview;
	private InterstitialAd _interstitialAd;
	private RewardedAd _rewardedAd;
	//             ........................bools............................
	private bool SmallBannerOnceLoaded;
	public bool enableTestMode;
	private bool isInternet = false;
	private bool isAdInitialized = false;
	bool isOnce = false;
	bool splashinst = true;
	private RewardedAd rewardedAd;
	public void Awake()
	{
		try
		{
			Instance = this;
		}
		catch
		{
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		try
		{
			if (enableTestMode)
			{
				//..................Test IDs..................
				bannerID = "ca-app-pub-3940256099942544/6300978111";
				rewardedID = "ca-app-pub-3940256099942544/5224354917";
			}
			SmallBannerOnceLoaded = false;
			if (IsInternetConnection())
			{
				try
				{
					InitializeAds();
				}
				catch
				{
				}
			}
			else
			{
				isAdInitialized = false;
			}
		}
		catch
		{
		}
	}
	void InitializeAds()
	{
		try
		{
			isAdInitialized = true;
			MobileAds.Initialize(initStatus => { });
            LoadRewardedAd();

            if (PlayerPrefs.GetInt("ADSUNLOCK").Equals(0))
			{
				try
				{
					RequestSmallBanner();
				}
				catch
				{
				}
				try
				{
					//LoadRewardedAd();
				}
				catch
				{
				}
				try
				{
					//RequestInterstitial();
				}
				catch
				{
				}
				try
				{
					//	RequestInterstitial_MainMenu();
				}
				catch
				{
				}
				try
				{
					//	RequestLargeBannerBL();
				}
				catch
				{
				}
			}
			if (isOnce)
			{
				try
				{
					//LoadRewardedAd();
				}
				catch
				{
				}
			}
			else
			{
				isOnce = true;
				Invoke("requestAd", 0.1f);
			}
		}
		catch
		{
		}
	}
	void requestAd()
	{
		try
		{
			try
			{
				//RequestRewardVedioAD();
			}
			catch
			{
			}
		}
		catch
		{
		}
	}
	public bool IsInternetConnection()
	{
		try
		{
			if (Application.internetReachability != NetworkReachability.NotReachable)
			{
				isInternet = true;
			}
			else
			{
				isInternet = false;
			}
			return isInternet;
		}
		catch
		{
			return true;
		}
	}
	private bool CheckInitilization()
	{
		try
		{
			if (isAdInitialized)
			{
				isAdInitialized = true;
				return isAdInitialized;
			}
			else
			{
				isAdInitialized = false;
				InitializeAds();
				return false;
			}
		}
		catch
		{
			return true;
		}
	}
	#region Small BannerAd
	//...........smallBannerAd.......
	public void RequestSmallBanner()
	{
		try
		{
			this.SmallBannerview = new BannerView(bannerID, AdSize.Banner, SmallbannerPosition);
			// Register for ad events.
			// Load a banner ad.
			this.SmallBannerview.LoadAd(this.CreateAdRequest());
			//this.SmallBannerview.Hide();
		}
		catch
		{
		}
	}
	public void ShowSmallAdmobBanner()
	{
		try
		{
			if (PlayerPrefs.GetInt("ADSUNLOCK").Equals(0))
			{
				if (IsInternetConnection())
				{
					if (CheckInitilization())
					{
						if (SmallBannerOnceLoaded)
						{
							SmallBannerview.Show();
						}
					}
				}
			}
		}
		catch
		{
		}
	}
	public void HandleAdLoaded(object sender, EventArgs args)
	{
		try
		{
			SmallBannerOnceLoaded = true;
		}
		catch
		{
		}
	}
	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		try
		{
		}
		catch
		{
		}
	}
	public void HideSmallAdmobBanner()
	{
		try
		{
			SmallBannerview.Hide();
		}
		catch
		{
		}
	}
	#endregion



	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder().Build();
	}
	//..........................................SplashIntrestitial
	public void RequestInterstitial()
	{
		try
		{
			// Clean up the old ad before loading a new one.
			if (_interstitialAd != null)
			{
				_interstitialAd.Destroy();
				_interstitialAd = null;
			}

			Debug.Log("Loading the interstitial ad.");

			// create our request used to load the ad.
			var adRequest = new AdRequest.Builder().Build();

			// send the request to load the ad.
			InterstitialAd.Load(interstitialID, adRequest,
				(InterstitialAd ad, LoadAdError error) =>
				{
					// if error is not null, the load request failed.
					if (error != null || ad == null)
					{
						Debug.LogError("interstitial ad failed to load an ad " +
									   "with error : " + error);
						return;
					}

					Debug.Log("Interstitial ad loaded with response : "
							  + ad.GetResponseInfo());

					_interstitialAd = ad;
				});
		}
		catch
		{
		}
	}
	private void RegisterEventHandlers(InterstitialAd interstitialAd)
	{
		// Raised when the ad is estimated to have earned money.
		interstitialAd.OnAdPaid += (AdValue adValue) =>
		{
			Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
				adValue.Value,
				adValue.CurrencyCode));
		};
		// Raised when an impression is recorded for an ad.
		interstitialAd.OnAdImpressionRecorded += () =>
		{
			Debug.Log("Interstitial ad recorded an impression.");
		};
		// Raised when a click is recorded for an ad.
		interstitialAd.OnAdClicked += () =>
		{
			Debug.Log("Interstitial ad was clicked.");
		};
		// Raised when an ad opened full screen content.
		interstitialAd.OnAdFullScreenContentOpened += () =>
		{
			Debug.Log("Interstitial ad full screen content opened.");
		};
		// Raised when the ad closed full screen content.
		interstitialAd.OnAdFullScreenContentClosed += () =>
		{
			RequestInterstitial();
			Debug.Log("Interstitial ad full screen content closed.");
		};
		// Raised when the ad failed to open full screen content.
		interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
		{
			RequestInterstitial();
			Debug.LogError("Interstitial ad failed to open full screen content " +
						   "with error : " + error);
		};
	}
	public void ShowInterstitial()
	{
		try
		{
			if (PlayerPrefs.GetInt("ADSUNLOCK").Equals(0))
			{
				if (IsInternetConnection())
				{
					if (CheckInitilization())
					{
						if (_interstitialAd != null && _interstitialAd.CanShowAd())
						{
							Debug.Log("Showing interstitial ad.");
							_interstitialAd.Show();
						}
						else
						{
							Debug.LogError("Interstitial ad is not ready yet.");
						}
					}
				}
			}
		}
		catch
		{
		}
	}



	public void LoadRewardedAd()
	{

		// Clean up the old ad before loading a new one.
		if (_rewardedAd != null)
		{
			DestroyAd();
		}

		Debug.Log("Loading rewarded ad.");

		// Create our request used to load the ad.
		var adRequest = new AdRequest.Builder().Build();

		// Send the request to load the ad.
		RewardedAd.Load(rewardedID, adRequest, (RewardedAd ad, LoadAdError error) =>
{
	// If the operation failed with a reason.
	if (error != null)
	{
		Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
		return;
	}
	// If the operation failed for unknown reasons.
	// This is an unexpected error, please report this bug if it happens.
	if (ad == null)
	{
		Debug.LogError("Unexpected error: Rewarded load event fired with null ad and null error.");
		return;
	}

	// The operation completed successfully.
	Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
	_rewardedAd = ad;

	// Register to ad events to extend functionality.
	RegisterEventHandlers(ad);

	// Inform the UI that the ad is ready.
	//AdLoadedStatus?.SetActive(true);
});
	}

	/// <summary>
	/// Shows the ad.
	/// </summary>
	public void ShowRewardedAd()
	{
		if (_rewardedAd != null && _rewardedAd.CanShowAd())
		{
			Debug.Log("Showing rewarded ad.");
			_rewardedAd.Show((Reward reward) =>
			{
				RewardSystem.instance.GiveCoins();
            });
		}
		else
		{
			Debug.LogError("Rewarded ad is not ready yet.");
		}

		// Inform the UI that the ad is not ready.
		//AdLoadedStatus?.SetActive(false);
	}

	/// <summary>
	/// Destroys the ad.
	/// </summary>
	public void DestroyAd()
	{
		if (_rewardedAd != null)
		{
			Debug.Log("Destroying rewarded ad.");
			_rewardedAd.Destroy();
			_rewardedAd = null;
		}

		// Inform the UI that the ad is not ready.
		//AdLoadedStatus?.SetActive(false);
	}

	/// <summary>
	/// Logs the ResponseInfo.
	/// </summary>
	public void LogResponseInfo()
	{
		if (_rewardedAd != null)
		{
			var responseInfo = _rewardedAd.GetResponseInfo();
			UnityEngine.Debug.Log(responseInfo);
		}
	}

	private void RegisterEventHandlers(RewardedAd ad)
	{
		// Raised when the ad is estimated to have earned money.
		ad.OnAdPaid += (AdValue adValue) =>
		{
			Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
				adValue.Value,
				adValue.CurrencyCode));
		};
		// Raised when an impression is recorded for an ad.
		ad.OnAdImpressionRecorded += () =>
		{
			Debug.Log("Rewarded ad recorded an impression.");
		};
		// Raised when a click is recorded for an ad.
		ad.OnAdClicked += () =>
		{
			Debug.Log("Rewarded ad was clicked.");
		};
		// Raised when the ad opened full screen content.
		ad.OnAdFullScreenContentOpened += () =>
		{
			Debug.Log("Rewarded ad full screen content opened.");
		};
		// Raised when the ad closed full screen content.
		ad.OnAdFullScreenContentClosed += () =>
		{
			Debug.Log("Rewarded ad full screen content closed.");
		};
		// Raised when the ad failed to open full screen content.
		ad.OnAdFullScreenContentFailed += (AdError error) =>
		{
			Debug.LogError("Rewarded ad failed to open full screen content with error : "
				+ error);
		};
	}

}