using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

	public float timeLeft;

	public bool stop = true;

	private float minutes;
	private float seconds;

	public Text timerText;

	// Use this for initialization
	public void Start () {
		stop = false;

		Update ();
		StartCoroutine (updateCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {
		if (stop)
			return;
		timeLeft -= Time.deltaTime;

		minutes = Mathf.Floor (timeLeft / 60);
		seconds = timeLeft % 60;
		if (seconds > 59) {
			seconds = 59;
		}
		if (minutes < 0) {
			stop = true;
			minutes = 0;
			seconds = 0;
			//SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0));
		}
	}

	private IEnumerator updateCoroutine(){
		while (!stop) {
			timerText.text = string.Format ("{0:0}:{1:00}", minutes, seconds);
			yield return new WaitForSeconds (0.2f);
		}
	}
}
