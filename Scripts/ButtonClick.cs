using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	public void TestClick() {
		Debug.Log ("Clicked.");
	}

	public void GameStart(){
		Application.LoadLevel("Scene1");	/*scene1へ遷移*/
	}

	public void GameExit(){
		Application.Quit();	/*ゲームを終了する*/
	}

	public void Tutorial(){

	}
}
