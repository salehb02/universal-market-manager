using UnityEngine;

namespace CafeBazaar
{
	public static class CafeIntents
	{
		public static void OpenAppInBazaar()
		{
			var packageName = CafeIntentsSetting.Instance.PackageName;

			if (packageName == null)
				throw new System.NullReferenceException("Package Name is empty. Fill it's field in 'Cafe Bazaar -> Intents Setting'.");

			var intentClass = new AndroidJavaClass("android.content.Intent");
			var intentObject = new AndroidJavaObject("android.content.Intent");
			var uriClass = new AndroidJavaClass("android.net.Uri");

			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
			intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + packageName));
			intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");

			var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);
		}

		public static void OpenComments()
		{
			var packageName = CafeIntentsSetting.Instance.PackageName;

			if (packageName == null)
				throw new System.NullReferenceException("Package Name is empty. Fill it's field in 'Cafe Bazaar -> Intents Setting'.");

			var intentClass = new AndroidJavaClass("android.content.Intent");
			var intentObject = new AndroidJavaObject("android.content.Intent");
			var uriClass = new AndroidJavaClass("android.net.Uri");

			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_EDIT"));
			intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + packageName));
			intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");

			var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);

		}

		public static void OpenDeveloperApps()
		{
			var developerId = CafeIntentsSetting.Instance.DeveloperID;

			if (developerId == null)
				throw new System.NullReferenceException("Developer ID is empty. Fill it's field in 'Cafe Bazaar -> Intents Setting'.");

			var intentClass = new AndroidJavaClass("android.content.Intent");
			var intentObject = new AndroidJavaObject("android.content.Intent");
			var uriClass = new AndroidJavaClass("android.net.Uri");

			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
			intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://collection?slug=by_author&aid=" + developerId));
			intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");

			var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);
		}

		public static void OpenBazaarLogin()
		{
			var intentClass = new AndroidJavaClass("android.content.Intent");
			var intentObject = new AndroidJavaObject("android.content.Intent");
			var uriClass = new AndroidJavaClass("android.net.Uri");

			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
			intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://login"));
			intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");

			var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);
		}
	}
}