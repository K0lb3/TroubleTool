# TroubleTool

A toolkit for creating and installing mods for [TROUBLESHOOTER: Abandoned Children](https://store.steampowered.com/app/470310/TROUBLESHOOTER_Abandoned_Children/).

[**Download**](https://github.com/K0lb3/TroubleTool/releases)

## Installing Mods

1. start tool
2. Open Game Folder
3. create a folder called Mods in the game folder (e.g. ``/Troubleshooter/Mods``)
4. copy the mods as zip into the Mods folder (don't unzip them)
5. set ``Use Mods`` to ``Yes``
6. Apply Settings

## Uninstalling Mods

1. start the tool
2. Uninstall Mods


## Creating Mods

1. start the tool
2. Extract Pack to Data
3. set ``Game Data Source`` to Data
4. Apply Settings
5. edit the files within ``Troubleshooter/Data`` according to your needs
6. copy your edited files into a new folder while keeping the original path structure (e.g. Data\xml\Options.xml -> MyMod\xml\Options.xml)
7. zip your mod, so that the structure within the mod is identical to the original path structure (same as before)
8. rename your zip so that it reflects your mod
9. that's it, now you can share your mod with other users

## TODO
- improve logging
- mod selection and ordering
- improve Troubleshooter path finding