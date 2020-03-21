Events
======
The bot can listen for certain events and your script can attach its own listeners to handle these events. This is done through the `ScriptInterface#Events` object.

The following events can be listened for:

- `PlayerDeath()` - Triggered when the player dies.
- `MonsterKilled()` - Triggered when a monster that the player has aggrevated is killed.
- `QuestAccepted(int id)` - Triggered when a quest is accepted by the bot.
- `QuestTurnedIn(int id)` - Triggered when a quest is turned in by the bot.
- `MapChanged(string map)` - Triggered when the map changes.
- `CellChanged(string map, string cell, string pad)` - Triggered when the cell is changed.
- `ReloginTriggered(bool kicked)` - Triggered when a relogin is triggered.
- `ExtensionPacketReceived(dynamic packet)` - Triggered when an extension packet is received from the server.

Event handlers are cleared when a script stops or starts. To manually clear event handlers use `ScriptEvents#ClearHandlers()`, although this is typically not necessary.

#### Listening for Events
To attach your own listener to an event, you can use the typical C# syntax for adding event handlers. All event handlers take a first argument which is the current instance of the `ScriptInterface` and some take a second argument (shown in the list above). For example:

```csharp
bot.Events.PlayerDeath += b => {
    b.Log("Player died.");
};
```

will log `"Player died"` every time the player dies. Another example:

```csharp
bot.Events.MapChanged += (b, map) => {
    b.Log("Player is in map " + map + ".");
};
```

will log `"Player is in map {map name}."` whenever the map changes.

I'm sure there are more imaginitive uses for these events but I have kept it simple for the examples.