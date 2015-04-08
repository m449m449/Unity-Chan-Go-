using UnityEngine;
using System.Collections;

public class GunShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Sound(){
		/*親のPlayerのAudioSourceはリアクション用に使いたいので分ける*/
		GetComponent<AudioSource>().Play();/*ショット音再生*/
	}
}
