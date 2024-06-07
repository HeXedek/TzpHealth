using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TzpHealth.Patches;

namespace TzpHealth
{
    [BepInPlugin("HeXedMods.TzpHealth", "TzpHealth", "4.2.0")]
    public class TzpHealth : BaseUnityPlugin
    {
        public static TzpHealth Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        private void Awake()
        {
            TzpHealth.instance = this;
            this._harmony = new Harmony("TzpHealth");
            this._harmony.PatchAll(typeof(TzpHealth));
            this._harmony.PatchAll(typeof(TzpeqHealth));
            base.Logger.LogInfo("Tzp=Health 0.1 Beta loaded");
        }

        public static void Log(string message)
        {
            Logger.LogInfo(message);
        }

        public static TzpHealth instance;

        // Token: 0x04000005 RID: 5
        private Harmony _harmony;
    }
}
