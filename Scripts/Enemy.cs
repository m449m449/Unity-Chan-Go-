using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	Common common;			/*Commonコンポーネント*/
	public int HP;
	public int shotLevel;	/*弾を同時発射する数 0:0発,1:1発,2:3発*/
	private int shot;		/*弾を同時発射する数 0:0発,1:1発,2:3発*/
	// Use this for initialization
	IEnumerator Start () {
		common = GetComponent<Common>();	/*Commonコンポーネント取得*/
		common.Move (transform.up * -1);	/*ローカル座標でY軸の下側に向かう*/
		/*canShotがfalseの場合ここでブレイク*/
		switch(shotLevel) {
			case 0:
				yield break;
			case 1:
				shot = 1;
				break;
			case 2:
				shot = transform.childCount - 1;/*発射用オブジェクトの子-モデル*/
				break;
		}
		/*子のtransformから発射*/
		while(true){
			for(int i = 0; i < shot; i++){
				Transform shotPos = transform.GetChild(i);	/*子のtransform代入*/
				common.Shot (shotPos);						/*子の位置、角度から発射*/
			}
			yield return new WaitForSeconds (common.shotInterval); /*発射間隔*/
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.tag != "WeakEnemy" && transform.position.y < 2){
			GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
		}
	
	}

	void OnTriggerEnter (Collider collider){
		string layerName = LayerMask.LayerToName(collider.gameObject.layer); /*レイヤー名を取得*/

		if(layerName == "Bullet"){
			if(transform.tag == "WeakEnemy"){
				/*雑魚敵なら被弾時のアニメーション*/
				this.gameObject.transform.GetComponentInChildren<ModelAnimation>().DamageAnimation();
			}else{
				/*耐久の高い敵はパーティクルで被弾演出*/
				common.DamageSmoke();/*煙発生*/
			}
			Destroy (collider.gameObject);	/*弾の削除*/
			HP -= 1;
			/*HPが0なら破壊される*/
			if(HP <= 0){
				common.Damage();/*煙発生*/
				Destroy (gameObject);/*敵の削除*/
			}
		}
	}
}
