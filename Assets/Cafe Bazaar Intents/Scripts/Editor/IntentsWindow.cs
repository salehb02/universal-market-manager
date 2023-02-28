using UnityEditor;
using CafeBazaar;

public class IntentsWindow : Editor
{
    [MenuItem("Cafe Bazaar/Intents Setting", false, -10)]
    public static void OpenPublicCustomization()
    {
        Selection.activeObject = CafeIntentsSetting.Instance;
    }
}