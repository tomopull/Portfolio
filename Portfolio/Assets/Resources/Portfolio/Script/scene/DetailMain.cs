using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using LitJson;



public class DetailMain : AbstractBehaviour,IInterfaceBehaviour {

	private MainDataManager _main_data_manager;
	// Use this for initialization


	private GameObject _detail_view;
	
	private string  _detail_folder_path = "DetailMain/DetailView/";

	//private MovieTexture _movie_texture;

	public void Initialize(){
		
	}
	
	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	public void Execute(JsonData _data, int _selected_index){
		StartCoroutine(Show(_data,_selected_index));
	}

	private IEnumerator Show(JsonData _data, int _selected_index){

		if(_detail_view == null){

			_detail_view = Util.InstantiateUtil("DetailView",new Vector3(0,0,0),Quaternion.identity,transform);
			
			_detail_view.SetActive(true);
			
			//タイトル
			GameObject.Find(_detail_folder_path + "Title").GetComponent<Text>().text = (_data["title"] as IJsonWrapper).GetString();

			//年度
			GameObject.Find(_detail_folder_path + "Year").GetComponent<Text>().text = (_data["year"] as IJsonWrapper).GetInt().ToString();

			//詳細
			GameObject.Find(_detail_folder_path + "DetailText").GetComponent<Text>().text = (_data["detail"] as IJsonWrapper).GetString();

			//メインイメージ
			MakeMainImage(_data,_selected_index);
			
			//サムネイルボタン作成
			MakeThumbnailButton(_data);
			
			 yield return null;
		}

	}

	private void MakeMainImage(JsonData _data, int _selected_index){
		//メインイメージ		
		string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][_selected_index];
		Texture2D _texture = Resources.Load(_base_url) as Texture2D;

		Image img =  GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<Image>();

		img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);
	}

	private void MakeThumbnailButton(JsonData _data){

		for (int i = 0; i <  _data["imgs"].Count; i++)
		{			
			string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][i];
			
			Texture2D _texture = Resources.Load(_base_url) as Texture2D;
			//Debug.Log(_detail_folder_path +  "Images" + "/ImageBtn" + (i+1) + "/Image" + (i+1) );
			Image img =  GameObject.Find(_detail_folder_path +  "Images" + "/ImageBtn" + (i+1) + "/Image" + (i+1) ).GetComponent<Image>();
			
			img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);
		
			//ボタンイベント
			Button btn = (Button)GameObject.Find(_detail_folder_path +  "Images" + "/ImageBtn" + (i+1) + "/btn_" + (i+1)).GetComponent<Button>();
			//ボタンにjson data 保存
			//画像サムネイルの画像のindexの保存
			btn.GetComponent<ThumbnailData>().JsonData = _data;
			Util.SetButtonEvent(btn.gameObject,UpDateMainImage,EventTriggerType.PointerClick);

			}
			
		//使わないボタンは非表示
		int j = 6;
		while(_data["imgs"].Count < j){
			GameObject.Find(_detail_folder_path +  "Images" + "/ImageBtn" + (j)).SetActive(false);
			j--;	
		}

	}

	private void UpDateMainImage(BaseEventData  _base_event_data){
		
		JsonData _data =  _base_event_data.selectedObject.GetComponent<Button>().GetComponent<ThumbnailData>().JsonData;
		string btn_clicked =  Util.GetStringOnly(_base_event_data.selectedObject.GetComponent<Button>().ToString());
		//Debug.Log(btn_clicked);
		string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][int.Parse(btn_clicked)-1];
		//Debug.Log(_base_url);
		Texture2D _texture = Resources.Load(_base_url) as Texture2D;

		Image img =  GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<Image>();
		img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);

	}

	public void Remove(){
		
		if(_detail_view){
			Destroy(_detail_view);
		}

	}

}

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