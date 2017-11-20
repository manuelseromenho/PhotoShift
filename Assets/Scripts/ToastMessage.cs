/*using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
	string toastString;
	string input;
	AndroidJavaObject currentActivity;
	AndroidJavaClass UnityPlayer;
	AndroidJavaObject context;

	void Start()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
		}
	}


	public void showToastOnUiThread(string toastString)
	{
		this.toastString = toastString;
		currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
	}

	void showToast()
	{
		Debug.Log(this + ": Running on UI thread");

		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call("show");
	}
}*/


/*
using UnityEngine;
using System.Collections;

public class ToastMessage : MonoBehaviour {

	string toastString;
	AndroidJavaObject currentActivity;

	public void MyShowToastMethod ()
	{
		if (Application.platform == RuntimePlatform.Android) {
			showToastOnUiThread ("It Worked!");
		}
	}

	public void showToastOnUiThread(string toastString){
		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		this.toastString = toastString;

		currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
	}

	void showToast(){
		Debug.Log ("Running on UI thread");
		AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString=new AndroidJavaObject("java.lang.String",toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call ("show");
	}

}*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToastMessage : MonoBehaviour {

	string toastString;
	string input;
	AndroidJavaObject currentActivity;
	AndroidJavaClass UnityPlayer;
	AndroidJavaObject context;

	void Start(){
		if(Application.platform == RuntimePlatform.Android){
			UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
			context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
		}
	}

	public void ToAndroidClipBoard(InputField txtField){
		if (Application.platform == RuntimePlatform.Android) {
			input = txtField.text;
			currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (toClipBoardOnUiThread));
		}
	}

	void toClipBoardOnUiThread(){
		Debug.Log (this+": Running on UI thread");

		AndroidJavaClass Context = new AndroidJavaClass("android.content.Context");
		AndroidJavaObject CLIPBOARD_SERVICE = Context.GetStatic<AndroidJavaObject> ("CLIPBOARD_SERVICE");
		AndroidJavaObject clipboardMgr = currentActivity.Call<AndroidJavaObject> ("getSystemService",CLIPBOARD_SERVICE);
		AndroidJavaClass ClipData = new AndroidJavaClass ("android.content.ClipData");
		AndroidJavaObject clipData = ClipData.CallStatic<AndroidJavaObject> ("newPlainText","deltaBit",input);
		clipboardMgr.Call ("setPrimaryClip", clipData);

		showToastOnUiThread ("Copied to clipboard: " + input);
	}

	public void showToastOnUiThread(string toastString){		
		this.toastString = toastString;
		currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
	}

	void showToast(){		
		Debug.Log (this+": Running on UI thread");

		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString=new AndroidJavaObject("java.lang.String",toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call ("show");
	}

}
