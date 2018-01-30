using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*!
* \file
* \brief A classe go é utilizada para dar funcionalidade aos botões.
* \details A classe go é utilizada para dar funcionalidade aos botões. Botões de tamanho de matriz e para o modo "jogo".
* \author Manuel Seromenho
* \author Valter António
* \date 29 Janeiro 2018
* \bug sem erros detetados
* \warning nenhum warning
* \version 1.0
* \copyright GNU Public License.
*/

/// <summary>
/// Classe go: É utilizada para dar funcionalidade aos botões. Botões de tamanho de matriz e para o modo "jogo".
/// São implementados os métodos: go3x2(), go4x3(), go7x2(), goPhotoMatriz.
/// </summary>
public class go : MonoBehaviour {

	/// <summary>
  	/// O método go3x2():
  	/// - é utilizado para dar funcionalidade ao botão 3x2, de maneira a abrir a matriz com 3 linhas e 2 colunas.
  	/// </summary>
	public void go3x2()
	{
		InputsMatriz.linhasInt = 3;
		InputsMatriz.colunasInt = 2;
		SceneManager.LoadScene("matriz");
	}

	/// <summary>
  	/// O método go4x3():
  	/// - é utilizado para dar funcionalidade ao botão 4x3, de maneira a abrir a matriz com 4 linhas e 3 colunas.
  	/// </summary>
	public void go4x3()
	{
		InputsMatriz.linhasInt = 4;
		InputsMatriz.colunasInt = 3;
		SceneManager.LoadScene("matriz");
	}

	/// <summary>
  	/// O método go7x2():
  	/// - é utilizado para dar funcionalidade ao botão 7x2, de maneira a abrir a matriz com 7 linhas e 2 colunas.
  	/// </summary>
	public void go7x2()
	{
		InputsMatriz.linhasInt = 7;
		InputsMatriz.colunasInt = 2;
		SceneManager.LoadScene("matriz");
	}

	/// <summary>
  	/// O método goPhotoMatriz():
  	/// - é utilizado para dar funcionalidade ao botão de jogo, de maneira a abrir a matriz com 3 linhas e 2 colunas.
  	/// </summary>
	public void goPhotoMatriz()
	{
		InputsMatriz.linhasInt = 3;
		InputsMatriz.colunasInt = 2;
		SceneManager.LoadScene("photoMatriz");
	}

}

/// <summary>
/// Classe InputsMatriz: Guarda valores para outra Scene 
/// </summary>
public class InputsMatriz 
{
	public static int linhasInt;
	public static int colunasInt;
}

