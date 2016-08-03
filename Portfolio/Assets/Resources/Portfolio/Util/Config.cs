using UnityEngine;
using System.Collections;

public class Config {


	//ローカルのjsonのパス
	[SerializeField]
	static private string _json_path = Config.GetBaseURL() + "/Json/data.json";
	static public string Json_Path{ get { return _json_path; } set { _json_path = value; } }


	//prefab base path
	[SerializeField]
	static private string _prefab_resource_base_path = "Prefabs/";
	static public string PrefabResourceBasePath{ get { return _prefab_resource_base_path; } set { _prefab_resource_base_path = value; } }


	//読み込み外部ファイルのベースのurlの決定
	static public string GetBaseURL(){

		string base_url = "";

		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) {
			//OSX Editor

			base_url = "file://" + Application.dataPath + "/StreamingAssets";

		} else if (Application.platform == RuntimePlatform.OSXPlayer) {
			//PC Mac & linux StandAlone
			base_url = "file://" + Application.dataPath + "/StreamingAssets";

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

}
