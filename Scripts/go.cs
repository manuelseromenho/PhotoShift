using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class go : MonoBehaviour {

	//string linhasString;
	//string colunasString;

	//public GameObject linhas_gobject;
	//public GameObject colunas_gobject;

	//public int nrLinhas = 2;
	//public int nrColunas = 4;


	/*void Start () 
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

		if (!(InputsMatriz.linhasString == "")) 
		{
			nrLinhas = int.Parse (InputsMatriz.linhasString, System.Globalization.NumberStyles.Integer);
		}

		if (!(InputsMatriz.colunasString == ""))
		{
			nrColunas = int.Parse (InputsMatriz.colunasString, System.Globalization.NumberStyles.Integer);		
		}

		int matrix = nrLinhas * nrColunas;
		var nrResources = Resources.LoadAll<Texture2D>("");
		Resources.UnloadUnusedAssets();
		int intArrayMax = nrResources.Length;

		if(matrix > intArrayMax)
		{
		}
		SceneManager.LoadScene("matriz");
	}*/


	public void go3x2()
	{
		InputsMatriz.linhasInt = 3;
		InputsMatriz.colunasInt = 2;
		SceneManager.LoadScene("matriz");
	}

	public void go4x3()
	{
		InputsMatriz.linhasInt = 4;
		InputsMatriz.colunasInt = 3;
		SceneManager.LoadScene("matriz");
	}

	public void go7x2()
	{
		InputsMatriz.linhasInt = 7;
		InputsMatriz.colunasInt = 2;
		SceneManager.LoadScene("matriz");
	}

}

public class InputsMatriz //guarda valores para outra Scene 
{
	//public static string linhasString;
	//public static string colunasString;
	public static int linhasInt;
	public static int colunasInt;
}

