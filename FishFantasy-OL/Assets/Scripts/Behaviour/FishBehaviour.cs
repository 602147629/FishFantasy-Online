using UnityEngine;
using System.Collections;

public class FishBehaviour : MonoBehaviour {


	public iTweenPath itweenPath;
	public float speed = 1f;

	private Vector3 lastPosition;

	void Awake ()
	{


	}
	// Use this for initialization
	void Start () {

		this.transform.position = itweenPath.nodes.ToArray () [0];

		iTween.MoveTo(gameObject, 
		              iTween.Hash ("path", itweenPath.nodes.ToArray(),
					               "speed", speed,
					               "easeType", iTween.EaseType.linear
		             			  )
		              );

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
}
