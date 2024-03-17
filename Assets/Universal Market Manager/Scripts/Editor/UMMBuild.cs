using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UMM
{
    public class UMMBuild : IPreprocessBuildWithReport
    {
        private const string BUILDALL_ADDRESS = "UMM/Build!";

        public int callbackOrder => 0;

        [MenuItem(BUILDALL_ADDRESS, priority = 1)]
        public static void BuildForMyketAndBazaar()
        {
            var baseBuildPath = EditorUtility.OpenFolderPanel("Choose build path", "", "");

            if (string.IsNullOrEmpty(baseBuildPath))
                throw new System.NullReferenceException("Build path is not selected.");

            ChangeScriptingBackendToIl2CP();

            var markets = new string[] { "UMM_MYKET", "UMM_BAZAAR" };
            var scenes = GetBuildScenes();

            for (int i = 0; i < markets.Length; i++)
            {
                string market = markets[i];

                var marketSettings = MarketSettings.Instance;

                var marketName = string.Empty;

                if (market == markets[0])
                {
                    marketName = "Myket";
                    marketSettings.ActivateMyket();
                }
                else if (market == markets[1])
                {
                    marketName = "Bazaar";
                    marketSettings.ActivateCafeBazaar();
                }

                var marketFolderPath = Path.Combine(baseBuildPath, marketName);

                if (!Directory.Exists(marketFolderPath))
                    Directory.CreateDirectory(marketFolderPath);

                BuildPipeline.BuildPlayer(scenes, marketFolderPath, BuildTarget.Android, BuildOptions.None);
            }
        }

        internal static void ChangeScriptingBackendToIl2CP()
        {
            if (PlayerSettings.GetScriptingBackend(BuildTargetGroup.Android).Equals(ScriptingImplementation.IL2CPP))
                return;

            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            Debug.Log("Scripting backend changed to IL2CPP.");
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
            if (report.summary.platform == BuildTarget.Android)
                return;
            
            throw new System.Exception("This script only supports Android builds.");
        }
    }
}