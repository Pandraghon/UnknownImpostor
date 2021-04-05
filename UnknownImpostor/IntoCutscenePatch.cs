using HarmonyLib;

namespace Glaucus
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__11), nameof(IntroCutscene._CoBegin_d__11.MoveNext))]
    class IntroCutscenePath
    {
        static bool Prefix(IntroCutscene._CoBegin_d__11 __instance)
        {
            if (PlayerControl.LocalPlayer.Data.IsImpostor && !UnknownImpostor.ImpostorsKnowEachother.GetValue())
            {
                var team = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
                team.Add(PlayerControl.LocalPlayer);
                __instance.yourTeam = team;
            }
            return true;
        }
    }
}