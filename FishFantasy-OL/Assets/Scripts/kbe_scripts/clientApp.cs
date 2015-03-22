using UnityEngine;
using System; 
using System.Collections; 
using KBEngine;

public class ClientApp : MonoBehaviour {

	public KBEngineApp gameapp = null;
	
	// 在unity3d界面中可见选项
	public bool isMultiThreads = true;
	public string ip = "127.0.0.1";
	public int port = 20013;
	public KBEngineApp.CLIENT_TYPE clientType = KBEngineApp.CLIENT_TYPE.CLIENT_TYPE_MINI;
	public string persistentDataPath = "Application.persistentDataPath";
	public bool syncPlayer = true;
	public int HZ_TICK = 100;
	public int SEND_BUFFER_MAX = (int)KBEngine.NetworkInterface.TCP_PACKET_MAX;
	public int RECV_BUFFER_MAX = (int)KBEngine.NetworkInterface.TCP_PACKET_MAX;

    KBEPluginIF pluginIF = null;

    public KBEPluginIF PluginIF
    {

        get { return this.pluginIF; }

        set { this.pluginIF = value; }

    }
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
 
	// Use this for initialization
	void Start () 
	{
		MonoBehaviour.print("Clientapp::start()");
		initKBEngine();

        pluginIF = new KBEPluginIF();
        pluginIF.RegisterOnConnectStatus(this, "onConnectStatus");
        pluginIF.RegisterOnDisableConnect(this, "onDisableConnect");
        pluginIF.RegisterOnKicked(this, "onKicked");

        //需要以后修改的地方，需要加载资源和验证版本后，完全准备好进入登录页面。
		Application.LoadLevel("Login");
	}
	void initKBEngine()
	{
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
        //clientIF.Deregister(this);

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

    // callback from server msg
    public void onKicked(UInt16 failedcode)
    {
        Debug.Log("kick, disconnect!, reason=" + KBEngineApp.app.serverErr(failedcode));
    }

    public void onConnectStatus(bool success)
    {
        if (!success)
            Debug.Log("connect is error! (连接错误)");
        else
            Debug.Log("connect successfully, please wait...(连接成功，请等候...)");
    }

    public void onDisableConnect()
    {
        Debug.Log("connect is disable! (无法连接)");
    }

   
}
