using UnityEngine;
using System.Collections;
//using GoogleMobileAds.Api;


public class GUIbutton : MonoBehaviour {
	public Texture2D buttonImage= null, newImage=null,silenceimage=null;
	public static AudioSource au_horn, au_effect, au_main;

	public AudioClip police,sound2,airhorn;
	public AudioClip[] listaudio;
	public int j;
	public bool buttonDown = false, mousedown, soundbutton=false, lastState=false, firsttime=true,wasPlaying=false, horndown=false, listopen=false,listscroll=false;
	public static bool cameraLock=false;
	private Touch touch;

	Vector2 bottomLeft;
	public GUIStyle buttonStyle, dropdownStyle,buttonText,silenceText,effectText;
//	public float timeThreshold = 0.1;
	private Vector2 scrollViewVector = Vector2.zero;

	public static string[] list = {"-Click to Play-","Police Siren","Ambulance","-Select and Play-","Yelp","Phaser","Wail","Two Tone", "Manual Wail","Mechanical","-Voice Effects-","     -Below-","Scroll from here","Pull Over","Hands in air","Step out","Step back", "Keep Hands"};

	public float delayTimer = .25f;

	int indexNumber,effectNumber=4;
	bool show = false, play= false;
	int p=0, q=0;
	float slotheight;

	//public GoogleAnalyticsV3 googleAnalytics;


	float buttonWidth = Screen.width/5; 
	float buttonHeight = Screen.height/7; 

	void Start()
	{   //For drop down
		//object1 = gameObject.Find("object1");
		//n=0;i=0;wichcountry=0;
		//au_police = (AudioSource) gameObject.AddComponent("AudioSource");

	//	Police= (AudioClip)Resources.Load("Sounds/Police_Siren");
	//	audio.clip=Police;

	//	au_main = gameObject.AddComponent<AudioSource>();
	//	au_horn = gameObject.AddComponent<AudioSource>();
	//	au_effect = gameObject.AddComponent<AudioSource>();
		au_effect = gameObject.AddComponent<AudioSource>();
		au_effect.clip = listaudio[0];
		
		au_horn = gameObject.AddComponent<AudioSource>();
		au_horn.clip = airhorn;
		
		au_main = gameObject.AddComponent<AudioSource>();
		au_main.clip = police;
		au_main.loop=true;
		//renderer.enabled = false;

	//	au_horn = gameObject.AddComponent<AudioSource>();
		/*
		listaudio =  new AudioClip[]{Resources.Load("Sounds/yelp") as AudioClip,
		Resources.Load("Sounds/mechanical") as AudioClip, 
			Resources.Load("Sounds/phaser") as AudioClip, 
			Resources.Load("Sounds/two_tone") as AudioClip
			, 
			Resources.Load("Sounds/wail") as AudioClip
			, 
			Resources.Load("Sounds/manual_wail") as AudioClip};
*/

//	bottomLeft = new Vector2(0,Screen.height/2);

		/*

			// Create a 320x50 banner at the top of the screen.
			BannerView bannerView = new BannerView(
			"ca-app-pub-9225879057400559/1652353224", AdSize.SmartBanner, AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("8B04264F2F06A831CA82E7A8B29C92CD").AddTestDevice("99A1E81E4FB096486F51BD23C3B0166B").AddTestDevice("E3C976748045607BE059D5D4833E1C91").AddTestDevice("DCBA7D383A7AF0D9F9A14432E7445B16").Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);

		googleAnalytics.LogScreen("Police Siren Scene");

*/
	}

