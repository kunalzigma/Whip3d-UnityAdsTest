using UnityEngine;
using System.Collections;

public class Texture : MonoBehaviour {
	public GUIStyle buttonStyle, dropdownStyle,buttonText,silenceText,effectText;
	public Texture2D tex1button = null, tex2button = null, tex3button = null, tex4button = null, tex5button = null, tex6button = null, Arrow= null;
	float buttonWidth = Screen.width/2; 
	float buttonHeight = Screen.height/17; 
	float borderPadding = Screen.height/30; 
	bool meet = false, slowmo=false;
	public static bool showDialog= false;
	int i=0;
	public GameObject player;
	public Material[] material1;
	public Font myfont;
	bool rateme,firstrun;
	int timesRun;
	// Use this for initialization
	void Start () {
		player.GetComponent<Renderer>().material = material1[0];
		//Time.timeScale = 2.0f;
				PlayerPrefs.SetInt("timesRun",1);
		//Rate this app Logic
		int timesRun = PlayerPrefs.GetInt( "timesRun");
		//timesRun = 0;


		if(timesRun ==0)
			firstrun=true;
		if( timesRun == 3 )
		{
			rateme= true;
		//	PlayerPrefs.SetInt( "HasPlayed", 1 );
		}
		 if(timesRun <= 3)
		{	
			timesRun ++;
			PlayerPrefs.SetInt("timesRun", timesRun);
		//	i = Random.Range (1, 5);
			// Not First Time
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI () {
		
		GUI.backgroundColor = Color.black;
		if(Time.timeScale==0.0)
		{
//			if(GetComponent<AudioSource>().isPlaying)
//				this.GetComponent<AudioSource>().Stop();
			GUI.enabled=false;
			
		}
		
		
		
		float borderPadding = Screen.height/30; 
		float dropdownbuttonheight = Screen.height/5;
		float dropdownbuttonwidth = Screen.width/(20/10) + Screen.width/40;
		buttonStyle = new GUIStyle();
		dropdownStyle = new GUIStyle();
		buttonText = new GUIStyle();
		silenceText = new GUIStyle();
		effectText = new GUIStyle();
		
		dropdownStyle.normal.textColor = Color.white;
		//buttonText.normal.textColor = Color.white;
		buttonStyle.normal.textColor = Color.white;
		silenceText.normal.textColor = Color.cyan;
		effectText.normal.textColor = Color.white;

		//buttonText.normal.background= GUI.skin.button.active.background;
	//	buttonText.alignment = TextAnchor.UpperCenter;
	//	buttonText.font = myfont;

		effectText.normal.background = GUI.skin.button.active.background;
		effectText.alignment = TextAnchor.MiddleCenter;
		effectText.font = myfont;


		dropdownStyle.alignment = TextAnchor.MiddleCenter;
		dropdownStyle.font = myfont;

		GUI.skin.box.font = myfont;

		GUI.skin.button.font = myfont;
	//	GUI.skin.box.font = silenceText;
				silenceText.font = myfont;
		GUI.skin.box.normal.textColor = Color.cyan;

		if (Screen.width<480)
		{
			dropdownStyle.fontSize = 9;
			buttonText.fontSize=9;
			silenceText.fontSize = 14 ;
			effectText.fontSize =9;
			GUI.skin.box.fontSize=20;
			GUI.skin.button.fontSize=9;
		}
		else if(Screen.width< 720 && Screen.width>=480)
		{
			dropdownStyle.fontSize= 18;
			buttonText.fontSize=22;
			silenceText.fontSize = 22;
			effectText.fontSize =22;
			GUI.skin.box.fontSize=22;
			GUI.skin.button.fontSize=18;
		}
		else if(Screen.width>=720 && Screen.width<=800)
		{
			dropdownStyle.fontSize= 30;
			buttonText.fontSize=30;
			silenceText.fontSize = 30;
			effectText.fontSize =30;
			GUI.skin.box.fontSize=35;
			GUI.skin.button.fontSize=30;
		}
		else if(Screen.width>800)
		{
			dropdownStyle.fontSize=42;
			buttonText.fontSize=42;
			silenceText.fontSize = 45;
			effectText.fontSize =42;
			GUI.skin.box.fontSize=45;
			GUI.skin.button.fontSize=42;
		}
		//	Color c = GUI.backgroundColor;

		
	  buttonStyle.normal.background= GUI.skin.button.onFocused.background;
		
		Vector2 positionOfDropDown = new Vector2(0, Screen.height - (Screen.height/17) );
		
		Vector2 positionOfBoostButton = new Vector2(0, Screen.height - buttonHeight - borderPadding);  
		
		Rect R = new Rect(positionOfBoostButton.x, positionOfBoostButton.y, buttonWidth, buttonHeight);
		

		Rect dropDownRect = new Rect(Screen.width/3,Screen.height/7,dropdownbuttonwidth,((Screen.height/3)*2));
	
		//Change Texture Button
		if (GUI.Button (new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width / 3), Screen.height / 17), "Select Texture")) { 
			if(meet==false)
			{
			meet = true;

			}
			else if(meet==true)
			{
				meet= false;
			}
				} 

	//	GUI.Label(new Rect (positionOfDropDown.x, positionOfDropDown.y, (Screen.width / 3), Screen.height / 17), "Select Texture", dropdownStyle);


		//Slow-motion button
	
			if (slowmo == false) {

						if (GUI.Button (new Rect (positionOfDropDown.x + ((Screen.width / 3) * 2), positionOfDropDown.y, (Screen.width / 3), Screen.height / 17), "Slowmo")) { 
			
								slowmo = true;
						}
						
				} else if (slowmo == true) {	

			if (GUI.Button (new Rect (positionOfDropDown.x + ((Screen.width / 3) * 2), positionOfDropDown.y, (Screen.width / 3), Screen.height / 17), "Normal Motion")) { 
				
				slowmo = false;
			}
				}
		if (meet == true) {
						showDialogOne ();
						
				}
		else {
			showDialog=false;
				}



	
		//Rate me button
		if (rateme == true) {
			showRateDialog();
		}

		//First run dialog
		if(firstrun == true)
		{
			showfirsttimeDialog();
		}






		if (slowmo == false) {
						Time.timeScale = 1.5f;
						WhipAnim.au_whip.pitch = 1.0f;
				} else if (slowmo == true) {

						Time.timeScale = 0.6f;
			WhipAnim.au_whip.pitch = 0.4f;
				}


		}
	public void showDialogOne()
	{
		//GUI.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		showDialog = true;

		GUI.Box (new Rect (Screen.width/6, Screen.height/6, (Screen.width/3)*2, (Screen.height/3)*2), "Select Texture");
		GUI.backgroundColor = Color.black;

		//GUI.color = Color.white;

		//Tex1 Button
		if (GUI.Button (new Rect ((Screen.width / 2)-Screen.width/3, (Screen.height /6) + (Screen.height /35), ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex1button, buttonStyle)) {

			player.GetComponent<Renderer>().material = material1[0];meet=false;
				}

		//Tex2 Button
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height /6) + (Screen.height /35), ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex2button, buttonStyle)) {
			
			player.GetComponent<Renderer>().material = material1[1];meet=false;
		}

		//Tex3 Button
		if (GUI.Button (new Rect ((Screen.width / 2)-Screen.width/3, (Screen.height /6) + (Screen.height /29) + (((Screen.width /4) +(Screen.width/3))/2) , ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex3button, buttonStyle)) {

			player.GetComponent<Renderer>().material = material1[2];meet=false;
			
		}
		//Tex4 Button
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height /6) + (Screen.height /29) + (((Screen.width /4) +(Screen.width/3))/2) , ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex4button, buttonStyle)) {
			
			player.GetComponent<Renderer>().material = material1[3];meet=false;
		}
		//Tex5 Button
		if (GUI.Button (new Rect ((Screen.width / 2)-Screen.width/3, (Screen.height /6) + (Screen.height /29) + (2*(((Screen.width /4) +(Screen.width/3))/2)) , ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex5button, buttonStyle)) {
			
			player.GetComponent<Renderer>().material = material1[4];meet=false;
		}
		//Tex6 Button 
		if (GUI.Button (new Rect ((Screen.width / 2), (Screen.height /6) + (Screen.height /29) + (2*(((Screen.width /4) +(Screen.width/3))/2)) , ((Screen.width /4) +(Screen.width/3))/2, ((Screen.width /4) +(Screen.width/3))/2), tex6button, buttonStyle)) {
			
			player.GetComponent<Renderer>().material = material1[5];meet=false;
		}


		//Close Button
		if (GUI.Button (new Rect ((Screen.width/2)- Screen.width/12, Screen.height/2 + (Screen.height/4), Screen.width / 6, Screen.height / 17), "Close")) {
		

			meet=false;
				}

		//GUI.Box (new Rect (10, 10, 200, 200), "A Smaller Box");
	}

	void showRateDialog()

	{

		GUI.Box (new Rect (Screen.width/2-(((Screen.width/3)*2)/2), Screen.height/2-(((Screen.height/4)*2)/2), (Screen.width/3)*2, (Screen.height/4)*2), "If you like this app, \n please rate it");

	//	GUI.Label (new Rect (Screen.width/2-(((Screen.width/3)*2)/2) + Screen.width/30 , Screen.height/2-(((Screen.height/5)*2)/3), (Screen.width/9)*2, (Screen.height/4)*2), "If you like this app, please rate it", silenceText );

		if (GUI.Button (new Rect (Screen.width / 2 - (((Screen.width / 3) * 2) / 2) + Screen.width /6, Screen.height / 2 - (((Screen.height / 5) * 2) / 3) + Screen.height/10, (Screen.width / 6) * 2, (Screen.height / 32) * 2), " Yes, sure")) {
			rateme=false;
			Application.OpenURL("itms-apps://itunes.apple.com/us/app/whip-animated-3d/id933474248?ls=1&mt=8");
		
			PlayerPrefs.SetInt("timesRun", 5);
				}
		if (GUI.Button (new Rect (Screen.width / 2 - (((Screen.width / 3) * 2) / 2) + Screen.width /6, Screen.height / 2 - (((Screen.height / 5) * 2) / 3) + Screen.height/10 + Screen.height/12 , (Screen.width / 6) * 2, (Screen.height / 32) * 2), " No")) {
			rateme= false;
			PlayerPrefs.SetInt("timesRun", 5);

		}
		if (GUI.Button (new Rect (Screen.width / 2 - (((Screen.width / 3) * 2) / 2) + Screen.width /6, Screen.height / 2 - (((Screen.height / 5) * 2) / 3) + Screen.height/10 + (2*(Screen.height/12))  , (Screen.width / 6) * 2, (Screen.height / 32) * 2), " Maybe, Later ")) {
			PlayerPrefs.SetInt("timesRun", 3);
			rateme=false;
		}


	}

	void showfirsttimeDialog()
		
	{

		GUI.Box (new Rect (Screen.width/40, Screen.height/9, Screen.width - ((Screen.width/40)*2),Screen.height), "How to play? \n\n Shake phone or Touch the Whip \n Left Arrow - Select from 6 textures \n Right arrow - Slow motion of whip crack\n\n Click 'Got it' to begin");
		
		if( GUI.Button ( new Rect ((Screen.width/10), Screen.height - (Screen.height/7), Screen.width/8, Screen.height/7), Arrow, buttonStyle))
		{}
		if( GUI.Button ( new Rect ((Screen.width/10)*8,Screen.height - (Screen.height/7), Screen.width/8, Screen.height/7), Arrow, buttonStyle))
		{}   
		//	Time.timeScale = 0.0f;
		
		if( GUI.Button (new Rect (Screen.width / 2 - (((Screen.width / 3) * 2) / 2) + Screen.width /6,Screen.height/2 + Screen.height/30, (Screen.width / 6) * 2, (Screen.height / 32) * 2), " Got it"))
		{
			firstrun= false;
		} 
	}


	}

