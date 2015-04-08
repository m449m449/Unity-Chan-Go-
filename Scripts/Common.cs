using UnityEngine;
using System.Collections;

public class Common : MonoBehaviour {

	public float speed;/*スピード*/
	public float shotInterval;/*弾発射の間隔*/
	public GameObject bullet;/*弾のオブジェクト*/
	public GameObject smoke;/*破壊された時のオブジェクト*/
	public GameObject damagesmoke;/*被弾時のオブジェクト*/

	/*弾の作成*/
	public void Shot(Transform trans){
		Instantiate(bullet,trans.position,trans.rotation);
	}

	/*移動*/
	public void Move(Vector2 direction){
		GetComponent<Rigidbody>().velocity = direction * speed;
	}
	/*撃沈された時の煙作成*/
	public void Damage(){
		Instantiate(smoke,transform.position,transform.rotation);
	}

	/*被弾時の煙作成*/
	public void DamageSmoke(){
		Instantiate(damagesmoke,transform.position,transform.rotation);
	}
}
