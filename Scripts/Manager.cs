using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject player;	/*プレイヤーオブジェクト*/
	public GameObject menuBack;	/*メニューの背景*/
	public GameObject startEvent;	/*スタートメニュー*/
	public GameObject endEvent;	/*ゲームオーバーメニュー*/
	public GameObject clearEvent;	/*クリアメニュー*/


	void Start () {
		player = GameObject.Find("Player");	/*プレイヤーを検索し取得*/
	}

	public void GameClear(){
		/*メニュー背景の作成*/
		Instantiate(menuBack,menuBack.transform.position,menuBack.transform.rotation);

		/*クリアメニューの作成*/
		Instantiate(clearEvent,clearEvent.transform.position,clearEvent.transform.rotation);
	}

	public void GameOver(){
		/*メニュー背景の作成*/
		Instantiate(menuBack,menuBack.transform.position,menuBack.transform.rotation);

		/*ゲームオーバーメニューの作成*/
		Instantiate(endEvent,endEvent.transform.position,endEvent.transform.rotation);
	}
	
}
