using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using LitJson;

public class MainScene : MonoBehaviour {

	//ゲームのデータ管理
	private GameModel _game_model;

	private GameModel.SimpleTouch ActiveTouch;

	// Use this for initialization
	void Start () {
		//init all managers
		InitManager ();
		Init ();
		PlayerPrefs.DeleteAll ();
	}

	//スワイプかタッチか判別
	private void CaluculateTouchInput(GameModel.SimpleTouch CurrentTouch){
		Vector2 touchDirection  = (CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation).normalized;
		float touchDistance     = (CurrentTouch.StartTouchLocation - CurrentTouch.CurrentTouchLocation).magnitude;
		TimeSpan timeGap        = System.DateTime.Now - CurrentTouch.StartTime;
		double touchTimeSpan    = timeGap.TotalSeconds;
		string touchType        = ( touchDistance > _game_model.SwipeDistance && touchTimeSpan > _game_model.SwipeTime ) ? "Swipe" : "Tap";
	}

	//各マネージャー、モデル初期化
	private void InitManager(){
		_game_model = GameModel.Instance;
	}

	//初期化
	private void Init(){
		LoadFile ();
	}

	//外部ファイルのロード
	private void LoadFile(){
		StartCoroutine("LoadFileCorutine",_game_model.Json_Path);
	}

	private IEnumerator LoadFileCorutine(string _file_path){

		WWW file = new WWW (_file_path);

		yield return file;

		JsonData data = LitJson.JsonMapper.ToObject(file.text);

		//ローカルにオリジナルjsonデータ保存
		_game_model.OriginalJsonData = data;

		//Debug.Log(data);
		Debug.Log(data.ToString());
		

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

				_game_model.DeviceTouch = Input.GetTouch (0);

				if (ActiveTouch.Phase == TouchPhase.Canceled) {

					ActiveTouch.Phase = _game_model.DeviceTouch.phase;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.StartTouchLocation = _game_model.DeviceTouch.position;
					ActiveTouch.CurrentTouchLocation = _game_model.DeviceTouch.position;
				
				} else {

					ActiveTouch.CurrentTouchLocation = _game_model.DeviceTouch.position;

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

