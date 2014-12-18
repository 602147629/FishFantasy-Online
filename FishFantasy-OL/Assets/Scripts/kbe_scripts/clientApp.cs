using UnityEngine;
using System; 
using System.Collections; 
using KBEngine;

public class ClientApp : MonoBehaviour {

public KBEngineApp gameapp = null;
	
	// 在unity3d界面中可见选项
	public bool isMultiThreads = true;
	public string ip = "127.0.0.1";
	public int port = 3306;
	public KBEngineApp.CLIENT_TYPE clientType = KBEngineApp.CLIENT_TYPE.CLIENT_TYPE_MINI;
	public string persistentDataPath = "Application.persistentDataPath";
	public bool syncPlayer = true;
	public int HZ_TICK = 100;
	public int SEND_BUFFER_MAX = (int)KBEngine.NetworkInterface.TCP_PACKET_MAX;
	public int RECV_BUFFER_MAX = (int)KBEngine.NetworkInterface.TCP_PACKET_MAX;

	private string m_stringAccount = "device_id";
	private string m_stringPasswd = "";

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
 
	// Use this for initialization
	void Start () 
	{
		MonoBehaviour.print("clientapp::start()");
		installEvents();
		initKBEngine();

		Application.LoadLevel("Login");
	}

	void installEvents()
	{
		KBEngine.Event.registerOut("onKicked", this, "onKicked");
		KBEngine.Event.registerOut("onCreateAccountResult", this, "onCreateAccountResult");
		KBEngine.Event.registerOut("onDisableConnect", this, "onDisableConnect");
		KBEngine.Event.registerOut("onConnectStatus", this, "onConnectStatus");
	}

	void uninstallEvents()
	{
		KBEngine.Event.deregisterOut(this);
	}

	void initKBEngine()
	{
		// 如果此处发生错误，请查看 Assets\Scripts\kbe_scripts\if_Entity_error_use______git_submodule_update_____kbengine_plugins_______open_this_file_and_I_will_tell_you.cs
		
		KBEngineArgs args = new KBEngineArgs();
		
		args.ip = ip;
		args.port = port;
		args.clientType = clientType;
		
		if(persistentDataPath == "Application.persistentDataPath")
			args.persistentDataPath = Application.persistentDataPath;
		else
			args.persistentDataPath = persistentDataPath;
		
		args.syncPlayer = syncPlayer;
		args.HZ_TICK = HZ_TICK;
		
		args.SEND_BUFFER_MAX = (UInt32)SEND_BUFFER_MAX;
		args.RECV_BUFFER_MAX = (UInt32)RECV_BUFFER_MAX;
		
		if(isMultiThreads)
			gameapp = new KBEngineAppThread(args);
		else
			gameapp = new KBEngineApp(args);
	}
	
	void OnDestroy()
	{
		MonoBehaviour.print("clientapp::OnDestroy(): begin");
		KBEngineApp.app.destroy();
		uninstallEvents();
		MonoBehaviour.print("clientapp::OnDestroy(): end");
	}
	
	void FixedUpdate () 
	{
		KBEUpdate();
	}

	void KBEUpdate()
	{
		// 单线程模式必须自己调用
		if(!isMultiThreads)
			gameapp.process();
		
		KBEngine.Event.processOutEvents();
	}

	// fire msg to server
	public void login()
	{
		print("connect to server...(连接到服务端...)");

		KBEngine.Event.fireIn("login", new object[]{m_stringAccount, m_stringPasswd});
	}

	public void createAccount()
	{
		print("connect to server...(连接到服务端...)");
		
		KBEngine.Event.fireIn("createAccount", new object[]{m_stringAccount, m_stringPasswd});
	}

	// callback from server msg
	public void onCreateAccountResult(UInt16 retcode, byte[] datas)
	{
		if(retcode != 0)
		{
			print("createAccount is error(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode));
			return;
		}
		
		if(KBEngineApp.validEmail(m_stringAccount))
		{
			print("createAccount is successfully, Please activate your Email!(注册账号成功，请激活Email!)");
		}
		else
		{
			print("createAccount is successfully!(注册账号成功!)");
		}
	}

	public void onKicked(UInt16 failedcode)
	{
		print("kick, disconnect!, reason=" + KBEngineApp.app.serverErr(failedcode));
		//Application.LoadLevel("login");
	}

	public void onConnectStatus(bool success)
	{
		if(!success)
			print("connect is error! (连接错误)");
		else
			print("connect successfully, please wait...(连接成功，请等候...)");
	}

	public void onDisableConnect()
	{
	}

}
