using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Minimap;

namespace ValheimModNoCompass
{
    internal class MinimapPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Minimap), "DiscoverLocation")]
        public static bool DiscoverLocationPrefix(ref UnityEngine.Vector3 pos, ref Minimap.PinType type, ref string name, ref bool showMap)
        {
            //orient the player to the location
            if (type == Minimap.PinType.Boss)
            {
                Player.m_localPlayer.SetLookDir(pos - Player.m_localPlayer.transform.position, 3.5f);
            }
            //dont do anything else
            return false;

            //ref Minimap __instance
            //var currentPins = __instance.m_playerPins; // Example property
        }
        //[HarmonyAfter]
        //[HarmonyPatch(typeof(Minimap), "SetMapMode")]
        //public static bool SetMapModePrefix(ref Minimap __instance)
        //{
        //    __instance.m_smallRoot.SetActive(value: false);
        //        ModNoCompass.StaticLogger.LogInfo("Set Map mode after run change mini map to 'none'");
        //    return true;
        //}
    }
}
