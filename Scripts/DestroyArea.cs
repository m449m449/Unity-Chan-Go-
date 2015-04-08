using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

	void OnTriggerExit (Collider collider)
	{
		Destroy (collider.gameObject);
	}
}
