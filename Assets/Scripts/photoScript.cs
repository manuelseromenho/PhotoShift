using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//NOTE: we're using LukeWaffel.AndroidGallery, without this it won't work
using LukeWaffel.AndroidGallery;

//using UnityEditor;
//using System.IO;


public class photoScript : MonoBehaviour {

	//[Header ("References")]
	public Image frame;
	//public RawImage TextFrame;
	public GameObject Image;
	public GameObject Row;
	//public GetAndSetText tamanhoMatriz;
	//public go tamanhoMatriz;

	private int nrLinhas = 3;
	private int nrColunas = 2;
	public int intMatriz;
	public int[] intArray;

	private int i = 0;
	private int j = 0;

	public List<GameObject> images;
	public Texture2D[] slices;


	void Start()
	{
		intMatriz = nrLinhas*nrColunas;

		images = new List<GameObject> ();
		for (i = 0; i < nrLinhas; i++) 
		{
			var rowGO = Instantiate (Row, transform); //instancia o espaço para a linha

			for (j = 0; j < nrColunas; j++) 
			{
				var imageGO = Instantiate (Image, rowGO.transform); //instancia o espaço para a imagem, na linha
				images.Add (imageGO);//insere as linhas e espaços na lista images (linhas e colunas...)
			}
		}


	}

	//This function is called by the Button
	public void OpenGalleryButton()
	{
		//NOTE: we're using LukeWaffel.AndroidGallery (As seen at the top of this script), without this it won't work
		//This line of code opens the Android image picker, the parameter is a callback function the AndroidGallery script will call when the image has finished loading
		AndroidGallery.Instance.OpenGallery (ImageLoaded);



	}

	//This is the callback function we created
	public void ImageLoaded()
	{
		Debug.Log("The image has succesfully loaded!");
		frame.sprite = AndroidGallery.Instance.GetSprite();
		Shifting ();
	}




	public void Shifting()
	{
		//1º Selecionar foto
		//2º Cortar foto em várias partes e guardar as partes num array de texturas
		//3º Criar um array de inteiros para criar uma situação de random
		//4ª Mostrar partes da imagem com efeito random

		//Debug.Log ("intMatriz = " + intMatriz); Devolve o valor correto ...
		//intMatriz = nrLinhas * nrColunas;

		int[] intArray = new int[intMatriz];

		/****************************************
		 * Criação do array intArray[i] com 
		 * valores aleatórios, consoante o numero 
		 * imagens existentes
		****************************************/
		for (i = 0; i < intMatriz; i++)
		{
			intArray[i] = i;
		}

		Shuffle(intArray);

		//You can put anything in the callback function. You can either just grab the image, or tell your other scripts the custom image is available


		GameObject tmpGO = GameObject.FindGameObjectWithTag("Slot1");
		Sprite sprity = tmpGO.GetComponent<Image> ().sprite;
		//Sprite sprity = frame.sprite;


		//textFrame.frame.sprite = AndroidGallery.Instance.GetSprite();

		//int xpto = (int)textFrame.frame.sprite.textureRect.x;
		//int ypto = (int)textFrame.frame.sprite.textureRect.y;
		int xpto = (int)sprity.textureRect.x;
		int ypto = (int)sprity.textureRect.y;

		//int xpto_width = (int)textFrame.frame.sprite.textureRect.width;
		//int ypto_height = (int)textFrame.frame.sprite.textureRect.height;
		int xpto_width = (int)sprity.textureRect.width;
		int ypto_height = (int)sprity.textureRect.height;


		Debug.Log ("Posições -> XPTO X: " + xpto + "YPTO: " + ypto);
		Debug.Log("Tamanhos ->xpto_width: " + xpto_width + " ypto_height = " + ypto_height);

		/*int spriteWidth = (int)frame.sprite.rect.width;
		int spriteHeight = (int)frame.sprite.rect.height;
		Debug.Log("SpriteWidth: " + spriteWidth + " SpriteHeight = " + spriteHeight);*/

		int sliceWidth = xpto_width / nrColunas;
		int sliceHeight = ypto_height / nrLinhas;
		Debug.Log("SliceWidth: " + sliceWidth + " SliceHeight = " + sliceHeight);

		int k = 0;

		slices = new Texture2D[intMatriz];
		//Texture2D slice1st;


		var croppedTexture = new Texture2D (sliceWidth, sliceHeight);
		/*var pixels = sprity.texture.GetPixels(0, 0, sliceWidth, sliceHeight );
		croppedTexture.SetPixels( pixels );
		croppedTexture.Apply();
		slices [0] = croppedTexture;*/
		//images [0].GetComponent<RawImage> ().texture = croppedTexture;

		/*croppedTexture = new Texture2D (sliceWidth, sliceHeight);
		pixels = sprity.texture.GetPixels(0, sliceHeight, sliceWidth, sliceHeight );
		croppedTexture.SetPixels( pixels );
		croppedTexture.Apply();
		slices [1] = croppedTexture;*/
		//this.images [1].GetComponent<RawImage> ().texture = croppedTexture;

		//Debug.Log ("TESTE TOU AQUI");

		for (i = 0; i < nrColunas; i++) 
		{
			for (j = 0; j < nrLinhas; j++) 
			{
				croppedTexture = new Texture2D (sliceWidth, sliceHeight);
				//corta uma slice da imagem, com base na localização x,y e tamanho width, height
				var pixels = sprity.texture.GetPixels( 
					i*sliceWidth, 
					j*sliceHeight,
					sliceWidth, 
					sliceHeight );

				//				var pixels = frame.sprite.texture.GetPixels( 
				//					xpto, 
				//					ypto,
				//					sliceWidth, 
				//					sliceHeight );


				croppedTexture.SetPixels( pixels );
				croppedTexture.Apply();


				slices [k] = croppedTexture;//guarda a slice no array de texturas
				//slice1st = croppedTexture;
				k = k + 1;
			}
		}





		for (i = 0; i < intMatriz; i++) 
		{
			//Aqui é inserido na lista de "images" um conjunto de imagens aleatórias, em que também é aleatório o seu Mirror Vertical/Horizontal e Rotação
			//this.images[i].GetComponent<RawImage> ().texture = slices [intArray[i]]; //acede-se ao array images
			images[i].GetComponent<RawImage> ().texture = slices[intArray[i]]; //acede-se ao array images
		}

	}


	//metodo utilizado para baralhar um conjunto de numero dentro de um array
	public void Shuffle(int[] obj)
	{
		for (i = 0; i < obj.Length; i++)
		{
			int temp = obj[i];
			int objIndex = Random.Range(0, obj.Length);
			obj[i] = obj[objIndex];
			obj[objIndex] = temp;
		}
	}




}

