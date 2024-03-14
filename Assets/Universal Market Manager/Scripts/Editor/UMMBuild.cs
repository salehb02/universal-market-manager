using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UMM;
namespace UMM
{
    public class UMMBuild : IPreprocessBuildWithReport
    {
        public const string BUILDALL_ADDRESS = "UMM/Build for Myket and Bazaar";

        public int callbackOrder => 0;

        [MenuItem(BUILDALL_ADDRESS)]
        public static void BuildForMyketAndBazaar()
        {
            string baseBuildPath = EditorUtility.OpenFolderPanel("Choose Base Build Path", "", "");

            if (string.IsNullOrEmpty(baseBuildPath))
            {
                Debug.Log("Build path not selected.");
                return;
            }
            ChangeScriptingBackendToIl2CP();
            string[] markets = new string[] { "UMM_MYKET", "UMM_BAZAAR" };

            string[] scenes = GetBuildScenes();
            int bundleV = PlayerSettings.Android.bundleVersionCode;
            int[] bundleVersions = new int[]
                {
                     bundleV+1, bundleV
                };

            for (int m = 0; m < markets.Length; m++)
            {
                string market = markets[m];

                MarketSettings marketSettings = MarketSettings.Instance;

                if (market == "UMM_MYKET")
                { 
                    marketSettings.ActivateMyket();
                }
                else if (market == "UMM_BAZAAR")
                {
                    marketSettings.ActivateCafeBazaar();
                }
                string marketFolderPath = Path.Combine(baseBuildPath, market);

                if (!Directory.Exists(marketFolderPath))
                {
                    Directory.CreateDirectory(marketFolderPath);
                }


                string[] architectures = new string[]
                {
                "arm64-v8a",
                "armeabi-v7a"
                };

                for (int i = 0; i < architectures.Length; i++)
                {
                    string architecture = architectures[i];
                    int bundle = bundleVersions[i];
                    PlayerSettings.Android.bundleVersionCode = bundle;
                    string path = Path.Combine(marketFolderPath, $"{PlayerSettings.productName}-{architecture}.apk");
                    PlayerSettings.Android.targetArchitectures = architecture switch
                    {
                        "armeabi-v7a" => AndroidArchitecture.ARMv7,
                        "arm64-v8a" => AndroidArchitecture.ARM64,
                        _ => AndroidArchitecture.ARMv7
                    };
                    BuildPipeline.BuildPlayer(scenes, path, BuildTarget.Android, BuildOptions.None);

                    Debug.Log("Built for " + market + " - " + architecture + " architecture at " + path);
                }
            }
            // reset targetArchitecture
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;

        }

        internal static void ChangeScriptingBackendToIl2CP()
        {
            if (!PlayerSettings.GetScriptingBackend(BuildTargetGroup.Android).Equals(ScriptingImplementation.IL2CPP))
            {
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
                Debug.Log("Scripting backend changed to IL2CPP.");
            }
        }
        internal static string[] GetBuildScenes()
        {
             return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
        }
        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android)
            {
                Debug.LogError("This script only supports Android builds.");
                throw new System.Exception("This script only supports Android builds.");
            }
        }
    }
}