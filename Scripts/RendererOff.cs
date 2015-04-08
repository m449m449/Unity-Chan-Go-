using UnityEngine;
using System.Collections;

public class RendererOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
