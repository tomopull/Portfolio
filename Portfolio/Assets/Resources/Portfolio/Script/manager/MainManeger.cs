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
	}

	public void Update(){

		//モデルが初期化されたら一回だけ実行。
		if(_main_model.Initialized){
			
			//インターフェイス初期化
			_main.Initialize();

			//メインデータから色々な形でデータを取得する時
			_main_data_manager.Initialize();
			_main_data_manager.SetModel(_main_model);
		
			//メインキャンバス
			_canvas_main.SetMainDataManager(_main_data_manager);
			_canvas_main.Initialize();

			_main_model.Initialized = !_main_model.Initialized;
			
		}

	}
	
}
