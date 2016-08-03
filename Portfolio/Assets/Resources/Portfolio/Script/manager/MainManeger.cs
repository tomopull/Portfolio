using UnityEngine;
using System.Collections;

public class MainManeger:AbstractBehaviour,IInterfaceBehaviour {

	//main model
	[SerializeField]
	private MainModel _main_model;
	
	//main scene
	[SerializeField]
	private Main _main;

	public void Start(){
		Initialize();
	}

	public void Initialize(){
		_main_model.Initialize();
		_main.Initialize();
	}
	
}
