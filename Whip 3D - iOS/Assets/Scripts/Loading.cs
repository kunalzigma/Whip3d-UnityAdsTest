using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	Vector2 positionOfDropDown = new Vector2(0, Screen.height/2+Screen.height/4);
	bool showText= false;

	int i ;

	public Font myfont1 ; 	
	// Use this for initialization
	void Start () {

		StartCoroutine(Load());

		int hasPlayed = PlayerPrefs.GetInt( "HasPlayed");
		
		if( hasPlayed == 0 )
		{
			// First Time
			// Initialize...etc
			i = 0;
			PlayerPrefs.SetInt( "HasPlayed", 1 );
		}
		else
		{	
			i = Random.Range (1, 5);
			// Not First Time
		}
	}
	void OnGUI() {
		GUI.skin.label.fontSize = 12;
		GUI.skin.label.font = myfont1;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;

		if (Screen.width<480)
		{

			GUI.skin.label.fontSize=13;
		
		}
		else if(Screen.width< 720 && Screen.width>=480)
		{
			GUI.skin.label.fontSize=18;
		}
		else if(Screen.width>=720 && Screen.width<=800)
		{
			GUI.skin.label.fontSize=30;
		}
		else if(Screen.width>800)
		{
			GUI.skin.label.fontSize=42;

		}
		//GUI.color = Color.blue;
		if(i ==0)
		GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Touch the whip or shake device\n\nMight take few more seconds to load for the first time on some devices. After that, it is fast.");

		else if (i == 1)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Slow motion is actually ~1/3 of normal motion in this app");

		else if (i == 2)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Section of whip moves faster than speed of sound while whip cracking ");

		else if (i == 3)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Simply Shake phone or Touch the whip");

		else if (i == 4)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Best experience it on iPad");

	
		else if (i == 5)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Rate app after pressing back key while using Whip");


		else if (i == 6)
			GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width), Screen.height / 5), "Feedback/Suggestions are welcome as comments while rating app");


		}


	IEnumerator Load()
	{
		#if UNITY_IPHONE
	//	Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
		#elif UNITY_ANDROID

		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		#endif
		Handheld.StartActivityIndicator();

		if(i == 0)
		yield return new WaitForSeconds (0);
		else 
			yield return new WaitForSeconds (2);
		Application.LoadLevel(2);

		
	}
	

}
