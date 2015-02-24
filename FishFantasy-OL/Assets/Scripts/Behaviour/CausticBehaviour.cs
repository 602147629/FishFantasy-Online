using UnityEngine;
using System.Collections;

public class CausticBehaviour : BaseBehaviour {

	//prefab
	public GameObject causticPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmosSelected()
	{
		if (this.transform.Find("caustic(Clone)") == null) 
		{
			int wNum = 7;
			int hNum = 4;
			
			Transform center = this.transform;
			Debug.Log(center.transform.position.y);
			Vector3 beginPoint = new Vector3(center.position.x - 16/2, center.position.y + (float)(9.0/2.0), 0);
			
			for(int i = 0; i< wNum; i++)
			{
				for(int k = 0; k < hNum; k++)
				{
					GameObject caustic = Instantiate(causticPrefab) as GameObject;
					caustic.transform.parent = this.transform;
					float tx = (float)(2.56* i + 2.56/2);
					float ty = (float)(-2.56* k - 2.56/2);
					Vector2 pos = new Vector2(beginPoint.x + tx, (float)beginPoint.y + ty);
					caustic.transform.position = pos;
				}
			}
		}

	}
}
