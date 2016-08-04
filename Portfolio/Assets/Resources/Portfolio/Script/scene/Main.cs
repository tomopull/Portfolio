using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using LitJson;

public class Main : AbstractBehaviour,IInterfaceBehaviour {

	//MainModel
	[SerializeField]
	private MainModel _main_model;
	public MainModel MainModel{ get { return this._main_model; } set { this._main_model = value; } }
	
	private Config.SimpleTouch ActiveTouch;

	public void Initialize(){
		LoadFile();
		PlayerPrefs.DeleteAll ();
	}

	//外部ファイルのロード
	private void LoadFile(){
		GlobalCoroutine.Go(LoadFileCorutine(Config.Json_Path));
	}
	private IEnumerator LoadFileCorutine(string _file_path){

		WWW file = new WWW (_file_path);
		yield return file;
		
		JsonData json_data = LitJson.JsonMapper.ToObject(file.text);

		//modelの初期化
		_main_model.InitializeData(json_data);		

		
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

				Config.DeviceTouch = Input.GetTouch (0);

				if (ActiveTouch.Phase == TouchPhase.Canceled) {

					ActiveTouch.Phase = Config.DeviceTouch.phase;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.StartTouchLocation = Config.DeviceTouch.position;
					ActiveTouch.CurrentTouchLocation = Config.DeviceTouch.position;
				
				} else {

					ActiveTouch.CurrentTouchLocation = Config.DeviceTouch.position;

				}

			} else {

				if(ActiveTouch.Phase != TouchPhase.Canceled){
					CaluculateTouchInput (ActiveTouch);
					ActiveTouch.Phase = TouchPhase.Canceled;
	
				}

			}
		}
		
	}


	//スワイプかタッチか判別
	private void CaluculateTouchInput(Config.SimpleTouch CurrentTouch){
		Vector2 touchDirection  = (CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation).normalized;
		float touchDistance     = (CurrentTouch.StartTouchLocation - CurrentTouch.CurrentTouchLocation).magnitude;
		TimeSpan timeGap        = System.DateTime.Now - CurrentTouch.StartTime;
		double touchTimeSpan    = timeGap.TotalSeconds;
		string touchType        = ( touchDistance > Config.SwipeDistance && touchTimeSpan > Config.SwipeTime ) ? "Swipe" : "Tap";
	}

}

