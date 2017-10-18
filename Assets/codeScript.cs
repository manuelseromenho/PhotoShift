using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeScript : MonoBehaviour {

	public Image imageGO;
	public Image imageGO1;
	public Image imageGO2;
	public int i,j;
	public int total;
	//public Text total_;
	public Text imageQuantity;


	void Start()
	{
		//Button btn = b;
		//btn.onClick.AddListener(TaskOnClick);
		i=1;
		j = 0;

		Object[] nrResources = Resources.LoadAll("");
		total = nrResources.Length;
		//total_ = GetComponent<UnityEngine.UI.Text>();
		//total_.text= total.ToString();
		imageQuantity.text = total.ToString();
		Debug.Log("Image Length= " + total.ToString());

		imageGO.sprite = Resources.Load<Sprite> (nrResources[0].ToString());


		//imageGO.sprite = nrResources [0];
		Debug.Log("nrResources: " + nrResources[0] );


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




}
