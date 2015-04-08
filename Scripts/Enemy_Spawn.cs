using UnityEngine;
using System.Collections;

public class Enemy_Spawn : MonoBehaviour {

	public GameObject[] waves;	/*Waveを格納する配列*/
	private int currentWave;	/*現在のWave*/
	private Manager manager; /*Managerコンポーネント*/

	// Use this for initialization
	IEnumerator Start () {
		manager = FindObjectOfType<Manager>();	/*Managerコンポーネント取得*/

		/*Waveが無ければ終了*/
		if(waves.Length == 0){
			yield break;
		}

		while(true){
			/*Waveの作成*/
			GameObject wave = (GameObject)Instantiate(waves[currentWave],transform.position,Quaternion.identity);

			wave.transform.parent = transform;	/*waveの親をEnemy_Spawnにする*/

			/*waveのEnemyが全滅するまで待機*/
			while(wave.transform.childCount != 0){
				yield return new WaitForEndOfFrame();
			}

			Destroy (wave);	/*Waveの削除*/

			/*格納されるWaveを全て実行したらゲームクリア*/
			if(waves.Length <= ++currentWave){
				manager.GameClear();
				break;
			}

		}
	
	}
}
