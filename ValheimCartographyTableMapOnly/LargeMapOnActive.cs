using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimCartographyTableMapOnly
{
    [HarmonyPatch(typeof(GameObject), "SetActive")]
    internal class LargeMapOnActive
    {
        public static bool LargeMapCanBeActive = false;
        [HarmonyPrefix]
        public static bool OnSetActivePrefix(GameObject __instance, bool value)
        {
            if (MinimapUpdatePlayerMarkers.mapInstance != null && __instance == MinimapUpdatePlayerMarkers.mapInstance.m_smallRoot)
            {
                return false;
            }
            if (MinimapUpdatePlayerMarkers.mapInstance != null && __instance == MinimapUpdatePlayerMarkers.mapInstance.m_largeRoot) // Check if the GameObject is the one you want to track
            {
                if (LargeMapCanBeActive)
                {
                    LargeMapCanBeActive = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
