using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class testescript : MonoBehaviour {

	public GameObject image;
	public GameObject row;
	public Texture2D texture;

	//public GetAndSetText tamanhoMatriz;
	//public go tamanhoMatriz;

	int nrLinhas = 1;
	int nrColunas = 1;

	public List<GameObject> images;
	//public static string helo;
	// Use this for initialization
	void Start () 
	{
		//Debug.Log ("Linhas: " + InputsMatriz.linhasString + "\n" + "Colunas: " + InputsMatriz.colunasString);


		if (!(InputsMatriz.linhasString == "")) 
		{
			nrLinhas = int.Parse (InputsMatriz.linhasString, System.Globalization.NumberStyles.Integer);
		}

		if (!(InputsMatriz.colunasString == ""))
		{
			nrColunas = int.Parse (InputsMatriz.colunasString, System.Globalization.NumberStyles.Integer);		
		}







		this.images = new List<GameObject> ();

		for (int i = 0; i < nrLinhas; i++) 
		{
			var rowGO = Instantiate (row, this.transform); //instancia o espaço para a linha

			for (int j = 0; j < nrColunas; j++) 
			{
				var imageGO = Instantiate (image, rowGO.transform); //instancia o espaço para a imagem, na linha
				//imageGO.GetComponent<RectTransform> ().localScale = new Vector3 (-1, 1, 1); //mirror
				this.images.Add (imageGO);//insere as linhas e espaços na lista images (linhas e colunas...)
			}
		}

		//clickaction
		for (int i = 0; i < nrLinhas * nrColunas; i++) 
		{
			this.images[i].SetActive(true);
			this.images[i].AddComponent<ClickImages> ();
		}

		Shifting ();

	}

	public void Shifting()
	{
		//this.images.RemoveAll ();


		int intMatriz = nrLinhas * nrColunas;
		int intArrayMax = 14;//nr de imagens nos resources;
		int[] intArray = new int[intArrayMax];

		for (int i = 0; i < intArrayMax; i++)
		{
			intArray[i] = i;
		}
		Shuffle(intArray);

		var nrResources = Resources.LoadAll<Texture2D>("");
		//		for (int i = 0; i < nrResources.Length; i++) {
		//			this.images [i].GetComponent<RawImage> ().texture = nrResources [i]; //acede-se ao array images
		//		}

		for (int i = 0; i < intMatriz; i++) 
		{
			//this.images[i].GetComponent<RectTransform> ().localScale = new Vector3 (-1, 1, 1);
			this.images[i].GetComponent<RawImage> ().texture = nrResources [intArray[i]]; //acede-se ao array images
			//this.images[i].GetComponent<RawImage>().transform.localScale = new Vector3(1,1,1);

			var myArray = new int[] { 0, 180 };
			var mirrorVertical = myArray[Random.Range(0,myArray.Length)];
			var mirrorHorizontal = myArray[Random.Range(0,myArray.Length)];
			//var rotacao = myArray[Random.Range(0,myArray.Length)]; não necessário pois caso seja mirrorVertical e mirroHorizontal, dá o efeito da rotacao 180º

			this.images[i].GetComponent<RectTransform>().localEulerAngles = new Vector3(mirrorVertical, mirrorHorizontal, 0);
		}

		/*for (int i = 0; i < intArrayMax; i++)
		{
			Debug.Log(intArray[i]);
		}*/

	}


	private void RandomUnique()
	{
		int intArrayMax = nrLinhas * nrColunas;
		int[] intArray = new int[intArrayMax];

		for (int i = 0; i < intArrayMax; i++)
		{
			intArray[i] = i;
		}
		Shuffle(intArray);

		for (int i = 0; i < intArrayMax; i++)
		{
			Debug.Log(intArray[i]);
		}

	}

	public void Shuffle(int[] obj)
	{
		for (int i = 0; i < obj.Length; i++)
		{
			int temp = obj[i];
			int objIndex = Random.Range(0, obj.Length);
			obj[i] = obj[objIndex];
			obj[objIndex] = temp;
		}
	}

}

