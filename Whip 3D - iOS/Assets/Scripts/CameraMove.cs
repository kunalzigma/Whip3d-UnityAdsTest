using UnityEngine;

using System.Collections;



public class CameraMove : MonoBehaviour {
	
	public Transform target;
	
	public float distance= 1.5f;
	
	public int cameraSpeed= 5;
	
	
	
	public float xSpeed= 175.0f;
	
	public float ySpeed= 75.0f;
	
	public float pinchSpeed;
	
	private float lastDist = 0;
	
	private float curDist = 0;
	
	
	
	public int yMinLimit= 10; //Lowest vertical angle in respect with the target.
	
	public int yMaxLimit= 80;
	
	
	
	public float minDistance= .5f; //Min distance of the camera from the target
	
	public float maxDistance= 1.5f;
	
	
	
	private float x= 0.0f;
	
	private float y= 0.0f;
	
	private Touch touch;
	
	

	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.


	void  Start (){

		Time.timeScale = 1.0f;
		Vector3 angles= transform.eulerAngles;
		
		x = angles.y;
		
		y = angles.x;
		
		
		
		// Make the rigid body not change rotation
		
		if (GetComponent<Rigidbody>())
			
			GetComponent<Rigidbody>().freezeRotation = true;
		
	}
	
	
	
	void  Update (){





		if (target && GetComponent<Camera>()) {
			if(Time.timeScale==0.0)
		/*
				GUIbutton.cameraLock=true;
			if(!GUIbutton.cameraLock)
			{
		*/	
			//Zooming with mouse
			
			distance += Input.GetAxis("Mouse ScrollWheel")*distance;
			
			distance = Mathf.Clamp(distance, minDistance, maxDistance);
			

			
			
			
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) 
				
			{
				
				//One finger touch does orbit
				
				touch = Input.GetTouch(0);
					if (touch.position.y > Screen.height/5)
					{

						Debug.Log("Bottom!!");    
					
				x += touch.deltaPosition.x * xSpeed * 0.02f;
				
				y -= touch.deltaPosition.y * ySpeed * 0.02f;
					}
			}
			
			// If there are two touches on the device...
			if (Input.touchCount == 2)
			{
				// Store both touches.
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);
				
				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
				
				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
				
				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				
				// If the camera is orthographic...
				if (GetComponent<Camera>().orthographic)
				{
					// ... change the orthographic size based on the change in distance between the touches.
					GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
					
					// Make sure the orthographic size never drops below zero.
					GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
				}
				else
				{
					// Otherwise change the field of view based on the change in distance between the touches.
					GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					
					// Clamp the field of view to make sure it's between 0 and 180.
					GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 40.0f, 100.0f);
				}
			}
			
			//Detect mouse drag;
			/*
			if(Input.GetMouseButton(0))   {
				
				
				
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;       
				
			}
*/


			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			
			
			Quaternion rotation= Quaternion.Euler(y, x, 0);
			
			Vector3 vTemp = new Vector3(0.0f, 0.0f, -distance);
			
			Vector3 position= rotation * vTemp + target.position;
			
			
			
			transform.position = Vector3.Lerp (transform.position, position, cameraSpeed*Time.deltaTime);
			
			transform.rotation = rotation;      
			
		//}
		
	}
	
	}
	
	static float  ClampAngle ( float angle ,   float min ,   float max  ){
		
		if (angle < -360)
			
			angle += 360;
		
		if (angle > 360)
			
			angle -= 360;
		
		return Mathf.Clamp (angle, min, max);
		
	}
	
	
	
}