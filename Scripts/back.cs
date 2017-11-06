using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		SceneManager.LoadScene(sceneName);

	}

	// Update is called once per frame
	void Update () {

	}
}
