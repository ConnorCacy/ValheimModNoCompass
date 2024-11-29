using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimCartographyTableMapOnly
{
    [HarmonyPatch(typeof(Minimap), "UpdatePlayerMarker")]
    internal class MinimapUpdatePlayerMarkers
    {
        public static Minimap mapInstance;
        [HarmonyPrefix]
        public static bool UpdatePlayerMarkerPrefix(ref Minimap __instance)
        {
            if (mapInstance == null) mapInstance = __instance;
            __instance.m_smallRoot.SetActive(value: false);
            __instance.m_largeMarker.gameObject.SetActive(value: false);
            __instance.m_smallMarker.gameObject.SetActive(value: false);
            __instance.m_smallShipMarker.gameObject.SetActive(value: false);
            __instance.m_largeShipMarker.gameObject.SetActive(value: false);
            return false;
        }
    }
}
