using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using LitJson;
using UniRx;

public class CanvasMain : AbstractBehaviour,IInterfaceBehaviour {

	[SerializeField]
	private MainDataManager _main_data_manager;
	// Use this for initialization

	private DetailMain _detail_main;

	private MainModel _main_model;

	[SerializeField]
	private List<JsonData> _all_data_list;
	public List<JsonData> AllDataList{ get { return this._all_data_list; } set { this._all_data_list = value; } }

	public void Initialize(){
		InitImages();
		InitTitleButton();
	}

	public void SetMainModel(MainModel _model){
		_main_model = _model;
	}

	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	public void SetDetailMain(DetailMain _detail){
		 _detail_main = _detail;
	}


	//バオバオ表示に戻るタイトルボタン
	private void InitTitleButton(){
		Button btn = (Button)GameObject.Find("TitleButton").GetComponent<Button>();
		Util.SetButtonEvent(btn.gameObject,ShowBAOBAO,EventTriggerType.PointerClick);
	}

	//バオバオビューを表示する
	private void ShowBAOBAO(BaseEventData _base_event_data){

		if(_main_model.MainModelState != MainModel.BAOBAO_VIEW_STATE){
			
			CanvasMainActivate(true);

			_detail_main.Remove();



		}
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

		//最終決定のリスト
		_all_data_list = _data_list;

		for (int i = 0; i < 49; i++)
		{
			JsonData _data = _data_list[i];
			int select_index_max = _data_list[i]["imgs"].Count;
			int select_index = Random.Range(0,select_index_max);			
			string _base_url = "Portfolio" + "/images/l/" +  _data_list[i]["imgs"][select_index];
			Texture2D _texture = Resources.Load(_base_url) as Texture2D;
		
	 		if(GameObject.Find("ImageTriangle" + i) != null){
				Image img =  GameObject.Find("Image" + i ).GetComponent<Image>();
				img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);
			 }

			 if(GameObject.Find("btn_" + i) != null){

				Button btn = (Button)GameObject.Find("btn_" + i).GetComponent<Button>();
				
				//ボタンにjson data 保存
				btn.GetComponent<ThumbnailData>().JsonData = _data_list[i];
				Util.SetButtonEvent(btn.gameObject,ShowDatail,EventTriggerType.PointerClick);

			}

		}


	}
	
	private void ShowDatail(BaseEventData  _base_event_data){
	
		//JsonData _data =  _main_data_manager.GetDataById( int.Parse(Util.GetStringOnly(_base_event_data.selectedObject.ToString())) );
		JsonData _data =  _base_event_data.selectedObject.GetComponent<Button>().GetComponent<ThumbnailData>().JsonData;

		//デティール表示
		_detail_main.Execute(_data);

		//デテールステート
		_main_model.MainModelState = MainModel.DETAIL_VIEW_STATE;

		//メイン非表示
		CanvasMainActivate(false);

		//Debug.Log( (_data["id"] as IJsonWrapper).GetInt() );	
		// Debug.Log( (_data["title"] as IJsonWrapper).GetString());
		// Debug.Log( (_data["year"] as IJsonWrapper).GetInt());
		// Debug.Log( (_data["category"] as IJsonWrapper).GetInt());
		// Debug.Log( (JsonData)_data["tag"]);
		// Debug.Log( (_data["mov"] as IJsonWrapper).GetString());
		// Debug.Log( (JsonData)_data["imgs"]);
		//Debug.Log( (_data["detail"] as IJsonWrapper).GetString());	
	}

	private void CanvasMainActivate(bool _flag){
		for (int i = 0; i < 49; i++)
		{
			JsonData _data = _all_data_list[i];

	 		if(GameObject.Find("Image" + i) != null){

				GameObject.Find("Image" + i).GetComponent<Image>().enabled = _flag;
				
			 }

		}
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
