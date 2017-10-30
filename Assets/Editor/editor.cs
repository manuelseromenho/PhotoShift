using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class editor : MonoBehaviour {


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
