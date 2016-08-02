
using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;

static public class Util  {

	static public void Shuffle (int[] deck) {
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
	static public GameObject InstantiateUtil(GameModel _game_model, string resource_path,Vector3 default_position,Quaternion default_quaernion){
		GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(Config.PrefabResourceBasePath + resource_path),default_position ,default_quaernion);
		//自動的につく(cloneの文字を除去処理 名称をresource_pathのみにする)
		obj.name = resource_path;
		return obj;
	}

	/// <summary>
	/// get text component and set the component's string to selected new text
	/// </summary>
	/// <returns>The text to text component util.</returns>
	/// <param name="_str">_str.</param>
	/// <param name="_new_text">_new_text.</param>
	static public Text SetTextToTextComponentUtil(string _str,Text _new_text){
		_new_text = GameObject.Find (_str).GetComponent<Text> ();
		return _new_text;
	}

	/// <summary>
	/// テキストのストリングを更新
	/// </summary>
	/// <returns>The text string util.</returns>
	static public string UpdateTextStringUtil(Text _text, string _string){
		_text.text = _string;
		return _string;
	}

	/// <summary>
	/// ボタンイベントの設定
	/// _obj:GameObject
	/// _unity_action:UIEventHandler.Instance.OnPointerClick
	/// _event_trigger_typ:EventTriggerType.PointerClick;
	/// </summary>
	/// <param name="_button">_button.</param>
	/// <param name="_event">_event.</param>
	static public void SetButtonEvent(GameObject _obj, UnityAction<BaseEventData> _action, EventTriggerType _event_trigger_type){

		//既にEventTriggerComponentが追加されボタン化されていなかったらボタン化
		if (!_obj.GetComponent<EventTrigger> ()) {
		
			//Debug.Log (_obj);
			EventTrigger _event_triger = _obj.AddComponent<EventTrigger> ();

			EventTrigger.Entry _entry = new EventTrigger.Entry ();

			_entry.callback.AddListener (_action);

			_entry.eventID = _event_trigger_type;

			_event_triger.triggers = new List<EventTrigger.Entry> ();
			_event_triger.triggers.Add (_entry);

			//_event_triger.triggers = UIEventHandler.Instance.EntryList;
			//UIEventHandler.Instance.EntryDict.Add(_obj.name,_entry);
			//_event_triger.triggers = new List<EventTrigger.Entry> ();
			//_event_triger.triggers.Add (_entry);
			//Debug.Log (_event_triger.triggers.Count);
			//Debug.Log (_event_triger.triggers.Count);
		}

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
