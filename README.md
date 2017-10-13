# SHHPatcher
Features:
- Remove film grain effects
- Replace button icons ( XBox / Playstation )

Usage

Put the exe file where ever you want.
When a patch process is started the patcher will ask you to open the GLOBAL.PAK from the PAK folder of the game.

Backups

The patcher will create backups for every file it changes and provides the function to restore the game to it's original state with these backups.

Backup Conflict

The button icon patch and film grain patch can be applied indepently.
However if you apply both patches there is one file that needs to be changed by both ( GLOBAL.PAK ).
It contains the button icons and the film grain texture for the loading screens.
This isn't a big problem but it leads to a backup conflict where you could end up with a changed file when restoring the backups incorrectly.
But don't worry the patcher will take care of that for you.
It will store some information in the registry to keep track of the applied patches and remind you to remove them in the correct order. ( see section "registry" below )

Registry

In order to keep track of the changes done to your game files the patcher will create some entries in the registry.
Of course this only works until either you delete those entries or reinstall windows.
The entries can be found under "HKEY_CURRENT_USER\Software\VB and VBA Program Settings\SHHPatcher\3.0".

Changelog

v3
- button patcher implemented
- backup solution improved
- released
v2
- film grain patcher improved
- backup solution implemented
v1
- film grain patcher created
