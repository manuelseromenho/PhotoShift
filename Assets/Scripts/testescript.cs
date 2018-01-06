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
	//public GetAndSetText tamanhoMatriz;
	//public go tamanhoMatriz;

	private int nrLinhas = 2;
	private int nrColunas = 4;

	public List<GameObject> images;

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

		int matrix = nrLinhas * nrColunas;
		//clickaction
		for (int k = 0; k < matrix; k++) 
		{
			this.images[k].SetActive(true);
			Debug.Log (this.images [k] + " is active!");
			//this.images[k].AddComponent<ClickImages> ();
		}



		Shifting ();

		//Debug.Log("MAD MANUEL"+ gameObject.GetInstanceID());
	}

	public void Shifting()
	{
		//this.images.RemoveAll ();

		var nrResources = Resources.LoadAll<Texture2D>("");
		Resources.UnloadUnusedAssets();

		int intMatriz = nrLinhas * nrColunas;
		int total = nrResources.Length;
		//var total = nrResources.Distinct().ToList().Count;
		//Debug.Log("Image Length= " + total);

		int intArrayMax = total;//nr de imagens nos resources;
		int[] intArray = new int[intArrayMax];

		for (int i = 0; i < intArrayMax; i++)
		{
			intArray[i] = i;
		}
		Shuffle(intArray);



		//		for (int i = 0; i < nrResources.Length; i++) {
		//			this.images [i].GetComponent<RawImage> ().texture = nrResources [i]; //acede-se ao array images
		//		}


		//Aqui é inserido na lista de images um conjunto de imagens aleatórias, em que também é aleatório o seu Mirror Vertical/Horizontal e Rotação"
		for (int i = 0; i < intMatriz; i++) 
		{
			this.images[i].GetComponent<RawImage> ().texture = nrResources [intArray[i]]; //acede-se ao array images

			/*cria-se aqui um array com dois valores, 0 ou 180, que vão servir de base para as duas possibilidades de "mirrorVertical" e "mirrorHorizontal". Com isto possibilitamos várias combinações de mirror.*/
			var myArray = new int[] { -1, 1 };//array 
			var mirrorVertical = myArray[Random.Range(0,myArray.Length)];
			var mirrorHorizontal = myArray[Random.Range(0,myArray.Length)];
			this.images[i].GetComponent<RectTransform>().localScale = new Vector3(mirrorVertical, mirrorHorizontal, 0);
			//this.images[i].GetComponent<RectTransform>().localEulerAngles = new Vector3(mirrorVertical, mirrorHorizontal, 0);
			//this.images [i].GetComponent<RawImage> ().texture = this.images [i].GetComponent<RectTransform> ().localEulerAngles;
			//this.images[i].GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(mirrorVertical, mirrorHorizontal, 0));
		}

		/*for (int i = 0; i < intArrayMax; i++)
		{
			Debug.Log(intArray[i]);
		}*/

	}

	//cria e preenche um array com valores inteiros, com o tamanho indicado pelo utilizador linhasxcolunas
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

	//metodo utilizado para baralhar um conjunto de numero dentro de um array
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

	public void ClickToChange()
	{
		Shifting ();
	}


}

