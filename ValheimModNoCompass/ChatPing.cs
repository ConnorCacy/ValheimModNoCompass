using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace ValheimModNoCompass
{
    [HarmonyPatch(typeof(Chat), "SendPing")]
    public class ChatPing
    {
        
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }

    }
}