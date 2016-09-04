using UnityEngine;
using System.Collections;
using LitJson;
public class ThumbnailData : AbstractBehaviour {

	[SerializeField]
	private JsonData _thumbnail_data;

	[SerializeField]
	private int _select_index;
	//選択されたサムネイル画像のid
	public int SelectIndex{ get { return this._select_index; } set { this._select_index = value; } }
	public JsonData JsonData{ get { return this._thumbnail_data; } set { this._thumbnail_data = value; } }


}
