using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class MainModel : AbstractBehaviour,IInterfaceBehaviour {


	public void Initialize(){
		
	}

	//オリジナルjson data
	[SerializeField]
	private JsonData original_json_data;
	public JsonData OriginalJsonData{get { return this.original_json_data; } set { this.original_json_data = value; }}

	//ゲームオブジェクトデータ
	[SerializeField]
	private Dictionary<string,DataObject> object_data_dict;
	public Dictionary<string,DataObject> ObjectDataDict{get { return this.object_data_dict;} set { this.object_data_dict = value;}}

	//ネイティブデバイスタッチ
	[SerializeField]
	private Touch deviceTouch;
	public Touch DeviceTouch{get { return this.deviceTouch; } set { this.deviceTouch = value; }}

	//スワイプの距離
	[SerializeField]
	private float swipeTime;
	public float SwipeTime{	get { return this.swipeTime; } set { this.swipeTime = value; }}

	//スワイプ時間
	[SerializeField]
	private float swipeDistance;
	public float SwipeDistance{	get { return this.swipeDistance; } 	set { this.swipeDistance = value; }}


	//シンプルタッチストラクト
	public struct SimpleTouch{public Vector2 StartTouchLocation;	public Vector2 CurrentTouchLocation;	public DateTime StartTime;	public TouchPhase Phase;}

	private static MainModel instance = null;
	public static MainModel Instance {

		get {	
				return MainModel.instance;	
			}
	}

	void Awake()
	{
		if( instance == null)

		{

			instance = this;

		}else{

			Destroy( this );

		}
		//DontDestroyOnLoad(this); // シーン読み込みの際に破棄されなくなる
			
	}
		
}
	