using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*!
* \file
* \brief A classe exit é apenas utilizada para dar funcionalidade ao botão exit.
* \details Na classe back é apenas utilizada para dar funcionalidade ao botão exit, de maneira a sair da app
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Classe exit: Funcionalidade para botão exit.
/// São implementados os métodos: Start()
/// </summary>
public class exit : MonoBehaviour 
{
	/// <summary>
  	/// O método doExitGame():
  	/// - Funcionalidade de "Quit", que pode ser aplicada a um botão de exit.
  	/// </summary>
	public void doExitGame()
	{
		Application.Quit ();
	}


}
