using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class CanvasMain : AbstractBehaviour,IInterfaceBehaviour {

	[SerializeField]
	private MainDataManager _main_data_manager;
	// Use this for initialization

	public void Initialize(){
		InitImages();
	}

	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	//イメージの読込み
	private void InitImages(){

		List<JsonData> _data_list = new List<JsonData>();
		List<JsonData> _data_list_1 = _main_data_manager.GetAllData();
		
		//画面を埋め尽くすデータ作成
		CreateDataList(_data_list,_data_list_1);
		CreateDataList(_data_list,_data_list_1);
		CreateDataList(_data_list,_data_list_1);
		CreateDataList(_data_list,_data_list_1);
		CreateDataList(_data_list,_data_list_1);
		ShuffleList(_data_list);


		 for (int i = 0; i < 48; i++)
		{
			JsonData _data = _data_list[i];
			//Debug.Log(_data);
			//Debug.Log(Config.GetBaseURL()  + "/" + "images/" +   _data_list[i]["imgs"][0] + ".png");
			//Texture2D _texture = TextureUtil.ReadTexture(Config.GetBaseURL() + "/images/l/" +  _data_list[i]["imgs"][0] + ".png");

			//string _texture_str = Config.GetBaseURL()  + "/" + "images/" +   _data_list[i]["imgs"][0] + ".png";
			//Debug.Log(_texture_str);
			//Texture2D _texture = TextureUtil.ReadTexture(_texture_str);

			//Debug.Log(Config.GetBaseURL() + "/images/l/" +  _data_list[i]["imgs"][0] + ".png");
			// Debug.Log(GameObject.Find("ImageTriangle" + i)); 
			//テクスチャーを描画
			//Debug.Log(GameObject.Find("ImageTriangle" + i));	
			//GameObject.Find("ImageTriangle" + (i+1)).GetComponent<GUITexture>().texture =  TextureUtil.ReadTexture(Config.GetBaseURL() + "/images/l/" +  _data_list[i]["imgs"][0] + ".png");
		
			string _base_texture = Config.GetBaseURL() + "/images/l/" +  _data_list[i]["imgs"][0];



			



			//GameObject.Find("ImageTriangle" + (i+1)).GetComponent<Sprite>().images =  TextureUtil.ReadTexture( + "/images/l/" +  _data_list[i]["imgs"][0] + ".png");
			

		}
	}

	private void CreateDataList(List<JsonData> _list, List<JsonData> _list_additional){
		for (int i = 0; i < _list_additional.Count; i++)
		{
			JsonData _tmp_data = _list_additional[i];
			_list.Add(_tmp_data);
			Debug.Log(_list.Count);
		}

	}

	private void ShuffleList (List<JsonData> _list) {
		for (int i = 0; i < _list.Count; i++) {
			JsonData temp = _list[i];
			int randomIndex = UnityEngine.Random.Range(0, _list.Count);
			_list[i] = _list[randomIndex];
			_list[randomIndex] = temp;
		}
	}

	


	
	
}
