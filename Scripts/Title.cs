using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*タッチされたら*/
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch (0);	/*タッチ情報を取得*/
			/*タッチ直後にシーン遷移*/
			if (touch.phase == TouchPhase.Began) {
				GetComponent<AudioSource>().Play(); /*タッチ音*/
				Application.LoadLevel("Scene1");	/*scene1へ遷移*/
			}
		}
	}
}
