using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

//データの単位
public class DataObject : AbstractBehaviour{
	// //id
	[SerializeField]
	private int _id;
	public int Id{ get { return this._id; } set { this._id = value; } }

	//title
	[SerializeField]
	private string _title;
	public string Title{ get { return this._title; } set { this._title = value; } }
	
	//year
	[SerializeField]
	private int _year;
	public int Year{ get { return this._year; } set { this._year = value; } }

	//category
	[SerializeField]
	private int _category;
	public int Category{ get { return this._category; } set { this._category = value; } }

	//配列のindex
	[SerializeField]
	private int _index;
	public int Index{ get { return this._index; } set { this._index = value; } }

	//自身のGameObject
	[SerializeField]
	private GameObject _game_obj;
	public GameObject GameObj{ get { return this._game_obj; } set { this._game_obj = value; } }

	//tag list
	[SerializeField]
	private JsonData _tag_list;
	public JsonData TagList{ get { return this._tag_list; } set { this._tag_list = value; } }

	//mov url
	[SerializeField]
	private string _mov_url;
	public string MOV_URL{ get { return this._mov_url; } set { this._mov_url = value; } }
	
	//img_list
	[SerializeField]
	private JsonData _img_list;
	public JsonData IMG_LIST{ get { return this._img_list; } set { this._img_list = value; } }

	//detail
	[SerializeField]
	private string _detail;
	public string Detail{ get { return this._detail; } set { this._detail = value; } }

}
