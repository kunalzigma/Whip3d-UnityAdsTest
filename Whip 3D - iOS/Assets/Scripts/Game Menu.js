
//var isQuit=false;
//var isAbout=false;

var i :int;
var myfont1:Font;

function Start()
{

}


function OnMouseDown(){
	//change text color
	if(i==0)
	GetComponent.<Renderer>().material.color=Color.red;
	else if(i==2)
	GetComponent.<Renderer>().material.color = Color.blue;
	else if(i==1)
	GetComponent.<Renderer>().material.color = Color.blue;
}

function OnMouseExit(){
	//change text color
	GetComponent.<Renderer>().material.color=Color.white;
	
}
function OnGUI() {
		
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
	


		}

	
		
				
		
function OnMouseUp(){
	//is this about
	if (i==0) {
		
		Application.LoadLevel(1);
		

		
	}
	else if(i==1) {
		//load level
		

	}
	else if(i==2) {
	 Application.OpenURL("https://play.google.com/store/apps/details?id=com.XigXag.policesiren&referrer=utm_source%3DWhipApp");
	}
}

function Update(){
	//quit game if escape key is pressed
	if (Input.GetKey(KeyCode.Escape)) {
    		Application.Quit();
	}
}