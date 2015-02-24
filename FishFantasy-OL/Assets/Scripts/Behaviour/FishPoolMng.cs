using UnityEngine;
using System.Collections;

public class FishPoolMng : MonoBehaviour {

	//prefab
	public GameObject roadPrefab;
	//prefab
	public GameObject fishesPrefab;

	void Awake () {


	}
	// Use this for initialization
	void Start () {

		//random fish
		GameObject fishPrefab =  fishesPrefab.transform.Find("黄金鲨").gameObject;
		GameObject road = Instantiate (roadPrefab) as GameObject;

		//random group
		GameObject groups = road.transform.Find ("3鱼组").gameObject;
		Groups groupBeh = groups.GetComponent<Groups> ();
		//random paths
		GameObject paths = groups.transform.Find ("path0").gameObject;

		for (int k = 0; k < groupBeh.fishNum; k++) 
		{
			string str = k.ToString();
			GameObject path = paths.transform.Find (str).gameObject;
			GameObject fish = Instantiate(fishPrefab) as GameObject;
			FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour> ();
			fishBehaviour.itweenPath = path.GetComponent<iTweenPath> ();
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
