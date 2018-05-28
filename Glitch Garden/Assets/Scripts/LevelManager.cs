using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public float autoLoadNextLevelAfter;

	void Start()
	{
		if (autoLoadNextLevelAfter <= 0) 
		{
			Debug.Log ("Level auto load disable, use a positive number in seconds");
		} 
		else 
		{
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}

	}

	public void LoadLevel(string name)
	{
		Debug.Log ("Load level requested: " + name);
		Debug.Log ("Current Difficulty is " + PlayerPrefsManager.GetDifficulty());
		SceneManager.LoadScene (name);
	}

	public void QuitLevel()
	{
		Debug.Log ("I want to quit!");
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
