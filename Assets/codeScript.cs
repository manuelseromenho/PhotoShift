using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class codeScript : MonoBehaviour {

	public Image imageGO;
	public Image imageGO1;
	public Image imageGO2;
	public int i,j;
	public int total;
	//public Text total_;
	public Text imageQuantity;

	private SpriteRenderer mySpriteRenderer;


	void Start()
	{
		//Button btn = b;
		//btn.onClick.AddListener(TaskOnClick);
		i=1;
		j = 0;

		int transformacao = 1;


		Object[] nrResources = Resources.LoadAll("");
		//GameObject testImage = Instantiate(Resources.Load("imagem (1)", typeof(GameObject))) as GameObject;

		/*
		 * //Criar GameObject em RunTime
		GameObject testImage = new GameObject ();
		testImage.AddComponent<SpriteRenderer>();
		SpriteRenderer rend = (SpriteRenderer)testImage.GetComponent("SpriteRenderer");
		rend.sprite = Resources.Load<Sprite> ("imagem (1)");
		//testImage.transform.Rotate(0,20,0);
		rend.flipX = true;
		imageGO1.sprite = rend.sprite;
		*/

		//Object[] nrResources = Instantiate(Resources.Load("", typeof(GameObject))) as GameObject;
		total = nrResources.Length;

		/*Object[,] resourcesTransformed;

		for (k = 0; k < total; k++) 
		{
			resourcesTransformed [k, 1] = nrResources [k];
		}*/


		//mySpriteRenderer


		//total_ = GetComponent<UnityEngine.UI.Text>();
		//total_.text= total.ToString();
		imageQuantity.text = total.ToString() + " " + nrResources[0].ToString();
		Debug.Log("Image Length= " + total.ToString());

		/*Texture2D tex = nrResources[0] as Texture2D;
		Sprite newSprite = Sprite.Create (nrResources[0] as Texture2D, new Rect(0,0,tex.width,tex.height), new Vector2(0,0));
		imageGO.sprite = newSprite;*/

		Texture2D texi = nrResources[1] as Texture2D;
		SetTextureImporterFormat (texi,true);

		Sprite newSprite2 = Sprite.Create (TranformTexture(texi, transformacao) as Texture2D, new Rect(0,0,texi.width,texi.height), new Vector2(0,0));
		imageGO1.sprite = newSprite2;




		/*for (k = 0; k < total; k++) 
		{
			resourcesTransformed[k,0] = nrResources[k];
		}
*/

		//imageGO.sprite = nrResources [0];


		//Texture2D textura = Resources.Load("imagem (1)", typeof(Texture2D)) as Texture2D;
		//Sprite newSprite = Sprite.Create (nrResources[0], new Rect(0,0,1247,2048), new Vector2(0,0));
		//imageGO.sprite = newSprite;



		Resources.UnloadUnusedAssets();

	}
	/*void OnGUI () 
	{

		total_ = GUI.TextField (new Rect (250, 93, 250, 25), total_, 40);

	}*/

	// Update is called once per frame
	void Update () {

	}

	public void ClickToChange()
	{

		imageGO.sprite = Resources.Load<Sprite> ("imagem ("+i+")");
		j = i+1;
		imageGO1.sprite = Resources.Load<Sprite> ("imagem ("+ j +")");
		j = i+2;
		imageGO2.sprite = Resources.Load<Sprite> ("imagem ("+ j +")");
		i = i + 1;		
	}

	//girar textura
	Texture2D TranformTexture(Texture2D original, int transformacao)
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
				//Rotation 180º
				break;

			//default:
				//
				//break;
		
		}


		/*for (int i = 0; i < imgHeight; i++)
		{
			for (int j = 0; j < imgWidth; j++)
			{
				//caso esteja invertida 
				if (upSideDown)
				{
					flipped.SetPixel(j, imgHeight - i - 1, original.GetPixel(j, i));
				}
				else
				{
					flipped.SetPixel(imgWidth - i - 1, j, original.GetPixel(i, j));
				}
			}
		}*/

		/*for (int j = 0; j < yN; j++)
		{
			for (int i = 0; i < xN; i++)
			{
				flipped.SetPixel(j, yN - i - 1, original.GetPixel(j, i));

			}
		}*/

		//flipped.SetPixel(j, yN - i - 1, original.GetPixel(j, i));








		imagem.Apply();

		return imagem;
	}

	//converter imagem em textura para posteriormente ser transformada
	public static void SetTextureImporterFormat( Texture2D texture, bool isReadable)
	{
		if ( null == texture ) return;

		string assetPath = AssetDatabase.GetAssetPath( texture );
		var tImporter = AssetImporter.GetAtPath( assetPath ) as TextureImporter;
		if ( tImporter != null )
		{
			tImporter.textureType = TextureImporterType.Default;

			tImporter.isReadable = isReadable;

			AssetDatabase.ImportAsset( assetPath );
			AssetDatabase.Refresh();
		}
	}



}
