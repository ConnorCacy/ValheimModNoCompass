using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Minimap;
using UnityEngine;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "CenterMap")]
    internal class MinimapCenterMap
    {
        [HarmonyPrefix]
        public static bool UpdatePrefix(ref Vector3 centerPoint)
        {

            if (LargeMapSetActive.triggerOnActive)
            {
                //override default centering of map
                LargeMapSetActive.triggerOnActive = false;
                centerPoint = new Vector3(311.53f, 41.46f, -39.90f);
            }
            if (MinimapUpdateMap.playerLocation != null)
            {
                if (centerPoint.x == MinimapUpdateMap.playerLocation.x && centerPoint.y == MinimapUpdateMap.playerLocation.y && centerPoint.z == MinimapUpdateMap.playerLocation.z)
                {
                    //override default centering of map (can cheese game if you drag and stop exactly on character, but that is like finding a needle in a haystack)
                    centerPoint = new Vector3(311.53f, 41.46f, -39.90f);
                }
            }
            return true;
        }
    }
}
