using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class MainModel : AbstractBehaviour,IInterfaceBehaviour {


	public void Initialize(){
		
	}

	//オリジナルjson data
	[SerializeField]
	private JsonData original_json_data;
	public JsonData OriginalJsonData{get { return this.original_json_data; } set { this.original_json_data = value; }}

	//ゲームオブジェクトデータ
	[SerializeField]
	private Dictionary<string,DataObject> object_data_dict;
	public Dictionary<string,DataObject> ObjectDataDict{get { return this.object_data_dict;} set { this.object_data_dict = value;}}

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
	