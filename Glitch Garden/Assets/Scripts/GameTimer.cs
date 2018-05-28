using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour 
{
	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	private GameObject loseCollider;

	public float levelSeconds = 99f;

	void Start () 
	{
		slider = GetComponent<Slider> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		audioSource = GetComponent<AudioSource> ();
		winLabel = GameObject.Find ("You Win");
		winLabel.SetActive (false);
		loseCollider = GameObject.Find ("Lose Collider");
	}

	void Update () 
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) 
		{
			audioSource.Play ();
			winLabel.SetActive (true);
			loseCollider.SetActive (false);
			Invoke("LoadNextLevel", audioSource.clip.length); 
			isEndOfLevel = true;
		}
	}

	void LoadNextLevel()
	{
		levelManager.LoadNextLevel ();
	}
}
