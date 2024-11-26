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
        //= new Harmony("connorcacy.valheim.nocompass");
        public static ManualLogSource StaticLogger;
        public void Awake()
        {
            Harmony.DEBUG = true;
            StaticLogger = Logger;
            Logger.LogInfo("Awake method called in no compass mod. Initializing mod...");
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "connorcacy.valheim.nocompass");
            //_harmony.PatchAll();
        

        }
      
    }
}
