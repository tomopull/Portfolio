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

	[SerializeField]
	private DetailMain _datail_main;
	
	public void Start(){
		Initialize();
	}

	public void Initialize(){
		//外部ファイルロード
		_main_model.Initialize();
	}

	public void Update(){

		//サーバー通信完了（json読込み完了//データ読込み完了
		if(_main_model.State == MainModel.LOAD_COMPLETE_STATE){

			//インターフェイス初期化
			_main.Initialize();

			//メインデータから色々な形でデータを取得する時
			_main_data_manager.Initialize();
			_main_data_manager.SetModel(_main_model);
			_main_model.State = MainModel.INITIALIZE_END_STAE;

			//メインキャンバス
			_canvas_main.Initialize();
			_canvas_main.SetMainModel(_main_model);
			_canvas_main.SetMainDataManager(_main_data_manager);

			//デティール表示
			_canvas_main.SetDetailMain(_datail_main); 
			_canvas_main.Initialize();
			_datail_main.SetMainDataManager(_main_data_manager);
			_datail_main.Initialize();
			
		}

		
			
			
			
			
			

			
	}
	
}
