using UnityEngine;
using System.Collections;
using KBEngine;
using System; 


public class LoginCtl : MonoBehaviour {

	ClientApp   clientApp;
    KBEPluginIF    pluginIF;

    private string m_stringAccount = "device_id";
    private string m_stringPasswd = "";
	void Awake()
	{
		clientApp = GameObject.FindGameObjectWithTag ("clientApp").GetComponent<ClientApp> ();
        pluginIF = clientApp.PluginIF;
	}
	// Use this for initialization
	void Start () {
        pluginIF.RegisterOnLoginFailed(this, "onLoginFailed");
        pluginIF.RegisterOnLoginSuccessfully(this, "onLoginSuccessfully");
        pluginIF.RegisterOnCreateAccountResult(this, "onCreateAccountResult");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        pluginIF.Deregister(this);
    }
	public void OnStartBtnClick()
	{
        pluginIF.Login("device_id", "");
	}
	public void OnRegistBtnClick()
	{
        pluginIF.CreateAccount("device_id", "");
	}
    // callback from server msg
    public void onCreateAccountResult(UInt16 retcode, byte[] datas)
    {
        if (retcode != 0)
        {
            print("createAccount is error(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode));
            return;
        }

        if (KBEngineApp.validEmail(m_stringAccount))
        {
            print("createAccount is successfully, Please activate your Email!(注册账号成功，请激活Email!)");
        }
        else
        {
            print("createAccount is successfully!(注册账号成功!)");
        }
    }
    public void onLoginFailed(UInt16 failedcode)
    {
        if (failedcode == 20)
        {
            print("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
        }
        else
        {
            print("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }
    }
    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, Account accountEntity)
    {
        print("login is successfully! (登录成功!)");

        //需要loading和异步加载
        Application.LoadLevel("FishPool");
    }
}
