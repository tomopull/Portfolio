using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using LitJson;



public class DetailMain : AbstractBehaviour,IInterfaceBehaviour {

	private MainDataManager _main_data_manager;
	// Use this for initialization


	private GameObject _detail_view;
	
	private string  _detail_folder_path = "DetailMain/DetailView/";

	private MovieTexture _movie_texture;

	public void Initialize(){
		
	}
	
	public void SetMainDataManager(MainDataManager _manager){
		 _main_data_manager = _manager;
	}

	public void Execute(JsonData _data){
		StartCoroutine(Show(_data));
	}

	private IEnumerator Show(JsonData _data){

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
			int select_index_max = _data["imgs"].Count;
			int select_index = Random.Range(0,select_index_max);			
			string _base_url = "Portfolio" + "/images/l/" +  _data["imgs"][select_index];
			Texture2D _texture = Resources.Load(_base_url) as Texture2D;

			Debug.Log(_texture);
			
			Image img =  GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<Image>();
			img.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), Vector2.zero);
			Debug.Log(_texture.width);
			
			 yield return null;
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

		}

	}

	public void Remove(){
		
		if(_detail_view){
			Destroy(_detail_view);
		}

	}

}
