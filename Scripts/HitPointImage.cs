using UnityEngine;
using System.Collections;

public class HitPointImage : MonoBehaviour {

	public GameObject[] image;
	// Use this for initialization
	void Start () {
	}

	public void DestroyImage(){
		Destroy(image[transform.childCount -1]);
	}
}
