using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class codeScript : MonoBehaviour {

	public Image imageGO;
	public Image imageGO1;
	public Image imageGO2;
	public Image imageGO3;

	public int i,j;
	public int total;
	//public Text total_;
	public Text imageQuantity;
	public testescript testeScript;

	private SpriteRenderer mySpriteRenderer;





	void Start()
	{
		//Button btn = b;
		//btn.onClick.AddListener(TaskOnClick);
		i=1;
		j = 0;


		//int nrLinhas = 0;
		//int nrColunas = 0;




		/*Texture2D tex = nrResources[0] as Texture2D;
		Sprite newSprite = Sprite.Create (nrResources[0] as Texture2D, new Rect(0,0,tex.width,tex.height), new Vector2(0,0));
		imageGO.sprite = newSprite;*/


		//SetTextureImporterFormat (texi1,true);
		//SetTextureImporterFormat (texi2,true);
		//SetTextureImporterFormat (texi3,true);

		 Object[] nrResources = Resources.LoadAll("");
		//GameObject testImage = Instantiate(Resources.Load("imagem (1)", typeof(GameObject))) as GameObject;
		//Object[] nrResources = Instantiate(Resources.Load("", typeof(GameObject))) as GameObject;
		total = nrResources.Length;

		//total_ = GetComponent<UnityEngine.UI.Text>();
		//total_.text= total.ToString();
		//imageQuantity.text = total.ToString() + " " + nrResources[0].ToString();
		Debug.Log("Image Length= " + total.ToString());

		int nrSprites = 3;

		Texture2D[] texi = new Texture2D[nrSprites];

		//Texture2D texi2 = nrResources[1] as Texture2D;
		//Texture2D texi3 = nrResources[2] as Texture2D;

		int transformacao = 1;


		/*Sprite[] newSprite = new Sprite[nrSprites];

		for (int k = 0; k < nrSprites; k++) 
		{
			texi [k] = nrResources [k] as Texture2D;
			TextureScale.Bilinear (texi[i], texi[i].width/4, texi[i].height/4);
			texi[i].Apply();


			newSprite[k] = Sprite.Create (TransformTexture(texi[k], transformacao) as Texture2D, new Rect(0,0,texi[k].width,texi[k].height), new Vector2(0,0));
		}

		imageGO.sprite = newSprite [0];
		imageGO1.sprite = newSprite [1];
		imageGO2.sprite = newSprite [2];*/


		/*Sprite newSprite1 = Sprite.Create (TranformTexture(texi1, transformacao) as Texture2D, new Rect(0,0,texi1.width,texi1.height), new Vector2(0,0));
		imageGO.sprite = newSprite1;

		Sprite newSprite2 = Sprite.Create (TranformTexture(texi2, transformacao) as Texture2D, new Rect(0,0,texi2.width,texi2.height), new Vector2(0,0));
		imageGO1.sprite = newSprite2;

		Sprite newSprite3 = Sprite.Create (TranformTexture(texi3, transformacao) as Texture2D, new Rect(0,0,texi3.width,texi3.height), new Vector2(0,0));
		imageGO2.sprite = newSprite3;*/





		Resources.UnloadUnusedAssets();
}


	public void ClickToChange()
	{
		//testescript testeScript = FindObjectOfType(typeof(testescript));


		//testescript testeScript = (testescript)this.GetComponent(typeof(testescript));
		testeScript.Shifting ();



		//Sprite[] newSprite = Sprite.Create (TranformTexture(texi, transformacao) as Texture2D, new Rect(0,0,texi[0].width,texi[].height), new Vector2(0,0));



		/*imageGO.sprite = Resources.Load<Sprite> ("imagem ("+i+")");
		j = i+1;
		imageGO1.sprite = Resources.Load<Sprite> ("imagem ("+ j +")");
		j = i+2;
		imageGO2.sprite = Resources.Load<Sprite> ("imagem ("+ j +")");
		i = i + 1;*/	
	}


	//girar textura
	Texture2D TransformTexture(Texture2D original, int transformacao)
	{

		Texture2D imagem = new Texture2D(original.width, original.height);

		int imgHeight = original.height;
		int imgWidth= original.width;

		switch (transformacao) 
		{
			case 0:
				//sem transformação
				break;
			case 1:
				//Mirror Horizontal
				for (int i = 0; i < imgHeight; i++)
				{
					for (int j = 0; j < imgWidth; j++)
					{
						imagem.SetPixel(j, imgHeight - i - 1, original.GetPixel(j, i));
					}
				}
				break;
			case 2:
				//Mirror Vertical
				for (int j = 0; j < imgHeight; j++)
				{
					for (int i = 0; i < imgWidth; i++)
					{
						imagem.SetPixel(imgWidth-i-1, j, original.GetPixel(i, j));
					}
				}
				break;
			case 3:
				//Rotation 180º, para esta rotacao é feito um mirror horizontal e a seguir vertical
				
				for (int i = 0; i < imgHeight; i++)
				{
					for (int j = 0; j < imgWidth; j++)
					{
						imagem.SetPixel(j, imgHeight - i - 1, original.GetPixel(j, i));
					}
				}

				for (int j = 0; j < imgHeight; j++)
				{
					for (int i = 0; i < imgWidth; i++)
					{
						imagem.SetPixel(imgWidth-i-1, j, original.GetPixel(i, j));
					}
				}
				
				break;

			//default:
				//
				//break;
		
		}


		imagem.Apply();

		return imagem;
	}






}
