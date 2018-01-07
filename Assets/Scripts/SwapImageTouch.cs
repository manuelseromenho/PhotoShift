using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SwapImageTouch : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, 
{
	int flag = 0;
	//string tempo_name="";
	Texture teste1;
	Texture teste2;
	GameObject teste3;
	Vector3 teste1_scale;
	Vector3 teste2_scale;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(flag == 0)
		{
			//tempo_name = eventData.pointerCurrentRaycast.gameObject.name;
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

/*
public class SwapImageTouch : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, 
{
	int flag = 0;
	//string tempo_name="";
	Texture teste1;
	Texture teste2;
	GameObject teste3;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(flag == 0)
		{
			//tempo_name = eventData.pointerCurrentRaycast.gameObject.name;
			teste1 = eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture;
			teste3 = eventData.pointerCurrentRaycast.gameObject;
			flag = 1;
		}
		else
		{
			teste2 = eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture;
			eventData.pointerCurrentRaycast.gameObject.GetComponent<RawImage> ().texture = teste1;
			teste3.GetComponent<RawImage>().texture = teste2;
			flag = 0;
		}

		Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
	}
}
*/