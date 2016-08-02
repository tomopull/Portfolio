using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataObject : AbstractBehaviour{
	//id
	[SerializeField]
	private uint _id;
	public uint Id{ get { return this._id; } set { this._id = value; } }

	//title
	[SerializeField]
	private string _title;
	public string Title{ get { return this._title; } set { this._title = value; } }
	
	//year
	[SerializeField]
	private uint _year;
	public uint Year{ get { return this._year; } set { this._year = value; } }

	//category
	[SerializeField]
	private uint _ctegory;
	public uint Category{ get { return this._ctegory; } set { this._ctegory = value; } }

	//配列のindex
	[SerializeField]
	private uint _index;
	public uint Index{ get { return this._index; } set { this._index = value; } }

	//自身のGameObject
	[SerializeField]
	private GameObject _data_obj;
	public GameObject DataObj{ get { return this._data_obj; } set { this._data_obj = value; } }

	//tag list
	[SerializeField]
	private List<string> _tag_list;
	public List<string> TagList{ get { return this._tag_list; } set { this._tag_list = value; } }

	//mov url
	[SerializeField]
	private string _mov_url;
	public string MOV_URL{ get { return this._mov_url; } set { this._mov_url = value; } }
	
	//img_list
	[SerializeField]
	private List<string> _img_list;
	public List<string> IMG_LIST{ get { return this._img_list; } set { this._img_list = value; } }

	//detail
	[SerializeField]
	private string _detail;
	public string Detail{ get { return this._detail; } set { this._detail = value; } }

}
