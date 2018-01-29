using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {

	void Start () 
	{

		//string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		SceneManager.LoadScene("principal");

	}
}
