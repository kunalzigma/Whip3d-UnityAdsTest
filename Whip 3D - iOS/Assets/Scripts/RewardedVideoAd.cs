using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class RewardedVideoAd : MonoBehaviour {
	
		public GameObject panelonstart, panelOnCounterOver;
	//	int counter;
		public Text counterText;

		//You can add zoneId from the inspector
		public string zoneId;

		GameObject ButtonGameObject;
		private Button AdButton;


	// Use this for initialization
	void Start () {
				panelonstart.SetActive(true);
				Time.timeScale = 0.0f;
				//PlayerPrefs.SetInt("firststart", 0);
				if(PlayerPrefs.GetInt("firststart") == 0)
				{
						PlayerPrefs.SetInt("counter",5);
						PlayerPrefs.SetInt("firststart", 1);
				}
		
				ButtonGameObject = GameObject.FindGameObjectWithTag("RewardedAdButton");
				AdButton = ButtonGameObject.GetComponent<Button>();
				//onClick code in start. Add this code, only if you haven't set up onClick in inspector in unity. 
				if(AdButton)
				{
						AdButton.onClick.AddListener(delegate() {
						ShowAdPlacement(); 
								//Hide Panel after clicking
								panelOnCounterOver.SetActive(false);
						});
				}
				panelOnCounterOver.SetActive(false);
			//	counter = PlayerPrefs.GetInt("counter");
		}
		public void testButtonPress()
		{
				panelonstart.SetActive(false);
				Time.timeScale = 1.0f;
				Analytics.CustomEvent("counteronstart",
						new Dictionary<string, object>
						{
								{ "counter", PlayerPrefs.GetInt("counter") },

						});
		}
	// Update is called once per frame
	void Update () {
			//	counter --;
				counterText.text = "" + PlayerPrefs.GetInt("counter");
				if(AdButton) 
				{ 
						if(string.IsNullOrEmpty (zoneId))
								zoneId = null;
						AdButton.interactable = Advertisement.IsReady(zoneId);
				}

		}

		void ShowAdPlacement()
		{
				if(string.IsNullOrEmpty(zoneId)) zoneId = null;

				ShowOptions options = new ShowOptions();
				options.resultCallback = HandleShowResult;

				Advertisement.Show(zoneId, options);
		}
		private void HandleShowResult(ShowResult result)
		{
				switch(result)
				{
				case ShowResult.Finished:
						Debug.Log("Both Rewarded/Non-rewarded have this case where User saw whole video. Offer a reward if this is an rewarded zoneId.");
						Debug.Log("5 more hits");
						PlayerPrefs.SetInt("reward",PlayerPrefs.GetInt("reward")+1);
						Analytics.CustomEvent("rewardedgiven",
								new Dictionary<string, object>
								{
										{ "rewardedtimes", PlayerPrefs.GetInt("reward") },

								});
						PlayerPrefs.SetInt("counter",5);
						break;
				case ShowResult.Skipped:
						Debug.Log("Rewarded video ads cant be skipped. Non-rewarded video ads can only have this if skip is enabled.");
						break;
						case ShowResult.Failed:
						Debug.Log("Both rewarded/non-rewarded have this case. Video failed to show");
						break;
				}
		}




}
