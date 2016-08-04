using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class MainModel : AbstractBehaviour,IInterfaceBehaviour {


	public void Initialize(){
		
	}

	public void InitializeData(JsonData _json_data){
			OriginalJsonData = _json_data;
			
			_data_list = new List<DataObject>();
			_data_dict = new Dictionary<string,DataObject>();
			
			for (int i = 0; i < _json_data.Count; i++)
			{
				//new 使っちゃダメ
				//DataObject _data = new DataObject();
				//_data.Id = (uint)_json_data[i]["id"];
				// _data.Title= (string)_json_data[i]["title"];
				// _data.Year = (uint)_json_data[i]["year"];
				// _data.Category = (uint)_json_data[i]["category"];
				// _data.TagList = _json_data[i]["tag"];
				// _data.MOV_URL = (string)_json_data[i]["mov"];
				// _data.IMG_LIST = _json_data[i]["imgs"];
				// _data.Detail = (string)_json_data[i]["detail"];	

				// Debug.Log(_data.Id);
				// Debug.Log(_data.Title);
				// Debug.Log(_data.Detail);
				
				// _data_list.Add(_data);
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
	