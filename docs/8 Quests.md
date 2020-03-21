Quests
======
Quests can be loaded, accepted and completed through `ScriptInterface#Quests`.

#### Properties
`List<Quest> ActiveQuests` - A list of currently accepted quests.

`List<Quest> CompletedQuests` - A list of currently accepted quests which are ready to turn in.

`List<Quest> QuestTree` - A list of all quests that have been loaded in the current session.

#### Methods
`void Load(int id)` - Loads the quest with the given id.

`void Accept(int id)` - Accepts the quest with the specified id. This requires the quest to be loaded first. `EnsureAccept` should always be used instead of this method (see below).

`void EnsureAccept(int id)` - Attempts to accept the quest with the specified id until it is successful. This does not require the quest to be loaded first.

`void Complete(int id, int itemId = -1, bool special = false)` - Completes the quest with the specified id. This requires the quest to be loaded first. `itemId` is the id of the item to obtain for quests with optional rewards. I don't really know what a `special` quest is but maybe you do. Again, `EnsureComplete` should always be used instead of this.

`void EnsureComplete(int id, int itemId = -1, bool special = false)` - Attempts to turn in the quest with the specified id until it is successful. This does not require the quest to be loaded first.

`bool IsInProgress(int id)` - Checks whether the specified quest is currently accepted.

`bool CanComplete(int id)` - Checks whether the given quest can be turned in.

`bool IsDailyComplete(int id)` - Checks whether the given quest is a daily quest and that the quest has already been completed today.

#### The Quest Class
Some properties give lists of `Quest` objects. These objects have the following properties:

`string Name` - The name of the quest.

`int ID` - The id of the quest.

`List<Item> Requirements` - The required items/temp items to turn in the quest.

`List<Item> Rewards` - The rewards from turning in the quest.

These properties may come in use but are typically not that important if you read the wiki page for your quest and you know what you need to do to complete it.