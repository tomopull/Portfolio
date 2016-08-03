using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using LitJson;

public class Main : AbstractBehaviour,IInterfaceBehaviour {

	//ゲームのデータ管理
	private MainModel _main_model;

	private MainModel.SimpleTouch ActiveTouch;

	public void Initialize(){

		//init all managers
		InitManager ();
		//Init ();
		PlayerPrefs.DeleteAll ();
	}

	//スワイプかタッチか判別
	private void CaluculateTouchInput(MainModel.SimpleTouch CurrentTouch){
		Vector2 touchDirection  = (CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation).normalized;
		float touchDistance     = (CurrentTouch.StartTouchLocation - CurrentTouch.CurrentTouchLocation).magnitude;
		TimeSpan timeGap        = System.DateTime.Now - CurrentTouch.StartTime;
		double touchTimeSpan    = timeGap.TotalSeconds;
		string touchType        = ( touchDistance > _main_model.SwipeDistance && touchTimeSpan > _main_model.SwipeTime ) ? "Swipe" : "Tap";
	}

	//各マネージャー、モデル初期化
	private void InitManager(){
	
		_main_model = MainModel.Instance;
	}

	//初期化
	private void Init(){
		LoadFile ();
	}

	//外部ファイルのロード
	private void LoadFile(){
		StartCoroutine("LoadFileCorutine",Config.Json_Path);
	}

	private IEnumerator LoadFileCorutine(string _file_path){

		WWW file = new WWW (_file_path);

		yield return file;

		JsonData json_data = LitJson.JsonMapper.ToObject(file.text);

		//ローカルにオリジナルjsonデータ保存
		_main_model.OriginalJsonData = json_data;

		
		Debug.Log(json_data.Count);
		for (int i = 0; i < json_data.Count; i++)
		{
			// Debug.Log(json_data[i]["title"]);
			// Debug.Log(json_data[i]["imgs"]);
			// Debug.Log(json_data[i]["detail"]);
		}
	}

	// Update is called once per frame
	void Update () {

		if(Application.isEditor){

			if (Input.GetMouseButton (0)) {

				if (ActiveTouch.Phase == TouchPhase.Canceled) {

					ActiveTouch.CurrentTouchLocation = Input.mousePosition;
					ActiveTouch.StartTouchLocation = Input.mousePosition;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.Phase = TouchPhase.Began;

				} else {

					ActiveTouch.CurrentTouchLocation = Input.mousePosition;

				}

			} else {

				if (ActiveTouch.Phase == TouchPhase.Began) {

					CaluculateTouchInput (ActiveTouch);
					ActiveTouch.Phase = TouchPhase.Canceled;

				}

			}

		}else{

			if (Input.touches.Length > 0) {

				_main_model.DeviceTouch = Input.GetTouch (0);

				if (ActiveTouch.Phase == TouchPhase.Canceled) {

					ActiveTouch.Phase = _main_model.DeviceTouch.phase;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.StartTouchLocation = _main_model.DeviceTouch.position;
					ActiveTouch.CurrentTouchLocation = _main_model.DeviceTouch.position;
				
				} else {

					ActiveTouch.CurrentTouchLocation = _main_model.DeviceTouch.position;

				}

			} else {

				if(ActiveTouch.Phase != TouchPhase.Canceled){
					CaluculateTouchInput (ActiveTouch);
					ActiveTouch.Phase = TouchPhase.Canceled;
	
				}

			}
		}
		
	}

}

