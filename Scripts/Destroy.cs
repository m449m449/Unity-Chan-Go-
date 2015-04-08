using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	private float time= 0f;
	public float rimit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > rimit){
			Destroy(gameObject);
		}
	}
}
