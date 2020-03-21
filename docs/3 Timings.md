Timings
======
If you enable `SafeTimings` as recommended, you can ignore most of this document. The `ScriptWait` class has many methods useful for pausing the bot's execution until a desired condition is met.

#### Sleeping
If you would simply like to pause exeuction for a specific length of time, you can do this easily using:

```csharp
bot.Sleep(time);
```

where `time` is the time in milliseconds to sleep. For example,

```csharp
bot.Sleep(1000);
```

will sleep the bot for 1000 milliseconds (1 second).

#### Waiting
There are also many actions that can be waiting for using `ScriptInterface#Wait`. All of these methods have a default `timeout` parameter ommited as this typically does not need to be modified. The return types of these methods are mostly irellevant so they have also been ommited.

If `SafeTimings` is enabled, these methods are used by default to wait for actions to complete.

`ForPlayerPosition(float x, float y)` - Waits for the player to move to the given position.

`ForSkillCooldown()` - Waits until all the player's skills are cooled down.

`ForCombatExit()` - Waits for the player to be out of combat.

`ForMonsterDeath()` - Waits for the player to have no target.

`ForMonsterSpawn(string name)` - Waits for a monster with the specified name to exist (and be alive) in the current cell.

`ForFullyRested()` - Waits for the player to have full health and mana.

`ForMapLoad(string map)` - Waits for the current map name to match `map`. This map name excludes any room numbers.

`ForCellChange(string cell)` - Waits for the current cell name to match `cell`.

`ForPickup(string item)` - Waits for the drop with name `item` to be picked up. This actually waits until that drop no longer exists, which is equivalent.

`ForDrop(string item)` - Waits for the drop with name `item` to exist.

`ForItemSell(string item, int quantity)` - Waits for the specified item to be sold with the specified quantity. This actually waits for the item to no longer exist in the player's inventory in the given quantity.

`ForItemEquip(int id)` - Waits for the item with the specified id to be equipped.

`ForItemEquip(string item)` - Waits for the item with the specified name to be equipped.

`ForBankToInventory(string item)` - Waits for the specified item to be moved from the player's bank to their inventory. This actually waits for the item to no longer exist in the bank.

`ForInventoryToBank(string item)` - Waits for the specified item to be moved from the player's inventory to their bank. This actually waits for the itme to no longer exist in the player's inventory.

`ForQuestAccept(int id)` - Waits for the quest with the specified id to be accepted.

`ForQuestComplete(int id)` - Waits for the quest with the specified id to be turned in (no longer accepted).

`For(Func<object> func, object val)` - Waits for the function `func` to return `val`.

`ForTrue(Func<bool> func)` - Waits for `func` to return `true`.

`ForActionCooldown(GameActions action)` - Waits for the specified game action to cool down.

#### Examples
Even when using `SafeTimings`, it is sometimes suitable to use these wait methods. For example, when turning in a quest, it is recommended you do the following:

```csharp
bot.Quests.EnsureComplete(id);
bot.Wait.ForDrop(reward);
bot.Player.Pickup(reward);
```

where `id` is the quest id you are turning in and `reward` is the name of the reward from the quest you would like to obtain. This ensures that the quest reward is actually obtained as there can be a small delay between turning in a quest and its reward appearing.

#### Handlers and Scheduling
__Handlers__

If you would like to run code repeatedly alongside your script at a fixed interval, you can do so using a `ScriptTimedHandler`. The best way to do this is through the `ScriptInterface#RegisterHandler(int ticks, Action<ScriptInterface> func)` method. This method takes a number of `ticks` (the interval in units of 250ms), and the function, `func`, to be run.

For example,

```csharp
bot.RegisterHandler(2, b => {
    b.Log("Test");
});
```

will log `"Test"` every 500ms.

Handlers are cleared when a script stops or when a new script starts running.

__Scheduling__

If you want to schedule some code to run once after a set period of time, you can use `ScriptInterface#Schedule(int delay, Action<ScriptInterface> func)` where `delay` is the time in ms before the code is run, and `func` is the function to run.

For example,

```csharp
bot.Schedule(500, b => {
    b.Log("Test");
});
```

will log `"Test"` once after 500ms.