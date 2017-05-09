using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {
	
	public void StartGame(){
		SceneManager.LoadScene (2);
	}

	public void StartIntro(){
		SceneManager.LoadScene (1);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
}
