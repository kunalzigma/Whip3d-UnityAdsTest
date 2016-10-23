using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UnityVideoAdsBoth : MonoBehaviour {

		//You can add zoneId from the inspector
		public string zoneId;

		private Button AdButton;


		void Start () {
				AdButton = this.GetComponent<Button>();
				//onClick code in start. Add this code, only if you haven't set up onClick in inspector in unity. 
				if(AdButton)
				{
						AdButton.onClick.AddListener(delegate() {
								ShowAdPlacement(); 
						});
				}



		}

		void Update () 
		{
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
