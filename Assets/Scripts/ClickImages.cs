using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickImages : MonoBehaviour, IPointerClickHandler
{ 
	public ToastMessage mensagem;
	public testescript saberTag;

	private void Update()
	{

		if (Input.GetKeyDown (KeyCode.Space))
		{
			saberTag.images[0].SetActive(false);

		}


	}

	public void OnPointerClick(PointerEventData eventData)
	{
		//ver raycasthit2d
		//para carregamento, vai levar tempo...



		// OnClick code goes here ...
		Debug.Log("imagem clicada" + GetInstanceID());
		//Debug.Log ("tag ->" + saberTag.images [0].tag);;
		//RaycastHit2D


//		string sceneName = PlayerPrefs.GetString("lastLoadedScene");
//		SceneManager.LoadScene(sceneName);
		//mensagem.showToastOnUiThread ("THIS IS SPARTA!!!");
		if (Application.platform == RuntimePlatform.Android) {
			mensagem.showToastOnUiThread ("THIS IS SPARTA!!!");

		}
	}
}
