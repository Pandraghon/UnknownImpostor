using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using Essentials.Options;
using HarmonyLib;
using Reactor;
using Reactor.Patches;
using UnityEngine;
using Random = System.Random;

namespace Glaucus
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class UnknownImpostor : BasePlugin
    {
        public const string Id = "glaucus.pocus.UnknownImpostor";

        //Credit to https://github.com/DorCoMaNdO/Reactor-Essentials
        public static CustomStringOption WhoCanVent = CustomOption.AddString("Who Can Vent", 
            new string[] { "Nobody", "Impostors", "Everyone" });
        public static CustomToggleOption ImpostorsKnowEachother = CustomOption.AddToggle("Impostors Know Eachother", true);
        public Harmony Harmony { get; } = new Harmony(Id);
        
        public override void Load()
        {
            CustomOption.ShamelessPlug = false;

            ReactorVersionShower.TextUpdated += (text) =>
            {
                int index = text.Text.LastIndexOf('\n');
                text.Text = text.Text.Insert(index == -1 ? text.Text.Length - 1 : index, 
                    "\n[FF5555FF]" + typeof(UnknownImpostor).Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description + " " + typeof(UnknownImpostor).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion + "[] by Pandraghon");
            };
            
            Harmony.PatchAll();
        }
    }
}