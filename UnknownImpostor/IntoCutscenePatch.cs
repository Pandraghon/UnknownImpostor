using HarmonyLib;

namespace Glaucus
{
    [HarmonyPatch(typeof(IntroCutscene.CoBegin__d), nameof(IntroCutscene.CoBegin__d.MoveNext))]
    class IntroCutscenePath
    {
        static bool Prefix(IntroCutscene.CoBegin__d __instance)
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