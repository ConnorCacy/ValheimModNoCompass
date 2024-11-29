using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimCartographyTableMapOnly
{
    [HarmonyPatch(typeof(MapTable), "OnRead")]
    internal class MapTableUpdate
    {

        [HarmonyPostfix]
        public static void OnReadPostFix(ref Minimap __instance)
        {
            if (MinimapUpdatePlayerMarkers.mapInstance == null) return;
            LargeMapOnActive.LargeMapCanBeActive = true;
            __instance.m_largeMarker.gameObject.SetActive(value: true);
            MinimapUpdatePlayerMarkers.mapInstance.m_largeMarker.gameObject.SetActive(value: true);
        }
    }
}
