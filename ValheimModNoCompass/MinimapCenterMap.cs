using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Minimap;
using UnityEngine;
using System.Reflection;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "CenterMap")]
    internal class MinimapCenterMap
    {
        public static bool inMouseDrag = false;
        [HarmonyPrefix]
        public static bool UpdatePrefix(ref Minimap __instance, ref Vector3 centerPoint)
        {

            FieldInfo dragViewField = AccessTools.Field(typeof(Minimap), "m_dragView");
            bool m_dragView = (bool)dragViewField.GetValue(__instance);
            FieldInfo mapOffsetField = AccessTools.Field(typeof(Minimap), "m_mapOffset");
            Vector3 m_mapOffset = (Vector3)mapOffsetField.GetValue(__instance);

            if (m_dragView)
            {
                inMouseDrag = true;
               
                centerPoint.x = m_mapOffset.x;
                centerPoint.y = m_mapOffset.y;
                centerPoint.z = m_mapOffset.z;
            }
            else
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
                if (inMouseDrag)
                {
                    centerPoint = new Vector3(311.53f, 41.46f, -39.90f);
                    inMouseDrag = false;
                    mapOffsetField.SetValue(__instance, centerPoint);
                }
            }
            return true;
        }
    }
}
