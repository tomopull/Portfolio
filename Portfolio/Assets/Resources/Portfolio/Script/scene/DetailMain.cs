﻿using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

using LitJson;
using DG.Tweening;

public class DetailMain : AbstractBehaviour,IInterfaceBehaviour{

	[SerializeField]
	private bool _is_swiping = false;
	public bool IsSwiping{ get { return this._is_swiping; } set { this._is_swiping = value; } }

	//jsonデータ
	[SerializeField]
	private JsonData _json_data;
	public JsonData JsonData{ get { return this._json_data; } set { this._json_data = value; } }

	//ループしだす間の制止している間の間隔
	private float _idle_time = 4f;
	private float _now_idle_time = 4f;

	private bool _update_flag = false;

	//アイドル状態かどうか。
	//アイドル状態の時はゆっくり時間をとってフェードインアウト
	//アイドル状態でない時はクリックされた時なので、すぐにフェードインアウト
	private bool _is_idle_time = true;

	//現在選択されているイメージのインデックス
	private int _now_selected_img_index = 0;
	
	//現在選択されている投稿のイメージ総数
	private int _now_img_total_count = 0;

	private MainDataManager _main_data_manager;
	// Use this for initialization

	[SerializeField]
	private GameObject _detail_view;
	public GameObject DetailView{ get { return this._detail_view; } set { this._detail_view = value; } }

	[SerializeField]
	private Vector3 _detail_view_pos;
	public Vector3 DetailViewPos{ get { return this._detail_view_pos; } set { this._detail_view_pos = value; } }

	private float _fade_in_time = 0.9f;

	private float _fade_in_time_delay_total = 0;

	private float _fade_in_time_delay_add = 0.3f;
	
	private string  _detail_folder_path = "DetailMain/DetailView/";

	IEnumerator ShowWork;
	IEnumerator UpdateMainImageWork;

	//private MovieTexture _movie_texture;

	public void Initialize(){

	}
	
	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	public void Execute(JsonData _data, int _selected_index){

		ShowWork =  Show(MainModel.TwoDMode,_data,_selected_index);
		StartCoroutine(ShowWork);
	}


	private Vector3 _touch_start_pos = new Vector3();
	private Vector3 _temp_touch_pos = new Vector3();
	private Vector3 _touch_end_pos = new Vector3();
	private int _slide_direction;

	void Update(){
		//InputHandler();
	} 



	//次の投稿の表示
	public void ShowNext(int _next_id){

		Debug.Log("ShowNext");
		Remove();
		
		JsonData _next_json_data = _main_data_manager.GetDataById(_next_id);

		ShowWork =  Show(MainModel.TwoDMode, _next_json_data,0);
		StartCoroutine(ShowWork);
		
	}

	private IEnumerator Show(string _mode, JsonData _data, int _selected_index){
		//Debug.Log(_data["id"]);

		if(_detail_view == null){
			_detail_view = Util.InstantiateUtil("DetailView",_mode,new Vector3(0,0,0),Quaternion.identity,transform);
			_detail_view_pos = new Vector3();
			_detail_view_pos.x = _detail_view.transform.position.x;
			_detail_view_pos.y = _detail_view.transform.position.y;
			_detail_view_pos.z = _detail_view.transform.position.z;

			_detail_view.SetActive(true);
			
			//タイトル-----------------------------------------------------------------------------------------------------------------
			string _title_text_str = (_data["title"] as IJsonWrapper).GetString();
			Text _title_text = _detail_view.gameObject.transform.FindChild("Title").GetComponent<Text>();
			_title_text.text = _title_text_str;
			Debug.Log(_title_text.text);
			_title_text.color = new Color(255,255,255,0);

			DOTween.ToAlpha(
				() => _title_text.color, 
				color => _title_text.color = color,
				1f,                             // 最終的なalpha値
				_fade_in_time
			);

			//年度------------------------------------------------------------------------------------------------------------------------
			string _year_text_str = (_data["year"] as IJsonWrapper).GetInt().ToString();
			Text _year_text = _detail_view.gameObject.transform.FindChild("Year").GetComponent<Text>();
			_year_text.text = _year_text_str;

			_year_text.color = new Color(255,255,255,0);

			DOTween.ToAlpha(
				() => _year_text.color, 
				color => _year_text.color = color,
				1f,                             // 最終的なalpha値
				_fade_in_time
			);

			//詳細-----------------------------------------------------------------------------------------------------------------------
			string _detail_text_str = (_data["detail"] as IJsonWrapper).GetString();
			Text _detail_text = _detail_view.gameObject.transform.FindChild("DetailText").GetComponent<Text>();
			_detail_text.text = _detail_text_str;

			_detail_text.color = new Color(255,255,255,0);

			DOTween.ToAlpha(
				() => _detail_text.color, 
				color => _detail_text.color = color,
				1f,                             // 最終的なalpha値
				_fade_in_time
			);

			//メインイメージ----------------------------------------------------------------------------------------------------------------
			_update_flag = true;
			_now_selected_img_index = _selected_index;
			_json_data = _data;
			_now_img_total_count = ((JsonData)_data["imgs"].Count as IJsonWrapper).GetInt();
			//サムネイルボタン作成------------------------------------------------------------------------------------------------------------
			MakeThumbnailButton(_data);

			yield return null;
		}
		//サムネイルイメージの自動更新開始
		UpdateMainImageWork =  UpdateMainImage(_data);
		StartCoroutine(UpdateMainImageWork);
	}

