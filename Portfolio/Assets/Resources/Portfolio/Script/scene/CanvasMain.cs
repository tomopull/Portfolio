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
		List<JsonData> _data_list = _main_data_manager.GetAllData();

		for (int i = 1; i <= 48; i++)
		{
			//テクスチャーを描画
			//Debug.Log(GameObject.Find("ImageTriangle" + i));
		}

	}

	


	
	
}
