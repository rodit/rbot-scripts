Monsters
======
Information about monsters in the current map and cell can be obtained through `ScriptInterface#Monsters`. This is useful for testing if monsters exist or exist with specific conditions about their health or other properties.

#### Properties
The class has the following properties. The proprties are outlined in this format: `Type PropertyName`.

`List<Monster> CurrentMonsters` - A list of monsters in the current cell. This includes monsters that are dead.

`List<Monster> MapMonsters` - A list of monsters in the current map.

`List<string> HuntCellBlacklist` - A list of cells that are ignored when hunting for monsters. This is typically unneeded.

#### Methods
The class has the following methods:

`bool Exists(string name)` - Checks if a monster with the specified name exists (and is alive) in the current cell.

`Dictionary<string, List<Monster>> GetCellMonsters()` - Gets a dictionary mapping cell names to the monsters in that cell.

`List<Monster> GetMonstersByCell(string cell)` - Gets a list of monsters in the given cell.

`List<string> GetMonsterCells(string name)` - Gets a list of cells that contain a monster with the given name.

`List<string> GetLivingMonsterCells(string name)` - Gets a list of cells that contain a living monster with the given name.

#### The Monster Class
Many of the above properties return lists containing instances of `Monster`. This class has the following properties:

`string Name` - The name of the monster.

`int ID` - The unique id of the monster.

`string Race` - The race of the monster. I don't quite know how useful this is if at all.

`string Cell` - The name of the cell that contains this monster.

`int MapID` - The map id of the monster. This can be used to target specific monsters in a room when multiple monsters with the same name exist.

`int HP` - The health of the monster.

`int State` - The state of the monster. When `State > 0`, the monster is alive, otherwise it is dead.

Later, when attacking monsters is explained, it will be made clear how to query monster lists and target monsters using these properties.