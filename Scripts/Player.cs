using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Common common;	/*Commonコンポーネント*/
	private Manager manager; /*Managerコンポーネント*/
	private HitPointImage hpImage;	/*HitPointImageコンポーネント*/
	public int HP;		/*HP*/
	public float unrivaledTime = 4;	/*無敵時間*/
	public int min,max;		/*発射する弾の位置、数*/
	public bool diffusion, laser;	/*弾の種類*/
	public int shotLevel;	/*弾のレベル*/
	private AudioSource audioSource;	/*AudioSourceコンポーネント*/
	public AudioClip[] damage = new AudioClip[5]; /*ダメージSE格納*/
	public AudioClip end;	/*HP0時のSE*/
	public Camera orthoCamera;	/*OrthocgaphicCamera*/

	IEnumerator Start () {
		audioSource = GetComponent<AudioSource>();	/*AudioSourceコンポーネント取得*/
		common = GetComponent<Common>();		/*Commonコンポーネント取得*/
		manager = FindObjectOfType<Manager>();	/*Managerコンポーネント取得*/
		hpImage = FindObjectOfType<HitPointImage>();	/*HitPointImageコンポーネント取得*/
		laser = true;/*初期はレーザー*/
		while(true){
			/*レーザーの場合*/
			if(laser){
				min = 1;
				switch(shotLevel){
				case 0:
					max = 1;
					break;
				case 1:
					max = 3;
					break;
				case 2:
					max = 5;
					break;
				}
			/*拡散の場合*/
			}else if(diffusion){
				min = 5;
				switch(shotLevel){
				case 0:
					max = 1;
					break;
				case 1:
					max = 7;
					break;
				case 2:
					max = 9;
					break;
				}
			}
			/*HP以下の時は弾を出さない*/
			if(HP > 0){
				transform.GetComponentInChildren<GunShot>().Sound();	/*子オブジェクトからSEを鳴らす*/
				common.Shot (transform.GetChild(0));/*初期弾をshotPosの位置、角度で作成*/
				for(int i = min; i < max; i++){
					common.Shot (transform.GetChild(i));/*弾をshotPosの位置、角度で作成*/
				}
			}
			yield return new WaitForSeconds(common.shotInterval);/*shotIntervalの間隔で処理*/
		}
	}
	

	void Update () {
		/*メニュー表示中は実行しない*/
		if(!GameObject.FindGameObjectWithTag("Menu")){
			/*タッチされたら*/
			if(Input.touchCount > 0){
				/*タッチしたスクリーン座標をワールド座標へ*/
				Touch touch = Input.GetTouch (0);	/*0番目のタッチデータをtouchに取得*/
				Vector3 screenPos = touch.position;	/*タッチ座標をscreenPosに代入*/
				screenPos = orthoCamera.ScreenToWorldPoint (screenPos); /*タッチ座標をスクリーン座標へ変換*/
				
				/*オブジェクトをタッチ座標へ移動させる*/
				screenPos.z = 0f; /*カメラのz座標を引き継がないよう0に戻す*/
				Vector3 pos = this.gameObject.transform.position;	/*オブジェクトの座標をposへ代入*/

				/*タッチ座標へ近づける*/
				/*座標の差が0.1未満ならブレないように処理*/
				if(Mathf.Abs (pos.x -screenPos.x) < 0.1f){
				}else{
					if(pos.x < screenPos.x){ 
						pos.x += 0.1f;
					}else if(pos.x > screenPos.x){
						pos.x -= 0.1f;
					}
				}
				if(Mathf.Abs (pos.y - screenPos.y) < 0.1f){
				}else{
					if(pos.y < screenPos.y){
						pos.y += 0.1f;
					}else if(pos.y > screenPos.y){
						pos.y -= 0.1f;
					}
				}

				this.gameObject.transform.position = pos; /*計算したposをオブジェクト座標へ代入*/
				//Debug.Log ("Screen:" + screenPos);
				//Debug.Log ("Object:" + pos);
			}
			/*無敵時間*/
			if(unrivaledTime < 3f){
				unrivaledTime += Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter (Collider collider){
		string layerName = LayerMask.LayerToName(collider.gameObject.layer); /*レイヤー名を取得*/

		/*レイヤー名がe_Bulletの時、弾を削除*/
		if(layerName == "e_Bullet"){
			Destroy (collider.gameObject);	/*弾の削除*/
		}

		/*メニュー表示中は実行しない*/
		if(!GameObject.FindGameObjectWithTag("Menu")){

			/*敵の弾か敵に当たったらダメージを受ける*/
			if(layerName == "e_Bullet" || layerName == "Enemy"){

				/*被弾から３秒以内は無敵*/
				if(unrivaledTime > 3){
					HP -= 1;	/*HPを減らす*/
					hpImage.DestroyImage();
					unrivaledTime = 0f;	/*無敵時間開始*/
					
					/*HP0以下になったら退却処理、残機があるならダメージSE*/
					if(HP <= 0){
						StartCoroutine("Destroy");	/*退却処理を呼び出す*/
					}else{
						/*被弾時のアニメーション*/
						this.gameObject.transform.GetComponentInChildren<ModelAnimation>().DamageAnimation();
						
						int m = Random.Range(0,5);	/*配列用の添え字*/
						/*AudioSourceを調整*/
						audioSource.PlayOneShot(damage[m]);	/*被弾時のサウンド*/
					}
				}
			}
		}

	}

	IEnumerator Destroy(){
		/*被弾時のアニメーション*/
		this.gameObject.transform.GetComponentInChildren<ModelAnimation>().GameOverAnimation();
		audioSource.PlayOneShot(end);	/*HP０の時のサウンド*/
		yield return new WaitForSeconds(2f);/*2秒待つ*/
		common.Damage();	/*破壊される*/
		manager.GameOver();
		Destroy (gameObject);	/*プレイヤーの削除*/
	}
}
