using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void LoadTestScene()
	{
		SceneManager.LoadScene("TestingScene");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
