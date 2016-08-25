﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class DetailMain : AbstractBehaviour,IInterfaceBehaviour {

	private MainDataManager _main_data_manager;
	// Use this for initialization

	public void Initialize(){
		
	}
	
	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	public void Execute(JsonData _data){

		GameObject _detail_view = Util.InstantiateUtil("DetailView",new Vector3(0,0,0),Quaternion.identity,transform);
		_detail_view.SetActive(true);
		
	}

}
