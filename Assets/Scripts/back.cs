using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*!
* \file
* \brief A classe back é apenas utilizada para dar funcionalidade ao botão back.
* \details Na classe back é apenas utilizada para dar funcionalidade ao botão back, de maneira a voltar para a primeira "scene"
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Classe back: Funcionalidade do botão back.
/// São implementados os métodos: Start()
/// </summary>
public class back : MonoBehaviour {

	/// <summary>
  	/// O método Start():
  	/// - Load da "scene principal"
  	/// </summary>
  	void Start () 
	{
		//string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		SceneManager.LoadScene("principal");
	}
}
