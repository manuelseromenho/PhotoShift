using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testescript : MonoBehaviour {

	public GameObject image;
	public GameObject row;
	public Texture2D texture;

	int nrLinhas = 2;
	int nrColunas = 3;


	private List<GameObject> images;
	// Use this for initialization
	void Start () {
		
		this.images = new List<GameObject> ();
		for (int i = 0; i < nrLinhas; i++) 
		{
			var rowGO = Instantiate (row, this.transform); //instancia o espaço para a linha
			for (int j = 0; j < nrColunas; j++) 
			{
				var imageGO = Instantiate (image, rowGO.transform); //instancia o espaço para a imagem, na linha
				imageGO.GetComponent<RectTransform> ().localScale = new Vector3 (-1, 1, 1); //mirror
				this.images.Add (imageGO);//insere as linhas e espaços na lista images (linhas e colunas...)
			}
		}

		int intArrayMax = nrLinhas * nrColunas;
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

		for (int i = 0; i < intArrayMax; i++) {
			this.images [i].GetComponent<RawImage> ().texture = nrResources [intArray[i]]; //acede-se ao array images
		}

//		for (int i = 0; i < intArrayMax; i++)
//		{
//			Debug.Log(intArray[i]);
//		}



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
