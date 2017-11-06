using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testescript : MonoBehaviour {

	public GameObject prefab;
	public GameObject row;
	public Texture2D texture;

	int nrLinhas = 2;
	int nrColunas = 3;

	private List<GameObject> images;
	// Use this for initialization
	void Start () {
		
		this.images = new List<GameObject> ();
		for (int i = 0; i < nrLinhas; i++) 
		{
			var rowGO = Instantiate (row, this.transform);
			for (int j = 0; j < nrColunas; j++) 
			{
				var child = Instantiate (prefab, rowGO.transform);
				child.GetComponent<RectTransform> ().localScale = new Vector3 (-1, 1, 1);
				this.images.Add (child);
			}
		}

		var nrResources = Resources.LoadAll<Texture2D>("");
		for (int i = 0; i < nrResources.Length; i++) {
			this.images [i].GetComponent<RawImage> ().texture = nrResources [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
