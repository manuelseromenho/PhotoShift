using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class go : MonoBehaviour {

	public string linhasString;
	public string colunasString;

	//public InputField linhas_field;
	//public InputField colunas_field;


	public GameObject linhas_gobject;
	public GameObject colunas_gobject;


	//public GetAndSetText setget;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);

		InputField linhas_field;
		InputField colunas_field;

		linhas_gobject = GameObject.Find ("linhas_field");
		colunas_gobject = GameObject.Find ("colunas_field");

		linhas_field = linhas_gobject.GetComponent<InputField>();
		colunas_field = colunas_gobject.GetComponent<InputField> ();

		linhasString = linhas_field.text.ToString ();
		colunasString = colunas_field.text.ToString();

		InputsMatriz.linhasString = linhasString;
		InputsMatriz.colunasString = colunasString;

		//Debug.Log ("Linhas: " + linhasString  + "\n" + "Colunas: " + colunasString);

		SceneManager.LoadScene("matriz");
	}


}

public class InputsMatriz //guardar valores para outra Scene 
{
	public static string linhasString;
	public static string colunasString;
}