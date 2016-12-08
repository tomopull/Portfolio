using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour
{
		private List<string> logs = new List<string> ();
		const int MAX_LOGS = 30;


		//現在のマウスタッチを開始位置
		[SerializeField]
		private Vector2 _touch_start_pos = new Vector2(3f,3f);
		public Vector2 TouchStartPos{ get { return this._touch_start_pos; } set { this._touch_start_pos = value; } }
		

		//現在のマウスタッチを終了位置
		[SerializeField]
		private Vector2 _touch_end_pos = new Vector2();
		public Vector2 TouchEndPos{ get { return this._touch_end_pos; } set { this._touch_end_pos = value; } }

		
		//現在のスワイプ開始距離
		[SerializeField]
		private Vector2 _swipe_pos = new Vector2();
		public Vector2 SwipePos{ get { return this._swipe_pos; } set { this._swipe_pos = value; } }

		//現在のフリック情報
		[SerializeField]
		private FlickEventArgs _flick_event_args_data;
		public FlickEventArgs FlickEventArgsData{ get { return this._flick_event_args_data; } set { this._flick_event_args_data = value; } }
		

		//drag flag
		[SerializeField]
		private bool _is_drag;
		public bool IsDrag{ get { return this._is_drag; } set { this._is_drag = value; } }

		//flick flag
		[SerializeField]
		private bool _is_flicking;
		public bool IsFlicking{ get { return this._is_flicking; } set { this._is_flicking = value; } }

		//isDown flag
		[SerializeField]
		private bool _isDown;
		public bool IsDown{ get { return this._isDown; } set { this._isDown = value; } }

		//isUp flag
		[SerializeField]
		private bool _is_up;
		public bool IsUp{ get { return this._is_up; } set { this._is_up = value; } }



		void OnEnable ()
		{
				TouchManager.Instance.Drag += OnSwipe;
				TouchManager.Instance.TouchStart += OnTouchStart;
				TouchManager.Instance.TouchEnd += OnTouchEnd;
				TouchManager.Instance.FlickStart += OnFlickStart;
				TouchManager.Instance.FlickComplete += OnFlickComplete;
		}

		void OnDisable ()
		{
				if (TouchManager.Instance != null) {
						TouchManager.Instance.Drag -= OnSwipe;
						TouchManager.Instance.TouchStart -= OnTouchStart;
						TouchManager.Instance.TouchEnd -= OnTouchEnd;
						TouchManager.Instance.FlickStart -= OnFlickStart;
						TouchManager.Instance.FlickComplete -= OnFlickComplete;
				}
		}

		void OnTouchStart (object sender, CustomInputEventArgs e)
		{
				string text = string.Format ("OnTouchStart X={0} Y={1}", e.Input.ScreenPosition.x, e.Input.ScreenPosition.y);
				Debug.Log (text);

				//タッチ開始位置の更新
				_touch_start_pos.x = e.Input.ScreenPosition.x;
				_touch_start_pos.y = e.Input.ScreenPosition.y;
		}

		void OnTouchEnd (object sender, CustomInputEventArgs e)
		{
				string text = string.Format ("OnTouchEnd X={0} Y={1}", e.Input.ScreenPosition.x, e.Input.ScreenPosition.y);
				Debug.Log (text);

				//タッチ終了位置の更新
				_touch_end_pos.x = e.Input.ScreenPosition.x;
				_touch_end_pos.y = e.Input.ScreenPosition.y;
		}

		void OnSwipe (object sender, CustomInputEventArgs e)
		{
				string text = string.Format ("OnSwipe Pos[{0},{1}] Move[{2},{3}]", new object[] {
						e.Input.ScreenPosition.x.ToString ("0"),
						e.Input.ScreenPosition.y.ToString ("0"),
						e.Input.DeltaPosition.x.ToString ("0"),
						e.Input.DeltaPosition.y.ToString ("0")
				});

				
				//スワイプ開始位置の更新
				_swipe_pos.x = e.Input.ScreenPosition.x;
				_swipe_pos.y = e.Input.ScreenPosition.y;
		}

		void OnFlickStart (object sender, FlickEventArgs e)
		{
				string text = string.Format ("OnFlickStart [{0}] Speed[{1}] Accel[{2}] ElapseTime[{3}]", new object[] {
						e.Direction.ToString (),
						e.Speed.ToString ("0.000"),
						e.Acceleration.ToString ("0.000"),
						e.ElapsedTime.ToString ("0.000"),
				});
				Debug.Log (text);

				//フリックデータ更新
				_flick_event_args_data = e;

		}

		void OnFlickComplete (object sender, FlickEventArgs e)
		{
				string text = string.Format ("OnFlickComplete [{0}] Speed[{1}] Accel[{2}] ElapseTime[{3}]", new object[] {
						e.Direction.ToString (),
						e.Speed.ToString ("0.000"),
						e.Acceleration.ToString ("0.000"),
						e.ElapsedTime.ToString ("0.000")
				});
				Debug.Log (text);	

				//フリックデータ更新
				_flick_event_args_data = e;
				
		}

		
	private static TouchHandler instance = null;
	
	public static TouchHandler Instance {

		get {	
				return TouchHandler.instance;	
			}
		}

		void Awake()
		{
			if( instance == null)

			{

				instance = this;

			}else{

				Destroy( this );

			}
			//DontDestroyOnLoad(this); // シーン読み込みの際に破棄されなくなる	
		}
}