	private void MakeThumbnailButton(JsonData _data){

		for (int i = 0; i <  _data["imgs"].Count; i++)
		{			
			string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][i];
			
			Texture2D _texture = Loader.Load(_base_url) as Texture2D;
			Image img =  _detail_view.gameObject.transform.FindChild("Images" + "/ImageBtn" + (i+1) + "/Image" + (i+1) ).GetComponent<Image>();
			img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);

			img.color = new Color(255,255,255,0);

			float tint_color;

			if(_now_selected_img_index == i){
				tint_color = 1;
			}else{
				tint_color = 0.3f;
			}

			DOTween.ToAlpha(
				() => img.color, 
				color => img.color = color,
				tint_color, // 最終的なalpha値
				0.1f
			);
		
			//ボタンイベント
			Button btn = (Button)_detail_view.gameObject.transform.FindChild("Images" + "/ImageBtn" + (i+1) + "/btn_" + (i+1)).GetComponent<Button>();
			
			//ボタンにjson data 保存
			//画像サムネイルの画像のindexの保存
			btn.GetComponent<ThumbnailData>().JsonData = _data;

			Util.SetButtonEvent(btn.gameObject,UpDateImageStart,EventTriggerType.PointerClick);

			}
			
		//使わないボタンは非表示
		int j = 6;
		Debug.Log(_data["imgs"].Count);
		while(_data["imgs"].Count < j){
			Transform _thumb_btn =  _detail_view.gameObject.transform.FindChild("Images" + "/ImageBtn" + (j));
			_thumb_btn.gameObject.SetActive(false);
			j--;
		}

	}

	private IEnumerator UpdateMainImage( JsonData _selected_data) {

			while(_update_flag){

				//サムネイルの フォーカスの移動
				SetThumbnailForcus(_selected_data);

				string _base_url = "Portfolio" + "/images/l/" +  _selected_data["imgs"][_now_selected_img_index];

				Texture2D _texture = Loader.Load(_base_url) as Texture2D;

				Image img =  _detail_view.gameObject.transform.FindChild("DetailImg").GetComponent<Image>();
		
				RawImage raw_img =  _detail_view.gameObject.transform.FindChild("DetailMov").GetComponent<RawImage>();

				img.gameObject.SetActive(true);

				raw_img.gameObject.SetActive(false);

				img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);

				img.color = new Color(255,255,255,0);

				DOTween.ToAlpha(
					() => img.color, 
					color => img.color = color,
					1f, // 最終的なalpha値
					_fade_in_time
				);

				//次の投稿に更新
				_now_selected_img_index +=1;

				//一周回ったら最初から
				if(_now_selected_img_index >= _now_img_total_count){
					_now_selected_img_index = 0;
				}

				yield return new WaitForSeconds(_now_idle_time);

			}
    }
	
	private void UpDateImageStart(BaseEventData  _base_event_data = null){
		
		JsonData _data =  _base_event_data.selectedObject.GetComponent<Button>().GetComponent<ThumbnailData>().JsonData;	
		string btn_clicked =  Util.GetStringOnly(_base_event_data.selectedObject.GetComponent<Button>().ToString());

		//現在選択中の画像のインデックスを更新
		_now_selected_img_index = int.Parse(Util.GetStringOnly(btn_clicked))-1;
		UpdateMainImage(_data);
	}

	private void SetThumbnailForcus(JsonData _data){
		
		for (int i = 0; i <  _data["imgs"].Count; i++)
		{			
			string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][i];
			
			Texture2D _texture = Loader.Load(_base_url) as Texture2D;

			Image img =  _detail_view.gameObject.transform.FindChild("Images" + "/ImageBtn" + (i+1) + "/Image" + (i+1) ).GetComponent<Image>();

			img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);

			Color tint_color;

			if(_now_selected_img_index == i){
				tint_color = new Color(255,255,255,1);
			}else{
				tint_color = new Color(255,255,255,0.3f);
			}

			DOTween.To(
				() => img.color,              // 何を対象にするのか
				color => img.color = color,   // 値の更新
				tint_color,                   // 最終的な値
				0                             // アニメーション時間
			);

		}

	}


	public void Remove(){
		
		if(_detail_view){
			Destroy(_detail_view);
			_detail_view = null;
			//コルーチン終了
			StopCoroutine(ShowWork);
			StopCoroutine(UpdateMainImageWork);
			_update_flag = false;
		}
		
	}

}

