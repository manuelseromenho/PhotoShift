using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*!
* \file
* \brief Na classe SwapImageTouch é implementada a funcionalidade de trocar imagens utilizado o toque ou click de rato.
* \details Nesta classe é implementada a funcionalidade de trocar imagens 
* utilizando o toque num ecran de telemovel Android, ou o click de rato num computador Windows.
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Nesta classe é implementada a funcionalidade de trocar imagens 
/// utilizando o toque num ecran de telemovel Android, ou o click de rato num computador Windows.
/// São implementados os métodos: OnPointerClick()
/// </summary>
public class SwapImageTouch : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, 
{
	int flag = 0;
	Texture teste1;
	Texture teste2;
	GameObject teste3;
	Vector3 teste1_scale;
	Vector3 teste2_scale;

	/// <summary>
  	/// O método OnPointerClick():
  	/// - é utilizado para selecionar as imagens a serem trocadas e trocar estas posteriormente.
  	/// </summary>
  	/// <param name="eventData">Este parametro do tipo PointerEventData, associa o evento do "toque" ou "click de rato"</param>
	public void OnPointerClick(PointerEventData eventData)
	{
		if(flag == 0)
		{
			teste1 = eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture;//associa textura da primeira imagem clicada
			teste1_scale = eventData.pointerCurrentRaycast.gameObject.GetComponent<RectTransform>().localScale;//associa escala da primeira imagem clicada
			teste3 = eventData.pointerCurrentRaycast.gameObject;
			flag = 1;
		}
		else
		{
			teste2 = eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture;  //associa textura da segunda imagem clicada
			teste2_scale =  eventData.pointerCurrentRaycast.gameObject.GetComponent<RectTransform>().localScale; //associa escala da segunda imagem clicada

			eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture = teste1; //swap da segunda textura pela primeira
			eventData.pointerCurrentRaycast.gameObject.GetComponent<RectTransform> ().localScale = teste1_scale; //swap da segunda escala pela primeira

			teste3.GetComponent<RawImage>().texture = teste2; //swap da primeira textura pela segunda
			teste3.GetComponent<RectTransform> ().localScale = teste2_scale; //swap da primeira escala pela segunda
			flag = 0;
		}

		//Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
	}
}

