using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using LukeWaffel.AndroidGallery;

/*!
* \file
* \brief Na classe photoScript é implementada a funcionalidade "puzzle".
* \details Nesta classe é implementada e funcionalidade "puzzle", onde o utilizador poderá carregar uma imagem da galeria "android", a foto é cortada e baralhada, de maneira o utilizador interagir e voltar a colocar a foto na disposição correta.
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Classe photoScript: nesta classe é implementada a funcionalidade do lançamento aleatório com comparação dos lançamentos anteriores.
/// São implementados os métodos: Start(), Shifting(), Shuffle()
/// </summary>
public class photoScript : MonoBehaviour {

	public Image frame;
	public GameObject Image;
	public GameObject Row;
	public int intMatriz;
	public int[] intArray;
	public List<GameObject> images;
	public Texture2D[] slices;
	
	private int nrLinhas = 3;
	private int nrColunas = 2;
	private int i = 0;
	private int j = 0;



	//! Método Start
	/**
	* método onde é:
  	* - é inicializada a lista "images" com espaços para serem populados por imagens mais tarde.
	* \return void
	*/
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

	//! Método OpenGalleryButton
	/**
	* Este método é executado através do botão "Select Photo".
	* \return void
	*/
	public void OpenGalleryButton()
	{
		///NOTE: we're using LukeWaffel.AndroidGallery (As seen at the top of this script), without this it won't work
		///This line of code opens the Android image picker, the parameter is a callback function the AndroidGallery script will call when the image has finished loading
		AndroidGallery.Instance.OpenGallery (ImageLoaded);
	}

	//! Método ImageLoaded
	/**
	* este método é executado através do botão "Select Photo". Método callback que serve de parametro a AndroidGallery.Instance.OpenGallery
	* \return void
	*/
	public void ImageLoaded()
	{
		Debug.Log("The image has succesfully loaded!");
		frame.sprite = AndroidGallery.Instance.GetSprite();
		Shifting ();
	}


	/// <summary>
  	/// O método Shifting():
  	/// 1º Selecionar foto
	///	2º Cortar foto em várias partes e guardar as partes num array de texturas
	///	3º Criar um array de inteiros para criar uma situação de random
	///	4ª Mostrar partes da imagem com efeito random
  	/// </summary>
	public void Shifting()
	{
		
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

		GameObject tmpGO = GameObject.FindGameObjectWithTag("Slot1");
		Sprite sprity = tmpGO.GetComponent<Image> ().sprite;

		int xpto = (int)sprity.textureRect.x;
		int ypto = (int)sprity.textureRect.y;
		int xpto_width = (int)sprity.textureRect.width;
		int ypto_height = (int)sprity.textureRect.height;
		int k = 0;

		//Debug.Log ("Posições -> XPTO X: " + xpto + "YPTO: " + ypto);
		//Debug.Log("Tamanhos ->xpto_width: " + xpto_width + " ypto_height = " + ypto_height);

		int sliceWidth = xpto_width / nrColunas;
		int sliceHeight = ypto_height / nrLinhas;
		//Debug.Log("SliceWidth: " + sliceWidth + " SliceHeight = " + sliceHeight);

		slices = new Texture2D[intMatriz];

		var croppedTexture = new Texture2D (sliceWidth, sliceHeight);


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

				croppedTexture.SetPixels( pixels );
				croppedTexture.Apply();

				slices [k] = croppedTexture;//guarda a slice no array de texturas
				k = k + 1;
			}
		}


		for (i = 0; i < intMatriz; i++) 
		{
			//Aqui é populado as texturas da lista de imagens, com as "slices" anteriormente capturadas
			images[i].GetComponent<RawImage> ().texture = slices[intArray[i]]; 
		}

	}

	/// <summary>
  	/// O método Shuffle():
  	/// - é utilizado para baralhar um conjunto de numero dentro de um array, 
  	/// que posteriormente será utilizado para criar aleatoriadade às imagens.
  	/// </summary>
  	/// <param name="obj">O método Shuffle recebe como parametro um array de inteiros</param>
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

