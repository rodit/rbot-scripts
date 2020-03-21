Map
======
Information about the currently loaded map (room) can be obtained through the `ScriptInterface#Map` object.

#### Properties
`string Name` - The name of the map. This does not include the room number.

`int RoomID` - The map's area id. This is required in some packets.

`int PlayerCount` - The number of players in the currently loaded map.

`List<String> Players` - The list of player names in the currently loaded map.

`bool Loaded` - Indicates whether a map is currently loaded.

`string[] Cells` - An array of all the cell names in the map.

#### Methods
`void Reload()` - Reloads the current map.

`void GetMapItem(int id)` - Sends a getMapItem packet with the specified id. This is useful for quests that require some sort of map interaction.

`bool PlayerExists(string name)` - Checks if the player with the given name exists in the map.