	void OnGUI () {


		if(Time.timeScale==0.0)
		{
			if(GetComponent<AudioSource>().isPlaying)
			this.GetComponent<AudioSource>().Stop();
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
		buttonText.normal.textColor = Color.blue;
		buttonStyle.normal.textColor = Color.red;
		silenceText.normal.textColor = Color.cyan;
		effectText.normal.textColor = Color.white;

		if (Screen.width<480)
		{
			dropdownStyle.fontSize = 18;
			buttonText.fontSize=13;
			silenceText.fontSize = 13;
			effectText.fontSize =13;
		}
		else if(Screen.width< 720 && Screen.width>=480)
		{
		dropdownStyle.fontSize= 30;
			buttonText.fontSize=22;
			silenceText.fontSize = 22;
			effectText.fontSize =22;
		}
		else if(Screen.width>=720 && Screen.width<=800)
		{
			dropdownStyle.fontSize= 45;
			buttonText.fontSize=35;
			silenceText.fontSize = 35;
			effectText.fontSize =35;
		}
		else if(Screen.width>800)
		{
			dropdownStyle.fontSize=60;
			buttonText.fontSize=48;
			silenceText.fontSize = 48;
			effectText.fontSize =48;
		}
	//	Color c = GUI.backgroundColor;
		GUI.backgroundColor = Color.black;
		 
		buttonStyle.normal.background= GUI.skin.button.onFocused.background;

		Vector2 positionOfDropDown = new Vector2(((buttonWidth*6)/5), Screen.height - ((buttonHeight)/15)*18);

		Vector2 positionOfBoostButton = new Vector2(0, Screen.height - buttonHeight - borderPadding);  

			Rect R = new Rect(positionOfBoostButton.x, positionOfBoostButton.y, buttonWidth, buttonHeight);


		if (GUI.RepeatButton(R, buttonImage, buttonStyle)) 
			{ 	
				//Debug.Log("MouseDown");
				soundbutton= true;

			}
				// and reset it when mouse button released:
				soundbutton &= Input.GetMouseButton(0);
				// now speedButton can be verified:
				if (soundbutton != lastState){ // if button changed state...
					lastState = soundbutton; // register current state
					if (soundbutton){ 

						// if button down define the thresholdime
					//	speedTime = Time.time + timeThreshold;
					if(!horndown)
					{
						au_horn = gameObject.AddComponent<AudioSource>();
						au_horn.clip = airhorn;
						au_horn.loop=true;	
						au_horn.Play();
						horndown=true;
					}
					else
					{
						//	au_horn.enabled=true;
					//	au_horn.clip = airhorn;
						au_horn.loop=true;
						au_horn.Play();
						}
					} else {
						// if button up select speed according to time elapsed
				//		speed = (Time.time > speedTime)? 10 : 5;
					au_horn.Stop();
					}
				}

		float total = ((buttonWidth*6)/5) + dropdownbuttonwidth  +   (((buttonWidth*6)/5)-buttonWidth);
		Rect L = new Rect(total, positionOfBoostButton.y, buttonWidth, buttonHeight);



		if (GUI.Button(L, newImage, buttonStyle)) 
		{ 

			//Debug.Log("MouseDown");
			if(!play)
			{
				play = true;
				p++;

			}
			else
			{
				play = false;
			}
	


			if(play)
			{	
				if(p>0)
				{
					//au_effect = gameObject.AddComponent<AudioSource>();
				//	au_effect.clip = listaudio[0];
						
					au_effect.Play();
					buttonDown=true;

				//	GUI.Label(new Rect(Screen.width/3, (positionOfDropDown.y+((Screen.height/17)/10)), (Screen.width/2),  dropdownbuttonheight), list[3],dropdownStyle);
				}
			/*
				else
				{
					au_effect.Play();
				}
				*/
				q=1;
				StartCoroutine("MyMethod");
				if(au_main.isPlaying)
				{au_main.Pause();
					wasPlaying=true;
		
				}
			//	yield return new WaitForSeconds(au_effect.clip.length);
			}
			else
			{

				au_effect.Pause();
				StopCoroutine("MyMethod");

				q=0;
				if(wasPlaying==true)
					au_main.Play();
			}
		}


		Rect Sil = new Rect(Screen.width/4+(Screen.width/8), positionOfDropDown.y + (Screen.height/10), buttonWidth, buttonHeight);
	

		if (GUI.Button(Sil, silenceimage, buttonStyle)) 
		{
			StopCoroutine("MyMethod");
				//	GUI.Label(new Rect(total+ ((buttonWidth)/5), positionOfBoostButton.y+(buttonHeight/4), buttonWidth, buttonHeight), "Effect\n Play",buttonText);
			if(q==1)
			{
				au_effect.Stop();
				q=0;
				play = false;
			}

			else if(au_main.isPlaying)
			au_main.Stop();
				wasPlaying = false;
				//wasPlaying=true;
				


		}
		GUI.Label(new Rect(Screen.width/5+(Screen.width/5), positionOfDropDown.y + (Screen.height/9), buttonWidth, buttonHeight), "Silence",silenceText);
		
		//For effect play/pause button
		if(q==0)
		{
			GUI.Label(new Rect(total+ ((buttonWidth)/5), positionOfBoostButton.y+(buttonHeight/5), buttonWidth, buttonHeight), "Effect\n Play",buttonText);
			//	GUI.Label(new Rect(Screen.width/3, positionOfBoostButton.y+(dropdownbuttonheight), (Screen.width/2), dropdownbuttonheight), "testing label", dropdownStyle);
			
			
		}
		else if(q==1)
		{
			GUI.Label(new Rect(total+ ((buttonWidth)/5), positionOfBoostButton.y+(buttonHeight/5), buttonWidth, buttonHeight), "Effect\n Stop",buttonText);
			//	GUI.Label(new Rect(Screen.width/3, positionOfBoostButton.y+(dropdownbuttonheight), (Screen.width/2), dropdownbuttonheight), "Effect Selected", dropdownStyle);
			
			
		}

		// EFFECT SELECTED LABEL
		if(indexNumber>=0 && indexNumber <=3)
		{
			//StopCoroutine("MyMethod");
			//StartCoroutine("MyMethod");
		
			GUI.Label(new Rect(Screen.width/4+(Screen.width/32), positionOfDropDown.y  + (Screen.height/17), buttonWidth, buttonHeight), "Selected-"+list[effectNumber],effectText);
			
		}
		else if(indexNumber>=4)
		{//  StopCoroutine("MyMethod");
			//StartCoroutine("MyMethod");
			effectNumber=indexNumber;
			GUI.Label(new Rect(Screen.width/4+(Screen.width/32), positionOfDropDown.y  + (Screen.height/17), buttonWidth, buttonHeight), "Selected-"+list[effectNumber],effectText);
		}






		Rect dropDownRect = new Rect(Screen.width/3,Screen.height/7,dropdownbuttonwidth,((Screen.height/3)*2));
		slotheight = dropDownRect.height/12;
		//Drop Down List
		if(GUI.Button(new Rect(positionOfDropDown.x, positionOfDropDown.y, (Screen.width/2), Screen.height/17), ""))
		{ 
			cameraLock=true; listopen=true;
				if(!show)
			{
				show = true;

			}
			else
			{
				show = false;
			}
		}
		
		if(show)
		{
			scrollViewVector = GUI.BeginScrollView(new Rect(positionOfDropDown.x, (positionOfDropDown.y - ((26/2)*(Screen.height/17))), dropDownRect.width, (dropDownRect.height/8)*9),scrollViewVector,new Rect(0, 0, dropDownRect.width, Mathf.Max((dropDownRect.height/8)*12, (list.Length*17))));

			GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height*2, (list.Length*14))), "");
			
