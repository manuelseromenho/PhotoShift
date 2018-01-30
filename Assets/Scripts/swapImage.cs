using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*!
* \file
* \brief Na classe swapImage é implementada a funcionalidade de trocar imagens utilizado o teclado.
* \details Nesta classe é implementada a funcionalidade de trocar imagens utilizando o teclado,
* utilizando as teclas "q","w","e","r","t","y","u", "a","s","d","f","g", "h","j", estando estas
* numeradas de 1 a 14. 
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Nesta classe é implementada a funcionalidade de trocar imagens utilizando o teclado,
/// utilizando as teclas "q","w","e","r","t","y","u", "a","s","d","f","g", "h","j", estando estas
/// numeradas de 1 a 14. 
/// São implementados os métodos: Update(), swapImages()
/// </summary>
public class swapImage : MonoBehaviour
{
	bool firstUp = false;
	bool secondUp = false;
	int firstKey = 0;
	int secondKey = 0;
	public maincodeScript testeScript;
	Vector3 first_scale;
	Vector3 second_scale;
	Vector3 tempo_scale;

	string[] keys = {"q","w","e","r","t","y","u", "a","s","d","f","g", "h","j"};


	/// <summary>
	/// Método Update: este método atualiza o interface gráfico, após sererem premidas 2 teclas,
	/// sendo a primeira tecla a primeira imagem, e a segunda tecla a segunda imagem a serem trocadas.
	/// </summary>
	void Update()
	{
		int keynr = 0;

		foreach (string key in keys) 
		{
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


	/// <summary>
  	/// O método swapImages():
  	/// - é utilizado para trocar as imagens previamente seleccionadas da matriz.
  	/// </summary>
  	/// <param name="first">Este parametro indica a posição da primeira imagem</param>
  	/// <param name="second">Este parametro indica a posição da segunda imagem</param>
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
