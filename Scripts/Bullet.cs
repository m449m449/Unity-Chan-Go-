using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = this.gameObject.transform.up.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
