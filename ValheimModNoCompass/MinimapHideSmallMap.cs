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
    [HarmonyPatch(typeof(Minimap), "Update")]
    internal class MinimapHideSmallMap
    {
        [HarmonyPrefix]
        public static bool UpdatePrefix(ref Minimap __instance)
        {
            //__instance.m_publicPosition.togg
            __instance.m_publicPosition.isOn = false;
            __instance.m_smallRoot.SetActive(value: false);
            //if (type == PinType.Player || type == PinType.Shout) return false;

            return true;
        }
        //public PinData AddPin(Vector3 pos, PinType type, string name, bool save, bool isChecked, long ownerID = 0L, string author = "")
        [HarmonyPostfix]
        public static void UpdatePostfix(ref Minimap __instance)
        {
            __instance.m_publicPosition.isOn = false;
            __instance.m_smallRoot.SetActive(value: false);
            
        }
    }
}
