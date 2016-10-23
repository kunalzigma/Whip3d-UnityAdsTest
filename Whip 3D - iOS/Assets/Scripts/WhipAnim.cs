using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhipAnim : MonoBehaviour {

	public AnimationClip[] allmotions;
	public AudioClip[] listaudio;
	public static AudioSource au_whip;
	int r;
	public static bool shake =false;
	//public GoogleAnalyticsV3 googleAnalytics;
//	public static BannerView bannerView;

		public GameObject panelOnCounterOver;
	
	float shakeThreshold = 5.0f;
	// Use this for initialization
	void Start () {
		for(int i=0; i < allmotions.Length; i++)
			GetComponent<Animation>().AddClip(allmotions[i], "random" + i);

		au_whip = gameObject.AddComponent<AudioSource>();
		au_whip.clip = listaudio[0];
		au_whip.pitch = 1.0f;
	
				/*

			// Create a 320x50 banner at the top of the screen.
			bannerView = new BannerView(
			"ca-app-pub-9225879057400559/3668542826", AdSize.SmartBanner, AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("8B04264F2F06A831CA82E7A8B29C92CD").AddTestDevice("99A1E81E4FB096486F51BD23C3B0166B").AddTestDevice("E3C976748045607BE059D5D4833E1C91").AddTestDevice("DCBA7D383A7AF0D9F9A14432E7445B16").AddTestDevice("23F145D22C72A656A6C6CDF1593B28F7").AddTestDevice("B2C90FB53F61D34BA1A43C405F643907").AddTestDevice("955bb13ae3956f5fb015c10dd848311d").Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
				*/
	//	googleAnalytics.LogScreen("Whip animated scene");

	
		

	}
	 void OnMouseDown() {
		//animation.Play("Armature");
	if(Texture.showDialog == false)
		onShake ();

		//Debug.Log("OnMouseDown");
	}
	public void onShake()
	{
				if(PlayerPrefs.GetInt("counter") != 0)
				{
						
		int random = Random.Range (0, allmotions.Length);
		GetComponent<Animation>().Play ("random" + random);
		PlayAudio ();

				PlayerPrefs.SetInt("counter",PlayerPrefs.GetInt("counter")-1); 
	
				}
				else 
				{
						
						panelOnCounterOver.SetActive(true);
						Time.timeScale = 0.0f;
				}
		}
	//Sound play
	void PlayAudio()
	{
		r = Random.Range (0, listaudio.Length);
		au_whip.clip = listaudio [r];
		au_whip.Play ();


		}



	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetButtonDown ("Fire1")) { 
			animation.Play("Armature"); 
Debug.Log("Animation Playing");
	*/
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
			
								/*
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("--------------");
*/
}
		}
	if (Input.acceleration.sqrMagnitude > shakeThreshold) {

			onShake ();
				}
} 

	}

