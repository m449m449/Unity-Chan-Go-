using UnityEngine;
using System.Collections;

public class ModelAnimation : MonoBehaviour {
	private Animator animator;	/*Animatorコンポーネント*/
	private int damageId;
	private int overId;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	/*Animatorコンポーネント取得*/

		/*AnimatorのDamageパラーメータ取得*/
		damageId = Animator.StringToHash("Damage"); /*被弾*/
		overId = Animator.StringToHash("Over");	/*ゲームオーバー*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DamageAnimation(){
		animator.SetTrigger(damageId);	/*被弾時のアニメーション*/
	}

	public void GameOverAnimation(){
		animator.SetTrigger(overId);	/*被弾時のアニメーション*/
	}
}
