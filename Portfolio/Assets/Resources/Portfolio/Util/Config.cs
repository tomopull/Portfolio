using System;
using System.Collections;
using UnityEngine;


public class Config : AbstractBehaviour{


	//サイト名をパスのルートに入れる
	[SerializeField]
	static private string _root_path = "Portfolio";
	static public string RootPath{ get { return _root_path; } set { _root_path = value; } }

	//ローカルのjsonのパス
	[SerializeField]
	static private string _json_path = Config.GetBaseURL() + "/Json/data.json";
	static public string Json_Path{ get { return _json_path; } set { _json_path = value; } }


	//prefab base path
	[SerializeField]
	static private string _prefab_resource_base_path = RootPath  + "/Prefabs/";
	static public string PrefabResourceBasePath{ get { return _prefab_resource_base_path; } set { _prefab_resource_base_path = value; } }


	//読み込み外部ファイルのベースのurlの決定
	static public string GetBaseURL(){

		string base_url = "";

		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) {
			
			//OSX Editor
			base_url = "file://" + Application.dataPath + "/StreamingAssets/" + RootPath;

		} else if (Application.platform == RuntimePlatform.OSXPlayer) {

			//PC Mac & linux StandAlone
			base_url = "file://" + Application.dataPath + "/StreamingAssets/" + RootPath;

		}else if(Application.platform == RuntimePlatform.IPhonePlayer){

			//Iphone
			base_url = "file://" + Application.dataPath + "/Raw";

		} else if(Application.platform == RuntimePlatform.OSXWebPlayer){

			//Web Player
			//絶対パス
			base_url = Application.dataPath;

		}

		return base_url;

	}

	//ネイティブデバイスタッチ
	[SerializeField]
	static private Touch deviceTouch;
	static public Touch DeviceTouch{get { return deviceTouch; } set { deviceTouch = value; }}

	//スワイプの距離
	[SerializeField]
	static private float swipeTime;
	static public float SwipeTime{	get { return swipeTime; } set { swipeTime = value; }}

	//スワイプ時間
	[SerializeField]
	static private float swipeDistance;
	static public float SwipeDistance{	get { return swipeDistance; } 	set { swipeDistance = value; }}

	//シンプルタッチストラクト
	 public struct SimpleTouch{public Vector2 StartTouchLocation;	public Vector2 CurrentTouchLocation;	public DateTime StartTime;	public TouchPhase Phase;}

}
