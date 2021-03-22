using HarmonyLib;
using InnerNet;
using UnityEngine;
using static Glaucus.UnknownImpostor;

namespace Glaucus
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    class HudUpdateManager
    {
        static void Postfix(HudManager __instance)
        {
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {
                PlayerTools.closestPlayer = PlayerTools.getClosestPlayer(PlayerControl.LocalPlayer);
                double distLocalClosest = PlayerTools.getDistBetweenPlayers(PlayerControl.LocalPlayer, PlayerTools.closestPlayer);

                if (!ImpostorsKnowEachother.GetValue() && PlayerControl.LocalPlayer.Data.IsImpostor)
                {
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                        if (player.Data.IsImpostor && PlayerControl.LocalPlayer.PlayerId != player.PlayerId)
                            player.nameText.Color = Color.white;
                    if (distLocalClosest < GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance])
                    {
                        __instance.KillButton.SetTarget(PlayerTools.closestPlayer);
                    }
                    if (MeetingHud.Instance != null)
                        foreach (PlayerVoteArea playerArea in MeetingHud.Instance.playerStates)
                        {
                            if (playerArea.NameText == null) continue;
                            PlayerControl player = PlayerTools.getPlayerById((byte)playerArea.TargetPlayerId);
                            if (player.Data.IsImpostor && PlayerControl.LocalPlayer.PlayerId != player.PlayerId)
                                playerArea.NameText.Color = Color.white;
                        }
                }
            }
        }
    }
}