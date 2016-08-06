using UnityEngine;
using System.Collections;
using LitJson;

public class MainDataManager : AbstractBehaviour,IInterfaceBehaviour {


	private MainModel _main_model;

	public void Initialize(){
		
	}

	public void SetModel(MainModel model){
		_main_model = model;
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


}
