using UnityEngine;
using System.Collections;

public class video : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		if (movie != null) {
						movie.loop = true;
						movie.Play ();
						audio = GetComponent<AudioSource> ();
						audio.Play ();
				}
	}
}
