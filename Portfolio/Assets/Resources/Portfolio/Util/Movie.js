var url = "http://www.unity3d.com/Movie/sample.ogg";

function Start () {
	// Start download
	var www = new WWW(url);

	// Make sure the movie is ready to start before we start playing
	var movieTexture = www.movie;
	while (!movieTexture.isReadyToPlay)
		yield;

	var gt = GetComponent.<GUITexture>();

	// Initialize gui texture to be 1:1 resolution centered on screen
	gt.texture = movieTexture;

	transform.localScale = Vector3 (0,0,0);
	transform.position = Vector3 (0.5,0.5,0);
	gt.pixelInset.xMin = -movieTexture.width / 2;
	gt.pixelInset.xMax = movieTexture.width / 2;
	gt.pixelInset.yMin = -movieTexture.height / 2;
	gt.pixelInset.yMax = movieTexture.height / 2;

	// Assign clip to audio source
	// Sync playback with audio
	var aud = GetComponent.<AudioSource>();
	aud.clip = movieTexture.audioClip;

	// Play both movie & sound
	movieTexture.Play();
	aud.Play();
}
// Make sure we have gui texture and audio source
@script RequireComponent (GUITexture)
@script RequireComponent (AudioSource)