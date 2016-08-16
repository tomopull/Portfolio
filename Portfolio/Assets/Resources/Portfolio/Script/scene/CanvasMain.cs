using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using LitJson;
using UniRx;

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

		 for (int i = 0; i < 49; i++)
		{
			JsonData _data = _data_list[i];
			int select_index_max = _data_list[i]["imgs"].Count;
			int select_index = Random.Range(0,select_index_max);			
			string _base_url = "Portfolio" + "/images/l/" +  _data_list[i]["imgs"][select_index];
			Texture2D _texture = Resources.Load(_base_url) as Texture2D;
			//Debug.Log(_texture);
			
	 		if(GameObject.Find("ImageTriangle" + i) != null){
				Image img =  GameObject.Find("Image" + i).GetComponent<Image>();
				img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);
				Button btn = (Button)GameObject.Find("btn_1").GetComponent<Button>();
				btn.onClick.AsObservable().Subscribe(_ =>  { ShowDatail(_data_list[i]); } );
			 }

		}
		
	}

	private void ShowDatail(JsonData _data){
		Debug.Log( (_data["id"] as IJsonWrapper).GetInt() );	
		Debug.Log( (_data["title"] as IJsonWrapper).GetString());
		Debug.Log( (_data["year"] as IJsonWrapper).GetInt());
		Debug.Log( (_data["category"] as IJsonWrapper).GetInt());
		Debug.Log( (JsonData)_data["tag"]);
		Debug.Log( (_data["mov"] as IJsonWrapper).GetString());
		Debug.Log( (JsonData)_data["imgs"]);
		Debug.Log( (_data["detail"] as IJsonWrapper).GetString());	
	}

	private void CreateDataList(List<JsonData> _list, List<JsonData> _list_additional){
		for (int i = 0; i < _list_additional.Count; i++)
		{
			JsonData _tmp_data = _list_additional[i];
			_list.Add(_tmp_data);
			//Debug.Log(_list.Count);
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
