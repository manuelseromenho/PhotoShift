using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//using UnityEditor;
//using System.IO;


public class maincodeScript : MonoBehaviour {

	public GameObject image;
	public GameObject row;
	//public GetAndSetText tamanhoMatriz;
	//public go tamanhoMatriz;

	private int nrLinhas = InputsMatriz.linhasInt;
	private int nrColunas = InputsMatriz.colunasInt;
	private int intMatriz;
	private int flagTrue = 1;
	private int flagBoss = 0;
	private int tempo_j = 1;
	private int flagVerifyIfLast = 1;
	private int mirrorVertical; 
	private int mirrorHorizontal; 
	private int place;
	private int n;

	private int passou;
	private int i = 0;
	private int j = 0;

	public List<GameObject> images;
	public int[] shuffled;
	public int[,] shuffledStory;

	//public string path = "Assets/Resources/dados.txt";
	//public StreamWriter writer;



	void Start () 
	{
		
		intMatriz = nrLinhas * nrColunas;

		shuffled = new int[intMatriz];
		shuffledStory = new int[100, intMatriz];//100 possibilidades de comparação
		for(j = 0; j<100; j++)//inicializar todas as posições a zero
		{
			for(i = 0;i<intMatriz;i++)
			{
				shuffledStory [j, i] = 0;
			}
		}

		this.images = new List<GameObject> ();


		for (i = 0; i < nrLinhas; i++) 
		{
			var rowGO = Instantiate (row, this.transform); //instancia o espaço para a linha

			for (j = 0; j < nrColunas; j++) 
			{
				var imageGO = Instantiate (image, rowGO.transform); //instancia o espaço para a imagem, na linha
				this.images.Add (imageGO);//insere as linhas e espaços na lista images (linhas e colunas...)
			}
		}

		Shifting ();

		//Debug.Log("MAD MANUEL"+ gameObject.GetInstanceID());
	}

