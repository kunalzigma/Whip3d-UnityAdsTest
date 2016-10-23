

var guiSkin: GUISkin;
var nativeVerticalResolution = 1920.0;
var isPaused : boolean = false;

 //Top Banner
var topBannerH : float;
var topBannerW : float;
//Buttons
var buttonSizeH : float;
var buttonSizeW : float;
var buttonPos1 : float;
var buttonPos2 : float;
var buttonPos3 : float;
var buttonPos4 : float;
var buttonPos5 : float;
var buttonPosFromLeft : float;
//Bottom Banner
var bottomBannerH : float;
var bottomBannerW : float;
var bottomBannerPos : float;
var exampleVar1 : String;
var customSkin1 : GUISkin;
var customSkin2 : GUISkin;
var customSkin3 : GUISkin; 
var myfont : Font;
var myButtonStyle:GUIStyle;
var myButtonStyle1:GUIStyle;
var pauseimage : Texture2D;
var heightofbutton : float;

 function Awake () {
	topBannerH = Screen.height/2 -( Screen.height/10 + Screen.height/20);
	topBannerW = Screen.width;
	buttonSizeH = Screen.height/10;
	buttonSizeW = Screen.width;
	buttonPos1 = topBannerH;
	buttonPos2 = topBannerH+buttonSizeH;
	buttonPos3 = topBannerH+(2*buttonSizeH);
	buttonPosFromLeft = 0;
	bottomBannerH = Screen.height/4;
	bottomBannerW =  Screen.width;
	bottomBannerPos = topBannerH+buttonSizeH*5;	
	
	 
}
 
function Update()
{
 
     if(Input.GetKeyDown("escape") && !isPaused)
   {
      print("Paused");
      Time.timeScale = 0.0;
      isPaused = true;
      
      GetComponent.<AudioSource>().Pause();
       
   }
   else if(Input.GetKeyDown("escape") && isPaused)
   {
      print("Unpaused");
      Time.timeScale = 1.0;
      isPaused = false;
          
   } 
}
 
function OnGUI ()
{
	heightofbutton = Screen.height/7;
		GUI.skin=customSkin2;
    myButtonStyle = new GUIStyle();
    myButtonStyle.fontSize = 50;
    
    /*
    if(Screen.width>800)
   GUI.skin.button.fontSize = 60;
   // myButtonStyle.fontSize=160;
  else if (Screen.width>=720 && Screen.width<=800)
  GUI.skin.button.fontSize = 50;
  //myButtonStyle.fontSize=120;
      else if (Screen.width>480)
    {
    GUI.skin.button.fontSize = 60;
    //myButtonStyle.fontSize=80;
    
    }
    else if (Screen.width<=480)
    {
    GUI.skin.button.fontSize = 30;
    //myButtonStyle.fontSize = 50;
    }
   */
   
    myButtonStyle.fontSize = 50;
		
		if(Screen.width==960)
		{
	 GUI.skin.button.fontSize = 30;
	heightofbutton = Screen.height/10;
	}
		else if(Screen.width==1136)
		{
			GUI.skin.button.fontSize = 50;
			heightofbutton = Screen.height/10;
		}
		else if (Screen.width==1024)
		         {
			 GUI.skin.button.fontSize=60;
			 heightofbutton = Screen.height/7;

		}
		else if(Screen.width==2048)
		{
			GUI.skin.button.fontSize=160;
			heightofbutton = Screen.height/7;
		}
else if (Screen.width == 1920)
{
GUI.skin.button.fontSize=110;
			heightofbutton = Screen.height/10;
}
else if (Screen.width == 1334)
{
GUI.skin.button.fontSize=50;
			heightofbutton = Screen.height/10;
}
   
   
    //myButtonStyle.normal.textColor= Color.white;
    //myButtonStyle.alignment = TextAnchor.LowerCenter;
    GUI.backgroundColor=Color.black;
   //myButtonStyle.normal.background= GUI.skin.button.active.background;
  // Load and set Font
//    myfont = (Font)Resources.Load("Fonts/policecruisergrad");
    //myButtonStyle.font = myfont;
    GUI.skin.button.font = myfont;
    if(isPaused)
    {  
      // RenderSettings.fogDensity = 1;
    
      if(GUI.Button(Rect(buttonPosFromLeft,buttonPos1,buttonSizeW,buttonSizeH), "Rate this App"))
      {
        // print("Restart");
          Application.OpenURL("itms-apps://itunes.apple.com/us/app/whip-animated-3d/id933474248?ls=1&mt=8");
         Time.timeScale = 1.0;
         isPaused = false;
      }
      if(GUI.Button(Rect(buttonPosFromLeft,buttonPos2,buttonSizeW,buttonSizeH), "Continue"))
      {
         print("Continue");
         Time.timeScale = 1.0;
         isPaused = false;  
         
      }
        if(GUI.Button(Rect(buttonPosFromLeft,buttonPos3,buttonSizeW,buttonSizeH), "Quit to Menu"))
      {
         print("Quit!");
         isPaused = false;
          Time.timeScale = 1.0;
         Application.LoadLevel(0);
      }
      GUI.skin = customSkin3;
	//Bottom Banner
//	GUI.Box(Rect(0,bottomBannerPos,bottomBannerW,bottomBannerH),"");
   } 
   else
 {
 if((GUI.Button(Rect(0,heightofbutton, Screen.width/15, Screen.height/15), pauseimage,myButtonStyle) ) && (PlayerPrefs.GetInt("counter") != 0))
 {
 isPaused = true;
 print("Paused");
      Time.timeScale = 0.0;
    
      
    //  audio.Pause();
 }
 else
 {
 isPaused = false;
  //  print("Unpaused");
  //    Time.timeScale = 1.0;
    
 }
 }
 
 
}
 