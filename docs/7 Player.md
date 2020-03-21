Player
======
Most of the bot's functionality is called through `ScriptInterface#Player`. There are many methods for movement, combat and properties that can be examined.

#### Properties
`string Cell` - The name of the cell the player is currently in.

`string Pad` - The name of the pad that the player spawned from.

`string ServerName` - The name of the server that the player is currently connected to.

`bool Playing` - Indicates whether the player is both logged in and alive.

`bool LoggedIn` - Indicates whether the player is logged in.

`string Username` - The username of the player.

`string Password` - The password of the player.

`bool Kicked` - Indicates whether the player has been kicked (disconnected) and is currently at the login screen with the red countdown text.

`int State` - The state of the player. `0` is dead, `1` is idle, and `2` is in combat (I think).

`bool InCombat` - Indicates whether the player is in combat.

`bool IsMember` - Indicates whether the player has an active membership.

`bool Alive` - Indicates whether the player is alive.

`int Health` - The player's current health.

`int MaxHealth` - The player's maximum health.

`int Mana` - The player's current mana.

`int MaxMana` - The player's maximum mana.

`int Level` - The player's level.

`int Gold` - The player's gold.

`bool HasTarget` - Indicates whether the player currently has a target selected.

`bool Loaded` - Indicates whether the player's avatar is loaded.

`bool AllSkillsAvailable` - Indicates whether all of the player's skills have cooled down.

`bool AFK` - Indicates whether the player is AFK.

`PointF Position` - Gets the player's current position.

`int WalkSpeed` - Gets or sets the player's walk speed.

`int Scale` - Gets or sets the player's avatar drawing scale (client side).

### Methods
`void Pickup(params string[] items)` - Picks up the specified items.

`void PickupFast(params string[] items)` - Picks up the specified items without waiting for them to be picked up (equivalent to `Pickup` without `SafeTimings`).

`void RejectExcept(params string[] items)` - Rejects all drops except for the given ones.

`bool DropExists(string name)` - Checks whether the specified drop exists.

`void PickupAll()` - Picks up all available drops.

`void RejectAll()` - Rejects all available drops.

`void WalkTo(float x, float y)` - Walks to the specified point.

`void SetSpawnPoint()` - Sets the player's spawn point to the current cell.

`void LoadBank()` - Loads the player's bank.

`void CancelTarget()` - Untargets the currently targeted player/monster.

`void ApproachTarget()` - Approaches the currently selected target.

`void Attack(string name)` - Attacks the monster with the specified name.

`void Attack(Monster monster)` - Attacks the specified monster instance.

`void Kill(string name)` - Attacks the specified monster until it is dead.

`void Kill(Monster monster)` - Attacks the specified monster instance until it is dead.

`void Hunt(string name)` - Searches the current room for a monster with the given name and jumps to that monster's cell to kill it. To specify multiple monster names, separate them in `name` with a `'|'` character.

`void HuntForItem(string name, string item, int quantity, bool tempItem = false, bool rejectElse = true)` - Hunts the specified monster(s) until the specified quantity of an item is obtained.

`void HuntForItem(string[] names, string item, int quantity, bool tempItem = false, bool rejectElse = true)` - Overload for `HuntForItem` where an array of names can be passed. This is equivalent to separating monster names with a `'|'`.

`void HuntForItem(List<string> names, string item, int quantity, bool tempItem = false, bool rejectElse = true)` - Another overload for `HuntForItem` where a list of monster names can be passed.

`void HuntForItems(string name, string[] items, int[] quantities, bool tempItems = false, bool rejectElse = true)` - Hunts the specified monster(s) until the specified quantities of items are obtained. The same overloads that exist for `HuntForItem` exist for this method.

`void AttackPlayer(string name)` - Attacks the specified player.

`void KillPlayer(string name)` - Attacks the specified player until they are dead.

`void AddTempItem(string name, int num = 100)` - **This has been patched**. This used to give the player as much of the specified temporary item as they wanted.

`void UseSkill(int index)` - Uses the skill at the given index.

`void Jump(string cell, string pad)` - Jumps to the specified cell and pad.

`void Join(string map, string cell = "Enter", string pad = "Spawn")` - Joins the map and jumps to the specified cell and pad (you need not specify the cell and pad as they have default values). This method will keep attempting to join the specified map with a 2.5 second delay until it succeeds.

`void JoinGlitched(string map)` - Attempts to join a glitched room (decrements the room number until success). This just calls `Join(map + "--9999")` and then `Join(map + "--9998")` and so on.

`void Goto(string name)` - Goes to the specified player.

`void EquipItem(string item)` - Equips the item with the given name.

`void EquipItem(int id)` - Equips the item with the specified id.

`void OpenBank()` - Opens the player's bank.

`void Rest(bool full = false)` - Rests the player. If `full` is true, the bot will wait until the player's health and mana are full.

`bool IsBoostActive(Item.BoostTypes boost)` - Checks if the specified boost is active.

`void UseBoost(int id)` - Uses the boost with the given id.

#### Examples
The main use of `ScriptInterface#Player` is movement and combat. This is especially useful in fulfilling quest requirements. Examples can be found at the end of the documentation.