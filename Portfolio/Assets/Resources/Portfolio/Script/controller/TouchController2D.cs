using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TouchScript.Gestures;

using LitJson;

public class TouchController2D : MonoBehaviour {

	private Camera _camera;
	
	 private PressGesture _pressGesture;

    private ReleaseGesture _releaseGesture;

	[SerializeField]
	private MainModel _model;
	public MainModel Model{ get { return this._model; } set { this._model = value; } }

	[SerializeField]
	private MainDataManager _main_data_manager;
	public MainDataManager MainDataManager{ get { return this._main_data_manager; } set { this._main_data_manager = value; } }


	private Vector3 _touch_start_pos = new Vector3();
	private Vector3 _temp_touch_pos = new Vector3();
	private Vector3 _touch_end_pos = new Vector3();

	private int _slide_direction;

	[SerializeField]
	private DetailMain _detail_main;
	public DetailMain DetailMain{ get { return this._detail_main; } set { this._detail_main = value; } }

	private void OnEnable()
	{
		_camera = GameObject.Find("Camera").GetComponent<Camera>();
		_pressGesture = GetComponent<PressGesture>();
        _releaseGesture = GetComponent<ReleaseGesture>();

		_pressGesture.Pressed += SwipeHandler;
		_releaseGesture.Released += SwipeEndHandler;
	}

	private void OnDisable()
	{
		_pressGesture.Pressed -= SwipeHandler;
		_releaseGesture.Released -= SwipeEndHandler;
	}


	public void Update(){

	if(_model != null){

		if(_model.MainModelState == MainModel.DETAIL_VIEW_STATE && _detail_main.IsSwiping == true){

			_temp_touch_pos = Input.mousePosition;

				if(_detail_main.DetailView != null){

					//一定の距離以上ドラッグしていたら移動_
					float tmp_dist = Vector2.Distance(_temp_touch_pos,_touch_start_pos);

					if(_touch_start_pos.x > _temp_touch_pos.x){
						_detail_main.DetailView.transform.position = new Vector3(_detail_main.DetailViewPos.x-tmp_dist,_detail_main.DetailView.transform.position.y,_detail_main.DetailView.transform.position.z);
					}else if(_touch_start_pos.x < _temp_touch_pos.x){
						_detail_main.DetailView.transform.position = new Vector3(_detail_main.DetailViewPos.x+tmp_dist,_detail_main.DetailView.transform.position.y,_detail_main.DetailView.transform.position.z);
					}

				}

			}

		}

	}
		

	//スワイプ開始
	 private void SwipeHandler(object sender, System.EventArgs e){

		 if(_model != null){

			 if(_model.MainModelState == MainModel.DETAIL_VIEW_STATE){
				 Debug.Log("swipe start");
				 _touch_start_pos = Input.mousePosition;
				_detail_main.IsSwiping = true;

			 }

		 }
		 	 
	 }

	 //スワイプ終了
	 private void SwipeEndHandler(object sender, System.EventArgs e){

		   if(_model != null){

			 if(_model.MainModelState == MainModel.DETAIL_VIEW_STATE){
				 Debug.Log("swipe end");
				 _detail_main.IsSwiping = false;

				_touch_end_pos = Input.mousePosition;

				//ある程度ドラッグしていたら次の投稿の表示
				
				//右方向にドラッグしていたら未来の投稿
				if(_touch_end_pos.x > ( (Screen.width/2) + (Screen.width/3) ) ){

					//Debug.Log("過去の投稿");
					//idを一つ遅らせる
					int now_id = (_detail_main.JsonData["id"] as IJsonWrapper).GetInt();
					int prev_id = now_id-=1;

					//Debug.Log(next_id);
					//idが一周したら最初に戻る
					if(1 > prev_id){
						prev_id = _main_data_manager.GetModel().OriginalJsonData.Count;
					}

					_detail_main.ShowNext(prev_id);

				//左方向にドラッグしてたら過去の投稿
				}else if(_touch_end_pos.x <  ( (Screen.width/2) - (Screen.width/3) ) ){

					//Debug.Log("未来の投稿");
					//idを一つ進める
					int now_id = (_detail_main.JsonData["id"] as IJsonWrapper).GetInt();
					int next_id = now_id+=1;

					//Debug.Log(next_id);

					//idが一周したら最初に戻る
					if(_main_data_manager.GetModel().OriginalJsonData.Count < next_id){
						next_id = 1;
					}

					_detail_main.ShowNext(next_id);
				
				}else{
					//Debug.Log("元に戻る");
					//元に戻る
					_detail_main.DetailView.transform.position = new Vector3(_detail_main.DetailViewPos.x,_detail_main.DetailViewPos.y,_detail_main.DetailViewPos.z);

				}

			}

		}

	}


}
	
