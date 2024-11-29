using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValheimCartographyTableMapOnly
{
    [BepInPlugin("connorcacy.valheim.modcarttablemaponly", "Valheim Mod - no maps except on cartography table read", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class ModCartTableMapOnly : BaseUnityPlugin
    {
        private Harmony _harmony;
        public static ManualLogSource StaticLogger;
        public void Awake()
        {
            StaticLogger = Logger;
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "connorcacy.valheim.modcarttablemaponly");
        }

    }
}