			for(int index = 0; index < list.Length; index++)
			{
				if(index!=0&&index!=3 && index!=10 && index!=11 && index!=12)
				{
					if(listscroll==false)
					{
					if(GUI.Button(new Rect(0, (slotheight*index), dropdownbuttonwidth,( Screen.height/17)), ""))
				{

							if(buttonDown==false)
							{
								au_effect = gameObject.AddComponent<AudioSource>();

							}
					show = false;
					indexNumber = index;
				if(firsttime == true)
						{
							au_main = gameObject.AddComponent<AudioSource>();

						}
					if(indexNumber==0)
						{
						}
						if(indexNumber==1)
						{   
						//this.gameObject.AddComponent<AudioSource>();
						au_main.clip = police;
							au_main.Play();
							au_main.loop=true;
							firsttime=false;
						}
						else if(indexNumber==2)
						{
							au_main.clip = sound2;
							au_main.Play();
							au_main.loop=true;
							firsttime=false;
						}
					else if(indexNumber==3)
					{

					}
							
							else if (indexNumber==4)
							{ 

								au_effect.clip = listaudio[0];
								buttonDown=true;
						
							}
						else if (indexNumber==5)
						{ 
							
							au_effect.clip = listaudio[1];
							buttonDown=true;
						}
				
						else if (indexNumber==6)
						{ 
							
							au_effect.clip = listaudio[2];
							buttonDown=true;
						}
						else if (indexNumber==7)
						{ 
							
							au_effect.clip = listaudio[3];
							buttonDown=true;
						}
						else if (indexNumber==8)
						{ 
							
							au_effect.clip = listaudio[4];
							buttonDown=true;
						}
						else if (indexNumber==9)
						{ 
							
							au_effect.clip = listaudio[5];
							buttonDown=true;
						}
						else if (indexNumber==10)
						{

						}
						else if (indexNumber==11)
						{

						}
						else if (indexNumber==12)
						{
							
						}
						else if (indexNumber==13)
						{ 
						au_effect.clip = listaudio[6];
							buttonDown=true;
						}
						else if (indexNumber==14)
						{ 
							au_effect.clip = listaudio[7];
							buttonDown=true;
						}
						else if (indexNumber==15)
						{ 
							
							au_effect.clip = listaudio[8];
							buttonDown=true;
						}
						else if (indexNumber==16)
						{ 
							
							au_effect.clip = listaudio[9];
							buttonDown=true;
						}
						else if (indexNumber==17)
						{ 
							
							au_effect.clip = listaudio[10];
							buttonDown=true;
						}
						if(q==1)
						{
							au_effect.Play();
							StopCoroutine("MyMethod");
							StartCoroutine("MyMethod");
						}

				}
					}

				
					GUI.Label(new Rect(Screen.width/40, ((slotheight*index)+((slotheight)/5)), (Screen.width/2),  dropdownbuttonheight), list[index],dropdownStyle);
				}

				else
				{
					GUI.Label(new Rect(Screen.width/40, ((slotheight*index)+((slotheight)/5)), (Screen.width/2),  dropdownbuttonheight), list[index],dropdownStyle);
				}
			}


