using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "UpdateMap")]
    internal class MinimapUpdateMap
    {
        public static Vector3 playerLocation;
        [HarmonyPrefix]
        public static void Prefix(Minimap __instance, Player player, ref Vector3 ___m_mapOffset)
        {
            playerLocation = player.transform.position;
        }
    }
}
