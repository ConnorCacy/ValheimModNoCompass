using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;

namespace ValheimModNoCompass
{
    [BepInPlugin("connorcacy.valheim.nocompass", "Valheim Mod for no compass and markers", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class ModNoCompass : BaseUnityPlugin
    {
        private Harmony _harmony; 
        public static ManualLogSource StaticLogger;
        public void Awake()
        {
            StaticLogger = Logger;
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "connorcacy.valheim.nocompass");
        }
      
    }
}
