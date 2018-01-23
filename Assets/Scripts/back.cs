using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEditor;
//using System.IO;

public class back : MonoBehaviour {

	void Start () 
	{
		
		string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		SceneManager.LoadScene(sceneName);

	}

	// Update is called once per frame
	void Update () {

	}


}
