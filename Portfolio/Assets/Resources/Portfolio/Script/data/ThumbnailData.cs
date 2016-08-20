using UnityEngine;
using System.Collections;
using LitJson;
public class ThumbnailData : AbstractBehaviour {

	[SerializeField]
	private JsonData _thumbnail_data;
	public JsonData JsonData{ get { return this._thumbnail_data; } set { this._thumbnail_data = value; } }


}
