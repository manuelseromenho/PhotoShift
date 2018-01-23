using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class swapImage : MonoBehaviour
{
	bool firstUp = false;
	bool secondUp = false;
	int firstKey = 0;
	int secondKey = 0;
	public testescript testeScript;
	Vector3 first_scale;
	Vector3 second_scale;
	Vector3 tempo_scale;

	string[] keys = {"q","w","e","r","t","y","u", "a","s","d","f","g", "h", "j"};


	void Start () 
	{
		//		this.images = new List<GameObject> ();
		//
		//		for (int i = 0; i < nrLinhas; i++) 
		//		{
		//			var rowGO = Instantiate (row, this.transform); //instancia o espaço para a linha
		//
		//			for (int j = 0; j < nrColunas; j++) 
		//			{
		//				var imageGO = Instantiate (image, rowGO.transform); //instancia o espaço para a imagem, na linha
		//				//imageGO.GetComponent<RectTransform> ().localScale = new Vector3 (-1, 1, 1); //mirror
		//				this.images.Add (imageGO);//insere as linhas e espaços na lista images (linhas e colunas...)
		//			}
		//		}
		//
		//		//clickaction
		//		for (int i = 0; i < (nrLinhas * nrColunas); i++) 
		//		{
		//			this.images[i].SetActive(true);
		//			//this.images[i].AddComponent<ClickImages> ();
		//		}
		//
		//		var nrResources = Resources.LoadAll<Texture2D>("");
		//		Resources.UnloadUnusedAssets();
		//
		//		int intMatriz = nrLinhas * nrColunas;
		//		//int total = nrResources.Length;
		//
		//
		//		for (int i = 0; i < intMatriz; i++) 
		//		{
		//			this.images[i].GetComponent<RawImage> ().texture = nrResources [i]; //acede-se ao array images
		//		}
		//
		//		//Debug.Log("MAD MANUEL"+ gameObject.GetInstanceID());

	}

	void Update()
	{
		int keynr = 0;

		foreach (string key in keys) 
		{
			//			if(key != null)
			//			{
			if (firstUp == true && secondUp == false && Input.GetKeyDown(key)) //apanha a segunda tecla (referente à lista de teclas)
			{
				keynr = System.Array.IndexOf (keys, key);
				//Debug.Log (key + "second keynr" + keynr);
				secondUp = true;
				secondKey = keynr;
			}
			if (firstUp == false && Input.GetKeyDown(key)) //apanha a primeira tecla (referente à lista de teclas)
			{
				keynr = System.Array.IndexOf (keys, key);
				//Debug.Log(key + "first keynr" + keynr);
				firstUp = true;
				firstKey = keynr;
			}
			//}
			//else{Debug.Log ("tecla errada");}

			//keynr++;
		} 


		if(firstUp == true && secondUp == true)//caso as duas imagens estejam escolhidas
		{
			if(firstKey != secondKey)//caso a primeira não seja igual à segunda
			{
				swapImages (firstKey, secondKey);
			}
			firstUp = false; secondUp = false;
		}
	}

	void swapImages(int first, int second)
	{
		var tempo = this.testeScript.images [first].GetComponent<RawImage> ().texture;
		tempo_scale = this.testeScript.images [first].GetComponent<RectTransform> ().localScale;
		this.testeScript.images[first].GetComponent<RawImage> ().texture = this.testeScript.images[second].GetComponent<RawImage> ().texture;
		this.testeScript.images[first].GetComponent<RectTransform> ().localScale = this.testeScript.images[second].GetComponent<RectTransform> ().localScale;
		this.testeScript.images [second].GetComponent<RawImage> ().texture = tempo;	
		this.testeScript.images [second].GetComponent<RectTransform> ().localScale = tempo_scale;	

		tempo = null;

	}
}
