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

		if(_detail_view == null){
			_detail_view = Util.InstantiateUtil("DetailView",new Vector3(0,0,0),Quaternion.identity,transform);
			
			_detail_view.SetActive(true);
			
			//タイトル
			GameObject.Find(_detail_folder_path + "Title").GetComponent<Text>().text = (_data["title"] as IJsonWrapper).GetString();

			//年度
			GameObject.Find(_detail_folder_path + "Year").GetComponent<Text>().text = (_data["year"] as IJsonWrapper).GetInt().ToString();

			//詳細
			GameObject.Find(_detail_folder_path + "DetailText").GetComponent<Text>().text = (_data["detail"] as IJsonWrapper).GetString();


			//_movie_texture =  (MovieTexture)GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<RawImage>().texture;
			
			// string _movie_tx_str = (_data["detail"] as IJsonWrapper).GetString();
			// _movie_texture = (MovieTexture)_movie_tx_str;


			//GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<RawImage>().texture;
			//_movie_texture = (MovieTexture)GameObject.Find(_detail_folder_path + "DetailMov").GetComponent<RawImage>().mainTexture;
			//_movie_texture.Play();

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
