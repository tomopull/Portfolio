using System;
using System.Collections;
using UnityEngine;


public class Config : AbstractBehaviour{

	//外部ファイルを参照するかリソースフォルダのファイルを参照するか。
	public static string RESOURCES_FILE = "/Resources/";
	public static string STREAMING_ASSETS = "/StreamingAssets/";

	//サイト名をパスのルートに入れる
	[SerializeField]
	static private string _root_path = "Portfolio";
	 
	static public string RootPath{ get { return _root_path; } set { _root_path = value; } }

	//ローカルのjsonのパス
	[SerializeField]
	static private string _json_path = Config.GetBaseURL(Config.STREAMING_ASSETS) + "/Json/data.json";
	static public string Json_Path{ get { return _json_path; } set { _json_path = value; } }

	//prefab base path
	[SerializeField]
	static private string _prefab_resource_base_path = RootPath  + "/Prefabs/";
	static public string PrefabResourceBasePath{ get { return _prefab_resource_base_path; } set { _prefab_resource_base_path = value; } }

	//読み込み外部ファイルのベースのurlの決定
	static public string GetBaseURL(string _asset_path = "/Resources/"){
	
	string base_url = "";

	#if UNITY_EDITOR
		if(_asset_path == RESOURCES_FILE){
			base_url = RootPath;
		}else if(_asset_path == STREAMING_ASSETS){
			base_url = "file://" + Application.streamingAssetsPath + "/" +  RootPath;
		}
		Debug.Log("UNITY_EDITOR");
	#endif

	#if UNITY_IOS
		if(_asset_path == RESOURCES_FILE){
			base_url = RootPath;
		}else if(_asset_path == STREAMING_ASSETS){
			base_url = "file://" + Application.streamingAssetsPath + "/" +  RootPath;
		}
	Debug.Log("IPONE");
	#endif

	#if UNITY_STANDALONE_OSX
	if(_asset_path == RESOURCES_FILE){
			base_url = RootPath;
		}else if(_asset_path == STREAMING_ASSETS){
			base_url = "file://" + Application.streamingAssetsPath + "/" +  RootPath;
		}
		Debug.Log("UNITY_STANDALONE_OSX");
	#endif

	#if UNITY_STANDALONE_WIN
		if(_asset_path == RESOURCES_FILE){
			base_url = RootPath;
		}else if(_asset_path == STREAMING_ASSETS){
			base_url = "file://" + Application.streamingAssetsPath + "/" +  RootPath;
		Debug.Log("UNITY_STANDALONE_WIN");
		}
	#endif

	Debug.Log(base_url);
	return base_url;
}

//2dmodeか3dモードか
public static string GetDisplayMode(string _display_mode){
	return _display_mode;
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
