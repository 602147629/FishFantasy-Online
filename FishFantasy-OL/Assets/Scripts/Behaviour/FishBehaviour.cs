using UnityEngine;
using System.Collections;
using System;

public class FishBehaviour : MonoBehaviour {
	
	public float speed = 1f;

	private Vector3 lastPosition;
	
	private Group group;

	void Awake ()
	{


	}
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = gameObject.transform.position - lastPosition;
		float angle = Vector3.Angle(Vector3.right, dir);

		if (dir.y < 0)
			angle = -angle;

		iTween.RotateUpdate (gameObject, iTween.Hash ("rotation", new Vector3(0, 0, angle),
		                                              "time", 0.5f
													 )
				            );

		lastPosition = gameObject.transform.position;
	}

	public void StartSwimming(Group groupParam)
	{
		group = groupParam;
		int pathNum = group.pathNum;

		int seekSeek = unchecked((int)DateTime.Now.Ticks);
		System.Random ran=new System.Random(seekSeek);
		int RandKey=ran.Next(0,pathNum);
		string pathName = "path" + RandKey.ToString ();

		GameObject path = group.transform.Find (pathName).gameObject;
		iTweenPath itweenPath = path.transform.Find ("0").gameObject.GetComponent<iTweenPath>();

		if (ran.Next() % 2 == 0) 
		{
			itweenPath.nodes.Reverse();
		}
		this.transform.position = itweenPath.nodes.ToArray () [0];
		iTween.MoveTo(gameObject, 
		              iTween.Hash ("path", itweenPath.nodes.ToArray (),
		             			   "speed", speed,
		             			   "easeType", iTween.EaseType.linear,
		             			   "oncomplete", "OnNextSwimming", 
		             			   "oncompletetarget", gameObject
		             			  )
		              );
	}

	void OnNextSwimming()
	{
		int pathNum = group.pathNum;
		System.Random ran=new System.Random();
		int RandKey=ran.Next(0,pathNum);
		string pathName = "path" + RandKey.ToString ();
		
		GameObject path = group.transform.Find (pathName).gameObject;
		iTweenPath itweenPath = path.transform.Find ("0").gameObject.GetComponent<iTweenPath>();
		//this.transform.position = itweenPath.nodes.ToArray () [0];

		if (ran.Next() % 2 == 0) 
		{
			itweenPath.nodes.Reverse();
		}
		this.transform.position = itweenPath.nodes.ToArray () [0];
		iTween.MoveTo(gameObject, 
		              iTween.Hash ("path", itweenPath.nodes.ToArray (),
		             				"speed", speed,
		             				"easeType", iTween.EaseType.linear,
		             				"oncomplete", "OnNextSwimming", 
		             				"oncompletetarget", gameObject
		            			  )
		              );
	}
}
