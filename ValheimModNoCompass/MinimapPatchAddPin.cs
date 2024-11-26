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
    [HarmonyPatch(typeof(Minimap), "AddPin")]
    internal class MinimapPatchAddPin
    {
        //public PinData AddPin(Vector3 pos, PinType type, string name, bool save, bool isChecked, long ownerID = 0L, string author = "")
        [HarmonyPrefix]
        public static bool AddPinPrefix(ref Minimap __instance, ref Vector3 pos, ref PinType type, ref string name, ref bool save, ref bool isChecked, ref long ownerID, ref string author)
        {
            if (__instance.m_smallRoot.activeSelf)
            {
                __instance.m_smallRoot.SetActive(value: false);
            }
            //
            //if (type == PinType.Player || type == PinType.Shout) return false;
            if (type == PinType.Icon0 || type == PinType.Icon1 || type == PinType.Icon2 || type == PinType.Icon3 || type == PinType.Icon4) return true;
            return false;
        }
    }
}
