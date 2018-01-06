using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickImages : MonoBehaviour, IPointerClickHandler 
{
	void Update()
	{
		
	} 


	public void OnPointerClick(PointerEventData eventData)
	{
		//ver raycasthit2d
		//para carregamento, vai levar tempo...

		// OnClick code goes here ...
		//Debug.Log("imagem clicada" + GetInstanceID());
		//this.testeScript.images [0].GetComponent<RawImage> ().texture = null;
		//testeScript.images [0].SetActive (false);

		/*var tempo = this.testeScript.images [first].GetComponent<RawImage> ().texture;
		this.testeScript.images[first].GetComponent<RawImage> ().texture = this.testeScript.images[second].GetComponent<RawImage> ().texture;
		this.testeScript.images [second].GetComponent<RawImage> ().texture = tempo;	
		tempo = null;*/

		//Debug.Log ("tag ->" + saberTag.images [0].tag);;
		//RaycastHit2D


		//		string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		//		SceneManager.LoadScene(sceneName);
		//mensagem.showToastOnUiThread ("THIS IS SPARTA!!!");
		/*if (Application.platform == RuntimePlatform.Android) 
		{
			mensagem.showToastOnUiThread ("THIS IS SPARTA!!!");
		}*/


		/*var temp = saberTag.images [0];
		this.saberTag.images [0] = this.saberTag.images [1];
		this.saberTag.images [1] = temp;*/

	}



}





	

