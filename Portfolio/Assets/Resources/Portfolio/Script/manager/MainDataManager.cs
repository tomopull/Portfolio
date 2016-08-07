using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class MainDataManager : AbstractBehaviour,IInterfaceBehaviour {


	private MainModel _main_model;

	public void Initialize(){
		
	}

	public void SetModel(MainModel model){
		_main_model = model;
	}

	//全てのデータを取得-----------------------------------------------------------------------------------------
	public List<JsonData> GetAllData(){
		
		List<JsonData> _data_list = new List<JsonData>();
		
		for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
		{
			JsonData _data = _main_model.OriginalJsonData[i];
			_data_list.Add(_data);
		}

		return _data_list;
	}

	

	
	//作品のidで取得-----------------------------------------------------------------------------------------
	public JsonData GetDataById(int _id){

		for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
		{
			JsonData _data = _main_model.OriginalJsonData[i];
			
			if( (_data[i]["id"] as IJsonWrapper).GetInt() == _id){

				return _data;

			}

		}

		return null;
	}

	//タイトル名で取得-----------------------------------------------------------------------------------------
	public JsonData GetDataByTitle(string _title){

		for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
		{
			JsonData _data = _main_model.OriginalJsonData[i];
			
			if( (_data[i]["title"] as IJsonWrapper).GetString() == _title){

				return _data;

			}

		}

		return null;

	}

	//カテゴリーidでリストを取得-----------------------------------------------------------------------------------------
	public List<JsonData> GetDataByCategoryId(int _category){
		
		List<JsonData> _data_list = new List<JsonData>();
		
		for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
		{
			JsonData _data = _main_model.OriginalJsonData[i];
			
			if( (_data[i]["category"] as IJsonWrapper).GetInt() == _category){

				_data_list.Add(_data);

			}

		}

		return _data_list;
	}

	//年代でリストを取得-----------------------------------------------------------------------------------------
	public List<JsonData> GetDataByYear(int _year){
		
		List<JsonData> _data_list = new List<JsonData>();
		
		for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
		{
			JsonData _data = _main_model.OriginalJsonData[i];
			
			if( (_data[i]["year"] as IJsonWrapper).GetInt() == _year){

				_data_list.Add(_data);

			}

		}

		return _data_list;
	}

	// //年代でリストを取得-----------------------------------------------------------------------------------------
	// public List<JsonData> GetDataByTag(){
		
	// 	List<JsonData> _data_list = new List<JsonData>();
		
	// 	for (int i = 0; i < _main_model.OriginalJsonData.Count; i++)
	// 	{
	// 		JsonData _data = _main_model.OriginalJsonData[i]["tag"];
			
			

	// 	}

	// 	return _data_list;
	// }


}
