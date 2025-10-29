using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private float delay = 0.7f;
	public void LoadTestScene()
	{
		StartCoroutine(DelaySceneLoad());
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
	private IEnumerator DelaySceneLoad()
	{
		yield return new WaitForSecondsRealtime(delay);
		SceneManager.LoadScene("TestingScene");
	}
}
