using UnityEngine;
using System.Collections;

public class CannonBehaviour : MonoBehaviour {

	public GameObject cannon_fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float KeyHorizontal = Input.GetAxis("Horizontal");  

		if(KeyHorizontal == 1)  
		{  
			//right
			cannon_fire.transform.Rotate(new Vector3(0, 0, -10.0f)); 

		}  
		else if(KeyHorizontal == -1)  
		{  
			//left
			cannon_fire.transform.Rotate(new Vector3(0, 0, 10.0f)); 
		} 
	}
}
