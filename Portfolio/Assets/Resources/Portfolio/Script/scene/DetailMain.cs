using UnityEngine;
using System.Collections;

public class DetailMain : AbstractBehaviour,IInterfaceBehaviour {

	private MainDataManager _main_data_manager;
	// Use this for initialization

	public void Initialize(){
		
	}
	
	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

}