			GUI.EndScrollView();  

		}
		else
		{
			GUI.Label(new Rect(Screen.width/4, (positionOfDropDown.y+((Screen.height/17)/10)), (Screen.width/2),  dropdownbuttonheight), list[indexNumber],dropdownStyle);
			cameraLock = false;
			listopen=false;

		}




	}
	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(au_effect.clip.length);
		//(!au_effect.isPlaying)
	//	{
		q=0;
		play=false;
		if(wasPlaying==true)
			au_main.Play();
		Debug.Log("After Waiting 2 Seconds");
	//	}
	}
	IEnumerator Myscroll() {
		//Debug.Log("Scrolling");
		listscroll=true;
		yield return new WaitForSeconds(0.35f);
		listscroll=false;
	//	Debug.Log("Not Scrolling");
		//	}
	}
	float oldPosition;
	void Update()  {
	
		if(listopen==true)
		{ 
		if(Input.touchCount >0)
		{
			
			touch = Input.touches[0];

			if (touch.phase == TouchPhase.Moved )
				{ 


				//	oldPosition = touch.position.y;
				
					oldPosition= scrollViewVector.y;
				//	scrollViewVector.y = oldPosition; 
					scrollViewVector.y += touch.deltaPosition.y* 5f;
					if(scrollViewVector.y> (oldPosition + 3.5F) || oldPosition> (scrollViewVector.y+3.5F))
					{		StopCoroutine("Myscroll");
						StartCoroutine("Myscroll");
						oldPosition= scrollViewVector.y;
					}


					//GUI.Label(new Rect(Screen.width/2, Screen.height/2, (Screen.width/2), Screen.height/2)," ",dropdownStyle);
			
					//	listscrolling=true;
				//scrollViewVector.x += touch.deltaPosition.x;
			}
			
		}

			//listscrolling=false;


		}

/*
		if (Input.touchCount != 1)
		{
			//selected = -1; 
			
			if ( scrollVelocity != 0.0f )
			{
				// slow down over time
				float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp(scrollVelocity, 0, t);
				scrollViewVector.y += frameVelocity * Time.deltaTime;
				
				// after N seconds, we've stopped
				if (t >= inertiaDuration) scrollVelocity = 0.0f;
			}
			return;
		}
	*/	
		
	}




}
