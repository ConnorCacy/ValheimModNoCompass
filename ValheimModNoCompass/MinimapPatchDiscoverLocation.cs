﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Minimap;

namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Minimap), "DiscoverLocation")]
    public class MinimapPatchDiscoverLocation
    {
        [HarmonyPrefix]
        public static bool DiscoverLocationPrefix(ref Minimap __instance, ref UnityEngine.Vector3 pos, ref Minimap.PinType type, ref string name, ref bool showMap)
        {
            if (type == Minimap.PinType.Boss)
            {
                Player.m_localPlayer.SetLookDir(pos - Player.m_localPlayer.transform.position, 3.5f);
            }
            return false;
        }
       
    }

}