// DOTween.To(
	// () => image.color,              // 何を対象にするのか
	// color => image.color = color,   // 値の更新
	// Color.yellow,                   // 最終的な値
	// 3f                              // アニメーション時間
	// );

// private IEnumerator StartMovie(JsonData _data, int _selected_index){

	// 	string  movieTexturePath    = Application.streamingAssetsPath + "/" + "donburi_catcher.ogv";
	// 	string  url                 = "file://" + movieTexturePath;
	// 	WWW     movie               = new WWW(url);

	// 	while (!movie.isDone) {
	// 		yield return null;
	// 	}

	// 	MovieTexture movieTexture = movie.movie as MovieTexture;

	// 	while (!movieTexture.isReadyToPlay) {
	// 		yield return null;
	// 	}

	// 		//var renderer = GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<MeshRenderer>();
	// 		//renderer.material.mainTexture = movieTexture;
	// 		RawImage img = GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<RawImage>();
	// 		img.material.mainTexture = movieTexture;
			
	// 		img.gameObject.SetActive(false);
	// 		img.gameObject.SetActive(true);
	// 		movieTexture.loop = true;
	// 		movieTexture.Play ();

	// 	#if false

	// 		//オーディオを使用する場合はこの部分を有効にしてください
	// 		var audioSource = GetComponent<AudioSource>();
	// 		audioSource.clip = movieTexture.audioClip;
	// 		audioSource.loop = true;
	// 		audioSource.Play ();
			
	// 	#endif

	// }


// private void UpdateMainImage(JsonData _data, int _selected_index){
// 	//メインイメージ		
// 	string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][_selected_index];
// 	Texture2D _texture = Loader.Load(_base_url) as Texture2D;

// 	Image img =  GameObject.Find(_detail_folder_path + "DetailImg").GetComponent<Image>();

// 	img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);

// 	img.color = new Color(255,255,255,0);

// 	DOTween.ToAlpha(
// 		() => img.color, 
// 		color => img.color = color,
// 		1f, // 最終的なalpha値
// 		_fade_in_time
// 	);

// }

//メインイメージ総数の決定// Debug.Log( (_data["category"] as IJsonWrapper).GetInt());
// Debug.Log( (JsonData)_data["tag"]);
// Debug.Log( (_data["mov"] as IJsonWrapper).GetString());
// Debug.Log( (JsonData)_data["imgs"]);

//string _movie_tx_str = (_data["mov"] as IJsonWrapper).GetString();

			
			//string  movieTexturePath    = Application.streamingAssetsPath + "/" + "Portfolio/ogv/" + _movie_tx_str;
			//string  movieTexturePath    = Application.streamingAssetsPath + "/" + "Portfolio/ogv/" + "donburi_catcher";
			//string  movieTexturePath    = "http://www.unity3d.com/webplayers/Movie/sample.ogg";
			
            //string  url                 = "file://" + movieTexturePath;
            // WWW     movie               = new WWW(url);

			// while (!movie.isDone) {
            //     yield return null;
            // }
			//Debug.Log("ムービー準備完了");

        	//MovieTexture movieTexture = movie.movie;
			//Debug.Log(movieTexture);
			//Debug.Log(movie.movie);
			//Debug.Log(movieTexturePath);
			

            // while (!movieTexture.isReadyToPlay) {
            //     yield return null;
            // }

        	// var renderer = GetComponent<MeshRenderer>();
        	// // MeshRenderer renderer = GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<RawImage>().GetComponent<MeshRenderer>();
			// // Debug.Log(renderer + "renderer?");
			// renderer.material.mainTexture = movieTexture;

            // movieTexture.loop = true;
            // movieTexture.Play ();

			// #if false
			// 		//オーディオを使用する場合はこの部分を有効にしてください
			// 		var audioSource = GetComponent<AudioSource>();
			// 		audioSource.clip = movieTexture.audioClip;
			// 		audioSource.loop = true;
			// 		audioSource.Play ();
			// #endif

			// Debug.Log( (_data["title"] as IJsonWrapper).GetString());
			// Debug.Log( (_data["year"] as IJsonWrapper).GetInt());
			// Debug.Log( (_data["category"] as IJsonWrapper).GetInt());
			// Debug.Log( (JsonData)_data["tag"]);
			// Debug.Log( (_data["mov"] as IJsonWrapper).GetString());
			// Debug.Log( (JsonData)_data["imgs"]);
			//Debug.Log( (_data["detail"] as IJsonWrapper).GetString());