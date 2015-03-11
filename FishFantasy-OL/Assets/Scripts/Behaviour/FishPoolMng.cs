using UnityEngine;
using System.Collections;

public class FishPoolMng : MonoBehaviour {

	//prefab
	public GameObject roadPrefab;
	public GameObject fishesPrefab;

	private GameObject road;

	void Awake () {


	}
	// Use this for initialization
	void Start () {
		road = Instantiate (roadPrefab) as GameObject;

		createFishAndSwimming ("黄金鲨", "1鱼组");
		createFishAndSwimming ("绿金鲨", "1鱼组");

		createFishAndSwimming ("蝴蝶鱼", "1鱼组");

		createFishAndSwimming ("黄灯笼鱼", "1鱼组");
		createFishAndSwimming ("红灯笼鱼", "1鱼组");
		createFishAndSwimming ("绿灯笼鱼", "1鱼组");

		createFishAndSwimming ("绿龟", "1鱼组");
		createFishAndSwimming ("绿龟", "1鱼组");

		createFishAndSwimming ("金鳝鱼", "1鱼组");
		createFishAndSwimming ("红鳝鱼", "1鱼组");

		createFishAndSwimming ("小丑鱼", "1鱼组");
		createFishAndSwimming ("小丑鱼", "1鱼组");
		createFishAndSwimming ("小丑鱼", "1鱼组");
		
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
		createFishAndSwimming ("小黄鱼", "1鱼组");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createFishAndSwimming(string fishName, string groupName)
	{
		GameObject fishPrefab =  fishesPrefab.transform.Find(fishName).gameObject;
		
		
		GameObject groupObj = road.transform.Find (groupName).gameObject;
		Group group = groupObj.GetComponent<Group> ();

		GameObject fish = Instantiate(fishPrefab) as GameObject;
		FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour> ();

		fishBehaviour.StartSwimming (group);
	}

	private void createFish(string fishName, string groupName, string pathsName)
	{
		GameObject fishPrefab =  fishesPrefab.transform.Find(fishName).gameObject;
		GameObject road = Instantiate (roadPrefab) as GameObject;

		GameObject groupObj = road.transform.Find (groupName).gameObject;
		Group group = groupObj.GetComponent<Group> ();
		//random paths
		GameObject paths = groupObj.transform.Find (pathsName).gameObject;
		
		for (int k = 0; k < group.fishNum; k++) 
		{
			string str = k.ToString();
			GameObject path = paths.transform.Find (str).gameObject;
			GameObject fish = Instantiate(fishPrefab) as GameObject;
			FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour> ();
			//fishBehaviour.itweenPath = path.GetComponent<iTweenPath> ();
		}
	}
}
