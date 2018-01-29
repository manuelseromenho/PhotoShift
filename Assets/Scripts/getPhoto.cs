using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class getPhoto : MonoBehaviour 
{

	/*[SerializeField]
	private RawImage m_image;

	public void SetImage()
	{
		List<string> galleryImages = GetAllGalleryImagePaths();
		Texture2D t = new Texture2D(2, 2);
		(new WWW(galleryImages[0])).LoadImageIntoTexture(t);
		m_image.texture = t;
	}

	private List<string> GetAllGalleryImagePaths()
	{
		List<string> results = new List<string>();
		HashSet<string> allowedExtesions = new HashSet<string>() { ".png", ".jpg",  ".jpeg"  };

		try
		{
			AndroidJavaClass mediaClass = new AndroidJavaClass("android.provider.MediaStore$Images$Media");

			// Set the tags for the data we want about each image.  This should really be done by calling; 
			//string dataTag = mediaClass.GetStatic<string>("DATA");
			// but I couldn't get that to work...

			const string dataTag = "_data";

			string[] projection = new string[] { dataTag };
			AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = player.GetStatic<AndroidJavaObject>("currentActivity");

			string[] urisToSearch = new string[] { "EXTERNAL_CONTENT_URI", "INTERNAL_CONTENT_URI" };
			foreach (string uriToSearch in urisToSearch)
			{
				AndroidJavaObject externalUri = mediaClass.GetStatic<AndroidJavaObject>(uriToSearch);
				AndroidJavaObject finder = currentActivity.Call<AndroidJavaObject>("managedQuery", externalUri, projection, null, null, null);
				bool foundOne = finder.Call<bool>("moveToFirst");
				while (foundOne)
				{
					int dataIndex = finder.Call<int>("getColumnIndex", dataTag);
					string data = finder.Call<string>("getString", dataIndex);
					if (allowedExtesions.Contains(Path.GetExtension(data).ToLower()))
					{
						string path = @"file:///" + data;
						results.Add(path);
					}

					foundOne = finder.Call<bool>("moveToNext");
				}
			}
		}
		catch (System.Exception e)
		{
			// do something with error...
		}

		return results;
	}*/

	/// <summary>
	/// based off 2 lines of Java code found at at http://stackoverflow.com/questions/18416122/open-gallery-app-in-androi
	///      Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("content://media/internal/images/media"));
	///      startActivity(intent); 
	/// expanded the 1st line to these 3:
	///      Intent intent = new Intent();
	///      intent.setAction(Intent.ACTION_VIEW);
	///      intent.setData(Uri.parse("content://media/internal/images/media"));
	/// </summary>
	/// 

	public void SetImage()
	{
		#region [ Intent intent = new Intent(); ]
		//instantiate the class Intent
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		//instantiate the object Intent
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		#endregion [ Intent intent = new Intent(); ]
		#region [ intent.setAction(Intent.ACTION_VIEW); ]
		//call setAction setting ACTION_SEND as parameter
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
		#endregion [ intent.setAction(Intent.ACTION_VIEW); ]
		#region [ intent.setData(Uri.parse("content://media/internal/images/media")); ]
		//instantiate the class Uri
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		//instantiate the object Uri with the parse of the url's file
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "content://media/internal/images/media");
		//call putExtra with the uri object of the file
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		#endregion [ intent.setData(Uri.parse("content://media/internal/images/media")); ]
		//set the type of file
		intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
		#region [ startActivity(intent); ]
		//instantiate the class UnityPlayer
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//instantiate the object currentActivity
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		//call the activity with our Intent
		currentActivity.Call("startActivity", intentObject);
		#endregion [ startActivity(intent); ]
	}
	
}


