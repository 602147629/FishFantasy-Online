using UnityEngine;
using System.Collections;

public class LoginCtl : MonoBehaviour {

	ClientApp	clientApp;

	void Awake()
	{
		clientApp = GameObject.FindGameObjectWithTag ("clientApp").GetComponent<ClientApp> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartBtnClick()
	{
		clientApp.login();
	}

	public void OnRegistBtnClick()
	{
		clientApp.createAccount ();
	}
}
