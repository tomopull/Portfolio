using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class MainModel : AbstractBehaviour,IInterfaceBehaviour {

	[SerializeField]
	private MainModel _main_model;
	public void Initialize(){
		LoadFile();
		PlayerPrefs.DeleteAll ();
	}

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

	public void InitializeData(JsonData _json_data){
			OriginalJsonData = _json_data;
			
			_data_list = new List<DataObject>();
			_data_dict = new Dictionary<string,DataObject>();
			
			for (int i = 0; i < _json_data.Count; i++)
			{
				DataObject _data = Util.InstantiateUtil("DataObjectPrefab",Vector3.zero,Quaternion.identity).GetComponent<DataObject>();
				_data.Id =(_json_data[i]["id"] as IJsonWrapper).GetInt();
				 _data.Title= (_json_data[i]["title"] as IJsonWrapper).GetString();
				 _data.Year = (_json_data[i]["year"] as IJsonWrapper).GetInt();
				_data.Category =(_json_data[i]["category"] as IJsonWrapper).GetInt();
				_data.TagList = (JsonData)_json_data[i]["tag"];
				 _data.MOV_URL = (_json_data[i]["mov"] as IJsonWrapper).GetString();
				_data.IMG_LIST = (JsonData)_json_data[i]["imgs"];
				_data.Detail = (_json_data[i]["detail"] as IJsonWrapper).GetString();	

				Util.CustomLog(_data,Util.RECURSIVE);
				Debug.Log(_data.Id);
				Debug.Log(_data.Title);
				Debug.Log(_data.Year);
				Debug.Log(_data.Category);
				Debug.Log(_data.TagList[0]);
				Debug.Log(_data.MOV_URL);
				Debug.Log(_data.IMG_LIST[0]);
				Debug.Log(_data.Detail);
				 _data_list.Add(_data);
			}

	}


	//オリジナルjson data
	[SerializeField]
	private JsonData _original_json_data;
	public JsonData OriginalJsonData{get { return this._original_json_data; } set { this._original_json_data = value; }}

	//データリスト
  	[SerializeField]
	private List<DataObject> _data_list;
	public List<DataObject> DataList{ get { return this._data_list; } set { this._data_list = value; } }

	//データディクショナリー
	[SerializeField]
	private Dictionary<string,DataObject> _data_dict;
	public Dictionary<string,DataObject> DataObjectDict{get { return this._data_dict;} set { this._data_dict = value;}}

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
	