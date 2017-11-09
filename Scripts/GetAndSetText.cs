using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAndSetText : MonoBehaviour {

	public InputField linhas;
	public InputField colunas;

	public string linhasString;
	public string colunasString;


	public void setget()
	{
		linhasString = linhas.text;
		colunasString = colunas.text;

		//Debug.Log ("Linhas: " + linhasString  + "\n" + "Colunas: " + colunasString);
	}
}
