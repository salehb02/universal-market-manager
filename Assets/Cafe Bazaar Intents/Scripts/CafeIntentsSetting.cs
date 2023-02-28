using UnityEngine;


namespace CafeBazaar
{
    [CreateAssetMenu(menuName = "Cafe Bazaar/Intents Setting")]
    public class CafeIntentsSetting : ScriptableObject
    {
        public string PackageName;
        public string DeveloperID;

        #region Singleton
        private static CafeIntentsSetting instance;
        public static CafeIntentsSetting Instance { get => instance == null ? instance = Resources.Load<CafeIntentsSetting>("Cafe Intents Setting") : instance; }
        #endregion
    }
}