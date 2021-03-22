using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Glaucus
{
    [HarmonyPatch(typeof(Vent), nameof(Vent.CanUse))]
    public static class VentPatch
    {
        public static bool Prefix(Vent __instance, ref float __result, [HarmonyArgument(0)] GameData.PlayerInfo pc, [HarmonyArgument(1)] out bool canUse, [HarmonyArgument(2)] out bool couldUse)
        {
            float num = float.MaxValue;
            PlayerControl localPlayer = pc.Object;
            switch (UnknownImpostor.WhoCanVent.GetValue())
            {
                case 0:  // Nobody
                    couldUse = false;
                    break;
                case 1:  // Impostors
                    couldUse = localPlayer.Data.IsImpostor && !localPlayer.Data.IsDead;
                    break;
                case 2:  // Everyone
                    couldUse = !localPlayer.Data.IsDead;
                    break;
                default:
                    couldUse = false;
                    break;
            }
            canUse = couldUse;
            num = Vector2.Distance(localPlayer.GetTruePosition(), __instance.transform.position);
            canUse &= num <= __instance.UsableDistance;
            __result = num;
            return false;
        }
    }
}