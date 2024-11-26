using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "UpdatePlayerMarker")]
    internal class MinimapCentermapfix
    {
        //public PinData AddPin(Vector3 pos, PinType type, string name, bool save, bool isChecked, long ownerID = 0L, string author = "")
        [HarmonyPrefix]
        public static bool UpdatePlayerMarkerPrefix(ref Minimap __instance)
        {
            __instance.m_largeMarker.gameObject.SetActive(value: false);
            __instance.m_smallMarker.gameObject.SetActive(value: false);
            __instance.m_smallShipMarker.gameObject.SetActive(value: false);
            __instance.m_largeShipMarker.gameObject.SetActive(value: false);
            return false;
        }
    }
}
