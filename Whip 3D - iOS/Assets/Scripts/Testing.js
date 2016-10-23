#pragma strict

import UnityEngine.Advertisements;

function Start () {

Advertisement.Initialize ("1175435");

}
/*
var i:int = 1;
function Update()
{
if(Advertisement.IsReady() && i == 1){ 
Advertisement.Show(); 
i = 0;
}
}
*/
function ShowMeAnAdPls()
{
if(Advertisement.IsReady("video")){ 
Advertisement.Show("video"); 
}
}