using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {
	
	void StartGame(){
		SceneManager.LoadScene (1);
	}

	void MainMenu(){
		SceneManager.LoadScene (0);
	}
}