	public void Shifting()
	{
		//flagTrue = 2;
		flagTrue = 1;
		tempo_j = 1;
		flagVerifyIfLast = 1;
		flagBoss = 0;
		var nrResources = Resources.LoadAll<Texture2D>("");
		Resources.UnloadUnusedAssets();

		int intArrayMax = nrResources.Length;//nr de imagens nos resources;
		int[] intArray = new int[intArrayMax];

		int mX = 0, mY = 0;
		/*cria-se aqui um array com dois valores, -1 e 1, que vão servir de base para as duas possibilidades de "mirrorVertical" e "mirrorHorizontal". 
		 	* Com isto possibilitamos várias combinações de mirror.*/
		var myArray = new int[] { -1, 1 };//array 


		do 
		{
			flagTrue = 1;
			tempo_j = 1;
			flagVerifyIfLast = 1;
			flagBoss = 0;


			/****************************************
			 * Criação do array intArray[i] com 
			 * valores aleatórios, consoante o numero 
			 * imagens existentes
			****************************************/
			for (i = 0; i < intArrayMax; i++)
			{
				intArray[i] = i;
			}
			Shuffle(intArray);

			if (intMatriz > intArrayMax)
			{
				intMatriz = intArrayMax;
			}


			//Definição das variáveis mirrorVertical, mirrorHorizontal
			for (i = 0; i < intMatriz; i++) 
			{
				mirrorVertical = myArray[Random.Range(0,myArray.Length)];
				mirrorHorizontal =  myArray[Random.Range(0,myArray.Length)];
				if (mirrorVertical == -1)	mX = 2;
				if (mirrorVertical == 1)	mX = 1;
				if (mirrorHorizontal == -1)	mY = 2;
				if (mirrorHorizontal == 1)	mY = 1;
				shuffled [i] = mX * 1000 + mY * 100 + intArray[i]; // exemplo: shuffled[0] = [1 2 1] mirrorVertical 1, mirrorHorizontal -1, posição 1
			}




			//verifica qual o ultimo elemento já preenchido do array shuffledStory
			for (j = 0; j < 100; j++) 
			{
				for (i = 0; i < intMatriz; i++) 
				{
					if(shuffledStory [j, i] == 0)
					{
						tempo_j = j;
						flagVerifyIfLast = 0;
						break;
					}
				}
				if(flagVerifyIfLast == 0) break;
			}

			//caso ainda não exista nenhum elemento preenchido no array "shuffledstory", é preenchido o primeiro elemento
			if(tempo_j == 0)
			{
				for(i=0;i<intMatriz;i++)
				{
					shuffledStory [tempo_j, i] = shuffled [i];
					//writer = new StreamWriter(path, true);
					//writer.Write(shuffled[i]+ " ");
					//writer.Close();
				}
				//writer = new StreamWriter(path, true);
				//writer.WriteLine();
				//writer.Close();

				flagBoss = 1;
			}
			//caso já exista pelo menos 1 elemento preenchido, compara-se o lançamento "shuffled" com todos os elementos existentes no "shuffledStory" 
			//caso exista pelo menos um "atributo" igual (mirrorHorizontal, mirrorVertical, posição), 
			//então flagTrue = 0 e terá de ser feito outro lançamento
			else
			{
				for (j = 0; j < 100; j++) 
				{
					for(i=0;i<intMatriz;i++)
					{

						if(shuffledStory [j, i] == shuffled [i] && shuffledStory[j,i] != 0)//basta apenas 1 elemento ser igual para obrigar a lançar de novo
						{
							flagTrue = 0;
							break;
						}
					}
					if(flagTrue == 0) break;
				}

				//grava o lançamento aleatório no array shuffledStory na posição posterior ao ultimo elemento, 
				//pois os valores são diferentes de todos os já saidos
				if(flagTrue == 1)
				{
					for(i=0;i<intMatriz;i++)
					{
						shuffledStory [tempo_j, i] = shuffled [i];
						//writer = new StreamWriter(path, true);
						//writer.Write(shuffled[i]+ " ");
						//writer.Close();
					}
					//writer = new StreamWriter(path, true);
					//writer.WriteLine();
					//writer.Close();

					flagBoss = 1;
				}
			}


		} while(flagBoss == 0);





		for (i = 0; i < intMatriz; i++) 
		{

			n = shuffled [i];
			n = n / 100;
			mY = (n % 100);
			n = n / 100;
			mX = (n % 100);

			if (mX == 2) mirrorVertical = -1;
			if (mX == 1) mirrorVertical = 1;
			if (mY == 2) mirrorHorizontal = -1;
			if (mY == 1) mirrorHorizontal = 1;
			//Debug.Log (mirrorVertical + " " +mirrorHorizontal + " " + " " +intArray[i]);

			//Aqui é inserido na lista de images um conjunto de imagens aleatórias, em que também é aleatório o seu Mirror Vertical/Horizontal e Rotação
			//this.images[i].GetComponent<RawImage> ().texture = nrResources [intArray[i]]; //acede-se ao array images
			this.images[i].GetComponent<RawImage> ().texture = nrResources [intArray[i]]; //acede-se ao array images
			this.images[i].GetComponent<RectTransform>().localScale = new Vector3(mirrorVertical, mirrorHorizontal, 0);

		}






	}

	//cria e preenche um array com valores inteiros, com o tamanho indicado pelo utilizador linhasxcolunas
	private void RandomUnique() 
	{
		int intArrayMax = nrLinhas * nrColunas;
		int[] intArray = new int[intArrayMax];

		for (i = 0; i < intArrayMax; i++)
		{
			intArray[i] = i;
		}
		Shuffle(intArray);

		for (i = 0; i < intArrayMax; i++)
		{
			Debug.Log(intArray[i]);
		}

	}

	//metodo utilizado para baralhar um conjunto de numero dentro de um array
	public void Shuffle(int[] obj)
	{
		for (i = 0; i < obj.Length; i++)
		{
			int temp = obj[i];
			int objIndex = Random.Range(0, obj.Length);
			obj[i] = obj[objIndex];
			obj[objIndex] = temp;
		}
	}

	/*public void ClickToChange()
	{
		Shifting ();
	}*/


}
