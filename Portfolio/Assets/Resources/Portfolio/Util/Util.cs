
using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;

using System.Text.RegularExpressions;




static public class Util  {


	public const string RECURSIVE = "_recursive";
	public const string NORMAL = "_normal";
	//カスタムログ
	static public void CustomLog(DataObject _obj, string _type = NORMAL){

		//オブジェクトのプロパティーの再帰出力

		//ノーマル出力
		if(_type == NORMAL){
			UnityEngine.Debug.Log("test");
		} 

	}


	//数字だけ抜き出す
	static public string GetStringOnly(string _str){
		Regex re = new Regex(@"[^0-9]");
		string _return_str  = re.Replace(_str, "");
		return _return_str;
	}

	static public void Shuffle(int[] deck) {
		for (int i = 0; i < deck.Length; i++) {
			int temp = deck[i];
			int randomIndex = UnityEngine.Random.Range(0, deck.Length);
			deck[i] = deck[randomIndex];
			deck[randomIndex] = temp;
		}
	}
		
	/// <summary>
	/// リソースのprefabから複製
	/// </summary>
	static public GameObject InstantiateUtil(string resource_path,Vector3 default_position,Quaternion default_quaernion, Transform parent){
		GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(Config.PrefabResourceBasePath + resource_path),default_position ,default_quaernion);

		//自動的につく(cloneの文字を除去処理 名称をresource_pathのみにする)
		obj.name = resource_path;

		//親のGameObjectの設定
		if(parent != null){
			//obj.transform.parent = parent;
			obj.transform.SetParent(parent);
		}

		// Transform初期化
		Transform tran = obj.transform;
    	tran.localPosition = Vector3.zero;
   		tran.localRotation = Quaternion.identity;
   		tran.localScale = Vector3.one;

		return obj;
	}


	// public static void AddListener(this UIBehaviour uiBehaviour, EventTriggerType eventID, UnityAction<BaseEventData> callback)
    // {
	// 	//button.AddListener(EventTriggerType.PointerUp, e => Debug.Log("PointerUp!"));
    //     var entry = new EventTrigger.Entry();
    //     entry.eventID = eventID;
    //     entry.callback.AddListener(callback);

    //     var eventTriggers = (uiBehaviour.GetComponent<EventTrigger>() ?? uiBehaviour.gameObject.AddComponent<EventTrigger>()).triggers;
    //     eventTriggers.Add(entry);
    // }

    // public static void RemoveAllListeners(this UIBehaviour uiBehaviour, EventTriggerType eventID)
    // {
    //     var eventTrigger = uiBehaviour.GetComponent<EventTrigger>();

    //     if (eventTrigger == null)
    //         return;

    //     eventTrigger.triggers.RemoveAll(listener => listener.eventID == eventID);
    // }


	/// <summary>
	/// ボタンイベントの設定
	/// _obj:GameObject
	/// _unity_action:UIEventHandler.Instance.OnPointerClick
	/// _event_trigger_typ:EventTriggerType.PointerClick;
	/// </summary>
	/// <param name="_button">_button.</param>
	/// <param name="_event">_event.</param>
	static public void SetButtonEvent(GameObject _obj, UnityAction<BaseEventData> _action, EventTriggerType _event_trigger_type){

		
		//既にEventTriggerComponentが追加されていなかったら追加
		//既にEventTriggerComponentが追加されていたらコンポーネント取得
		EventTrigger _event_triger;

		if(!_obj.GetComponent<EventTrigger> ()){

			_event_triger = _obj.AddComponent<EventTrigger> ();

			EventTrigger.Entry _entry = new EventTrigger.Entry ();

			_entry.callback.AddListener (_action);

			_entry.eventID = _event_trigger_type;

			_event_triger.triggers = new List<EventTrigger.Entry> ();

			_event_triger.triggers.Add (_entry);

		}else{

			_event_triger = _obj.GetComponent<EventTrigger> ();

			EventTrigger.Entry _entry = new EventTrigger.Entry ();

			_entry.callback.AddListener (_action);

			_entry.eventID = _event_trigger_type;

			_event_triger.triggers = new List<EventTrigger.Entry> ();

			_event_triger.triggers.Add (_entry);
		}

		
		//Debug.Log (_obj);
		//_event_triger = _obj.AddComponent<EventTrigger> ();
		//_event_triger.triggers = UIEventHandler.Instance.EntryList;
		//UIEventHandler.Instance.EntryDict.Add(_obj.name,_entry);
		//_event_triger.triggers = new List<EventTrigger.Entry> ();
		//_event_triger.triggers.Add (_entry);
		//Debug.Log (_event_triger.triggers.Count);
		//Debug.Log (_event_triger.triggers.Count);

	}

	/// <summary>
	/// remove button event
	/// </summary>
	/// <param name="_obj">_obj.</param>
	/// <param name="_action">_action.</param>
	/// <param name="_event_trigger_type">_event_trigger_type.</param>
	static public void RemoveButtonEvent(GameObject _obj, EventTrigger.Entry _entry, UnityAction<BaseEventData> _action){

		//既にEventTriggerComponentが追加されボタン化されていたらボタン無効化
		if (_obj.GetComponent<EventTrigger> ()) {

			EventTrigger _event_triger = _obj.GetComponent<EventTrigger> ();

			_entry.callback.RemoveListener (_action);
				
		}

	}

}
