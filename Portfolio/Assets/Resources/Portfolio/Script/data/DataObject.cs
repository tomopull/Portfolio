using UnityEngine;
using System.Collections;

public class DataObject : MonoBehaviour{
	
	//name
	[SerializeField]
	private string _name;
	public string Name
	{
		get { return this._name; } 
		set { this._name = value; }
	}
	
	//自身のGameObject
	[SerializeField]
	private GameObject _obj;
	public GameObject Obj
	{
	    get { return this._obj; } 
	    set { this._obj = value; }
	}
	
	//配列のindex
	[SerializeField]
	private uint _index;
	public uint Index
	{
	    get { return this._index; } 
	    set { this._index = value; }
	}

	//データが格納される連想配列のkey
	[SerializeField]
	private string _key;
	public string Key
	{
	    get { return this._key; } 
	    set { this._key = value; }
	}
}
