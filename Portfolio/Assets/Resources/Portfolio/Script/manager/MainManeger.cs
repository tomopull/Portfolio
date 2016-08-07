using UnityEngine;
using System.Collections;


//メインの表示系
public class MainManeger:AbstractBehaviour,IInterfaceBehaviour {

	//main model
	[SerializeField]
	private MainModel _main_model;
	
	//main scene
	[SerializeField]
	private Main _main;

	[SerializeField]
	private MainDataManager _main_data_manager;

	[SerializeField]
	private CanvasMain _canvas_main;

	public void Start(){
		Initialize();
	}

	public void Initialize(){
		//外部ファイルロード
		_main_model.Initialize();
		//インターフェイス初期化
		_main.Initialize();

		//メインデータから色々な形でデータを取得する時
		_main_data_manager.Initialize();
		_main_data_manager.SetModel(_main_model);

		//キャンバスメイン初期化
		_canvas_main.SetMainDataManager(_main_data_manager);
		_canvas_main.Initialize();
		
	}
	
}
