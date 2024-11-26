using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(GameObject), "SetActive")]
    public class LargeMapSetActive  
    {
        public static bool triggerOnActive = false;
        [HarmonyPrefix]
        public static void Prefix(GameObject __instance, bool value)
        {
            if (MinimapUpdatePlayerMarkers.mapInstance != null && __instance == MinimapUpdatePlayerMarkers.mapInstance.m_largeRoot) // Check if the GameObject is the one you want to track
            {
                if (value)
                {
                    triggerOnActive = true;
                    // The object is being set active
                }
                else
                {
                    triggerOnActive = false;

                    // The object is being set inactive
                }
            }
        }

    }
}
