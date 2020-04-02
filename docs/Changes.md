## Changes
### Version 2.2
---
#### ScriptInterface Changes
Added methods to get actionscript objects and call actionscript functions:
- `T GetGameObject<T>(string path)` - Gets the game object at the given path (actionscript property name) and deserializes it to type T. For example:
    ```csharp
    double haste = bot.GetGameObject<double>("world.myAvatar.sta.$tha");
    ```
    This will get the player's haste stat.

- `T GetArrayObject<T>(string path, int index)` - Gets the object at the index in the given array.

- `T CallGameFunction<T>(string path)` - Calls a function in game and deserializes the return to type T. For example:
    ```csharp
    bot.CallGameFunction<object>("world.resPlayer");
    ```
    This will respawn the player. Since `world.resPlayer()` has `void` return type, deserializing to an `object` should allow for the call to be successful.

Calling these methods with no type paramater (e.g. `bot.GetGameObject("world.myAvatar.pnm")`) will return a string containing the result of the call serialized with JSON. You can deserialize or view this result as you wish.

#### ScriptPlayer Changes
You can now get a list of the player's factions and information about them (rep, rank etc) through the `ScriptPlayer#Factions` property.

You can also get the player's currently targeted monster through `ScriptPlayer#Target`.

Other fields have also been added to `ScriptPlayer`:
- `int ID`
- `int XP`
- `int RequiredXP`

See `7. Player` for more information.

#### Map Player Information
You can retrieve information about players in the current map and current cell with `ScriptMap#Players` and `ScriptMap#CellPlayers`. See `9. Map` for more information.

#### Hunt Changes
There is a new option `ScriptOptions#HuntPriority` which allows for some control over how targets are chosen when hunting. This option takes any of the following values from the `HuntPriorities` enum:
- `HuntPriorities.None` - Default hunting behaviour - selects based on the game's order of monsters.
- `HuntPriorities.LowHP` - Prioritises targets with low HP.
- `HuntPriorities.HighHP` - Prioritises targets with high HP.
- `HuntPriorities.Close` - Prioritises targets in the same cell.

Another option `ScriptOptions#HuntBuffer` allows you to configure how many monsters should be killed before picking up drops. This can speed up hunting when many monsters must be killed to complete a quest. This defaults to `1`.

#### Configurable Script Options
You can now add options which generate a UI to configure your script before it is run. Options are persistent and saved in the `options` directory. See `14. Script Options` for more information.

#### Script Runtime Variables
A new way of managing bank/inventory has been added through `ScriptInterface#Runtime`. You can `require` items which you want in the player's inventory for the script as follows:

```csharp
bot.Player.LoadBank();
bot.Runtime.Require("Required Item 1");
bot.Runtime.Require("Required Item 2");
bot.Player.BankAllCoinItems();
```

Calling `Require` will check if the item is in the player's bank and, if it is, will move it into the player's inventory. It also prevents the item from being moved into the bank by calls to `ScriptPlayer#BankAllCoinItems`.

You can also check if the bank is loaded through the boolean property `ScriptRuntimeVars#BankLoaded`.

#### Plugin System
A plugin system has been added to RBot. See `15. Plugins` for more information.

#### AFK Event
There is now an event that fires when the player goes AFK - `ScriptEvents#PlayerAFK`. The player going AFK while running a script typically means something has gone wrong. It is a good idea to force a relogin when this happens (`bot.Player.Logout()` will trigger a relogin if auto relogin is enabled and setup).

#### Bank Loading
`ScriptPlayer#LoadBank()` has been redefined with an optional `bool waitForLoad` parameter which defaults to true. If true, the script will wait for the bank to load before continuing execution. For example:

```csharp
bot.Player.LoadBank(false);
```

will disable this check.

#### Loader Window Changes
The loader window now allows for multiple quests to be loaded, separating the ids by commas. The grabbing feature of the loader is now far better organized and easy to use.

#### Packet Interceptor
The packet interceptor is now fixed. To use it, login and then open the packet interceptor window. Select a server from the drop down and connect to it. You can add interceptors to read/modify incoming and outgoing packets.

#### Misc
I probably fixed/added other stuff which I have forgotten about.