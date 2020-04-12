## Changes
### Version 2.2.1
---
#### Script Options Changes
The script options window is now resizable. The options no longer bug - options are not endlessly re-added when reopening the options window as was the case previously.

#### Patchable Game Client
The game client and all the SWFs used by the game are now loaded through a proxy which runs alongside RBot (and only intercepts HTTP traffic from the game; i.e. it does not intercept any traffic from other applications on your computer). This required 2 additional libraries (EasyHook to hook the WinINet initialization and force just RBot to use the required proxy, and Titanium Web Proxy which is used for the proxy server).

There is now a `patch.txt` file next to the RBot.exe which can be used to patch game client SWF. Already included is a patch that disables client sided quest checks when accepting, as well as one which maximizes client haste. To disable the proxy and game patching, just add

```autoit
; disabled
```
to the top of the `patch.txt` file.

The syntax of patches is as follows:

```autoit
[SWF URL]
[N1:]<find>=<replace>
[N2:]<find2>=<replace2>
; ... as many patches for this SWF as you want.
[Different SWF URL]
[N3:]<find3>=<replace3>
```

where `Nx` is the number of times to run the patch, `find` is the hexadecimal string representation of the bytes to find, and `replace` is the hexadecimal string representation of the bytes to replace the found bytes with. The `N:` is entirely optional. If ommited, the patch will run once.

When patching, the SWF is decompressed so patches can be made equivalent to modifying the actionscript bytecode contained in the SWF. For example, adding the following line to `patch.txt`:

```
3:66b44366cf4324ff=66b44366cf432f0c
```

causes the left hand set of bytes (`66b44366cf4324ff`) to be replaced by the right hand set of bytes (`66b44366cf432f0c`) 3 times. This particular bytecode change replaces the player's haste stat with 50% in the 3 calculations it's used with.

#### Quest Changes
I have made some changes to how quest information is gathered from the game. I have tested these changes less extensively than I should have so please keep a copy of 2.2 somewhere just in case they're broken (although I'm pretty sure it's all fine).

The changes are completely backwards compatiable so no changes should be required in scripts (unless you, for some reason, used the drop rates of the rewards of the quest in your script).

#### Other Changes
As usual, I have probably made other changes/features that I have forgotten about.

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