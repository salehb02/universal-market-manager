using UnityEditor;
using UMM;

public class UMMEditorWindow : Editor
{
    [MenuItem(MarketSettings.TAB_ADDRESS, priority = 0)]
    public static void OpenMarketSettings()
    {
        Selection.activeObject = MarketSettings.Instance;
    }
}