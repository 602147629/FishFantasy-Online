namespace KBEngine
{
	using UnityEngine;
	using System.Collections;

	public class Account :Entity
    {
    	public Account()
		{

		}
		
		public override void __init__()
		{
			Event.fireOut("onLoginSuccessfully", new object[]{KBEngineApp.app.entity_uuid, id, this});
		}
    }
}
