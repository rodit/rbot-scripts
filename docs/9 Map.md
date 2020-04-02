Map
======
Information about the currently loaded map (room) can be obtained through the `ScriptInterface#Map` object.

#### Properties
`string Name` - The name of the map. This does not include the room number.

`int RoomID` - The map's area id. This is required in some packets.

`int PlayerCount` - The number of players in the currently loaded map.

`List<String> PlayerNames` - The list of player names in the currently loaded map.

`List<PlayerInfo> Players` - The list of players in the current map.

`List<PlayerInfo> CellPlayers` - The list of players in the current cell.

`bool Loaded` - Indicates whether a map is currently loaded.

`string[] Cells` - An array of all the cell names in the map.

#### Methods
`void Reload()` - Reloads the current map.

`void GetMapItem(int id)` - Sends a getMapItem packet with the specified id. This is useful for quests that require some sort of map interaction.

`bool PlayerExists(string name)` - Checks if the player with the given name exists in the map.

`PlayerInfo GetPlayer(string name)` - Gets information about the player with the given name. The player must be loaded in the current map.

#### PlayerInfo Objects
These objects have the following properties:

`string Name` - The player's name (username). This is always lower case.

`int HP` - The player's current HP.

`int MaxHP` - The player's maximum HP.

`int MP` - The player's current mana.

`PlayerStats Stats` - The player's stats. Only your player will have any stats loaded. This is also incomplete.

`bool AFK` - Determines whether the player is AFK or not.

`int EntID` - The player's entity ID.

`int Level` - The player's level.

`string Cell` - The player's cell.

`string Pad` - The player's pad.

`float X` - The player's X coordinate.

`float Y` - The player's Y coordinate;

`int State` - The state of the player (0 = dead, 1 = idle, 2 = combat, I think).