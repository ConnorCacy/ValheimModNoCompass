using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "SetMapMode")]
    public class MinimapPatchSetMapMode
    {
        [HarmonyAfter]
        public static void SetMapModePrefix(ref Minimap __instance)
        {
            //
            ModNoCompass.StaticLogger.LogInfo("Set Map mode after run change mini map to 'none'");
            __instance.m_smallRoot.SetActive(value: false);
        }
      
    }
}
