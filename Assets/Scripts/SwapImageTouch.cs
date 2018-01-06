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


		//if(eventData.pointerCurrentRaycast.gameObject.name != tempo_name)


	}

}
