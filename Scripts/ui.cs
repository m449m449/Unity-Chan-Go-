using UnityEngine;
using System.Collections;

public class ui : MonoBehaviour {

	RectTransform rectTransform;
	public int origin;	/*原点*/
	public int x;		/*withのx倍*/
	public int y;		/*heightのy倍*/
	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform>();

		/*調整中*/
		rectTransform.sizeDelta = new Vector2(Screen.width/10,Screen.height/10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
