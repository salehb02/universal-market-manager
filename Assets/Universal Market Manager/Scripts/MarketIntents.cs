using UnityEngine;

namespace UMM
{
    public static class MarketIntents
    {
        public static void OpenAppDetails()
        {
#if UNITY_ANDROID
            var packageName = Application.identifier;

            var intentClass = new AndroidJavaClass("android.content.Intent");
            var intentObject = new AndroidJavaObject("android.content.Intent");
            var uriClass = new AndroidJavaClass("android.net.Uri");

            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
#if UMM_MYKET
			intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "myket://details?id=" + packageName));
			intentObject.Call<AndroidJavaObject>("setPackage", "ir.mservices.market");
#elif UMM_BAZAAR
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + packageName));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
#endif

            var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
#endif
        }

        public static void OpenRating()
        {
#if UNITY_ANDROID
            var packageName = Application.identifier;

            var intentClass = new AndroidJavaClass("android.content.Intent");
            var intentObject = new AndroidJavaObject("android.content.Intent");
            var uriClass = new AndroidJavaClass("android.net.Uri");

#if UMM_MYKET
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "myket://comment?id=" + packageName));
            intentObject.Call<AndroidJavaObject>("setPackage", "ir.mservices.market");
#elif UMM_BAZAAR
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_EDIT"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + packageName));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
#endif
            var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
#endif
        }

        public static void OpenDeveloperApps()
        {
#if UNITY_ANDROID
            var packageName = Application.identifier;
            var developerId = MarketSettings.Instance.GetBazaarDeveloperId;

            var intentClass = new AndroidJavaClass("android.content.Intent");
            var intentObject = new AndroidJavaObject("android.content.Intent");
            var uriClass = new AndroidJavaClass("android.net.Uri");

#if UMM_MYKET
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "myket://developer/" + packageName));
            intentObject.Call<AndroidJavaObject>("setPackage", "ir.mservices.market");
#elif UMM_BAZAAR
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://collection?slug=by_author&aid=" + developerId));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
#endif

            var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
#endif
        }

        public static void OpenMarketLogin()
        {
#if UNITY_ANDROID

            var intentClass = new AndroidJavaClass("android.content.Intent");
            var intentObject = new AndroidJavaObject("android.content.Intent");
            var uriClass = new AndroidJavaClass("android.net.Uri");
#if UMM_MYKET
            
#elif UMM_BAZAAR
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://login"));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
#endif

            var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
#endif
        }
    }
}