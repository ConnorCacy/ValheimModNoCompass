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
    [HarmonyPatch(typeof(Minimap), "UpdateDynamicPins")]
    internal class MinimapPatchUpdateDynamicPins
    {
        //public PinData AddPin(Vector3 pos, PinType type, string name, bool save, bool isChecked, long ownerID = 0L, string author = "")
        [HarmonyPrefix]
        public static bool UpdateDynamicPins()
        {  
            
            return false;
        }
    }
}
