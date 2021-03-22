# UnknownImpostor

An Among Us mod where impostors don't known each other.  
For the moment, only the Steam version (2021.3.5s) of the game is supported.

## Features

- **Impostors don't know each other**.  
  The other Impostors look like any Crewmate and you can kill them.
- **Who can vent**.  
  Allows Crewmates to vent, or can disable vents for everyone.
    - Options : [ `Nobody` | `Impostors` | `Everyone` ]
        - `Nobody`: disable the vents
        - `Impostors`: only Impostors can vent
        - `Everyone`: everyone is able to use the vents

## Extra features

- **Map Selection** and **# Impostors** options are available in Online Lobby

## Installation

Everyone in the lobby need to have the mod installed.  
Follow one of these methods to install it:

- [All included Archive](#all-included-archive): easiest
- [Custom Install](#custom-install): advanced (recommended)

### All included Archive

1. Download the file `UnknownImpostor-vX.X.X.zip` in the [Releases section](https://github.com/Pandraghon/UnknownImpostor/releases).
2. Extract the content of the zip into your game folder (i.e. `Steam\steamapps\common\Among Us`).
3. Run the game

### Custom Install

1. Install Reactor BepInEx by following **[these instructions](https://docs.reactor.gg/docs/basic/install_bepinex/)**.
2. Install Reactor by following **[these instructions](https://docs.reactor.gg/docs/basic/install_reactor)**.
3. Download the file `UnknownImpostor-2021.3.5s.dll` in the [Releases section](https://github.com/Pandraghon/UnknownImpostor/releases).
4. Copy the dll file into `Among Us/BepInEx/plugins`.
5. Repeat steps 3-4 for the file `Essentials-2021.3.5s.dll` from [DorCoMaNdO's repository](https://github.com/DorCoMaNdO/Reactor-Essentials/releases).
6. (Optional) If you want to play on official servers, you must do the following :
- Open **`Among us/BepInEx/config/gg.reactor.api.cfg`** with a text editor.
- Find the line `Modded handshake = true` and change it to `Modded handshake = false`.
- Save and close your editor.

## Using

- https://github.com/NuclearPowered/Reactor
- https://github.com/DorCoMaNdO/Reactor-Essentials
