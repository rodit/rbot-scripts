Options
======
The bot has a range of options that can be changed through the script interface. Some of these options can be changed through the UI as well. Changes to options in a script will update their state in the UI accordingly.

#### Boolean Options
These options can be set to `true` or `false` (enabled or disabled).

`SafeTimings` - Forces the bot to wait for any action taken to complete before continuing execution of the script, with a 5 second timeout

`ExitCombatBeforeQuest` - Ensures a player is out of combat before attempting to turn in quests. This is done by jumping to the player's current cell and pad.

`SkipCutsenes` - Forces all cutsenes in the game to be skipped.

`PrivateRooms` - All calls to `Join` are forced to transfer to a random room.

`Magnetise` - Causes any targeted monster to teleport to the player.

`LagKiller` - Removes the world from the stage to drastically reduce CPU load while the bot is running.

`AggroMonsters` - Causes all living monsters in the room to attack the player. As a result, when any monster in the room is killed, the player gets the reward.

`InfiniteRange` - Allows the player to attack monsters from any distance.

`RestPackets` - Sends a rest packet every second while the player is not in combat, causing the player to heal.

`DisableFX` - Disables all player animations. This can slightly reduce CPU load.

`HidePlayers` - Hides all player avatars except the user's.

`StopOnDisconnect` - Deprecated - don't use it.

`AutoRelogin` - Enables auto-relogin. When the player disconnects or the game is taking too long to load, the client will logout and relogin, and restart the loaded script.

`AutoReloginAny` - When relogging in, the client will pick the first server that isn't the last server the player was connected to. This is typically unnecessary to use.

`SafeRelogin` - Causes a 75 second delay before attempting a relogin. This is typically unnecessary to use.

#### Other Options
These options have various types and can be set accordingly.

`RunOnExit` - A string that, if set, will indicate a program to run when the script finishes.

`WalkSpeed` - An integer that sets the player's walking speed. The default is `8` and the maximum is `32`.

`LoadTimeout` - The time in milliseconds that the game is allowed to load before it is considered to be a timeout, and an autorelogin is triggered. The default is `10000` (10 seconds).

`HuntDelay` - The minimum time in milliseconds between jumping between cells when hunting for monsters (using `Hunt`, or any method that uses it). The default is `1000` (1 second).

`CustomName` - Sets the player's name on the client side.

`CustomGuild` - Sets the player's guild on the client side.

Some options can be set through the UI. All options can be set programatically in a script as follows:

```csharp
using RBot;

public void ScriptMain(ScriptInterface bot)
{
	bot.Options.SafeTimings = true;
	bot.Options.InfiniteRange = true;
	bot.Options.CustomName = "ARTIX";
}
```

**Note:** It is strongly recommended that `SafeTimings` is always enabled so you do not have to manage the timings of the bot yourself.