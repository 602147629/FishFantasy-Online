using UnityEngine;
using System.Collections;

public class FishPoolMng : MonoBehaviour {

	//prefab
	public GameObject roadPrefab;
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

		//random fish
		fishPrefab =  fishesPrefab.transform.Find("绿金鲨").gameObject;
		road = Instantiate (roadPrefab) as GameObject;
		
		//random group
		groups = road.transform.Find ("1鱼组").gameObject;
		groupBeh = groups.GetComponent<Groups> ();
		//random paths
		paths = groups.transform.Find ("path0").gameObject;
		
		for (int k = 0; k < groupBeh.fishNum; k++) 
		{
			string str = k.ToString();
			GameObject path = paths.transform.Find (str).gameObject;
			GameObject fish = Instantiate(fishPrefab) as GameObject;
			FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour> ();
			fishBehaviour.itweenPath = path.GetComponent<iTweenPath> ();
		}

		fishPrefab =  fishesPrefab.transform.Find("蝴蝶鱼").gameObject;
		road = Instantiate (roadPrefab) as GameObject;
		
		//random group
		groups = road.transform.Find ("1鱼组").gameObject;
		groupBeh = groups.GetComponent<Groups> ();
		//random paths
		paths = groups.transform.Find ("path2").gameObject;
		
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

	private void createFish(string fishName, string groupsName, string pathsName)
	{
		GameObject fishPrefab =  fishesPrefab.transform.Find(fishName).gameObject;
		GameObject road = Instantiate (roadPrefab) as GameObject;
		
		//random group
		GameObject groups = road.transform.Find (groupsName).gameObject;
		Groups groupBeh = groups.GetComponent<Groups> ();
		//random paths
		GameObject paths = groups.transform.Find (pathsName).gameObject;
		
		for (int k = 0; k < groupBeh.fishNum; k++) 
		{
			string str = k.ToString();
			GameObject path = paths.transform.Find (str).gameObject;
			GameObject fish = Instantiate(fishPrefab) as GameObject;
			FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour> ();
			fishBehaviour.itweenPath = path.GetComponent<iTweenPath> ();
		}
	}
}
