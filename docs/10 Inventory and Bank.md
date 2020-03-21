Inventory and Bank
======

The player's inventory and bank can be managed through `ScriptInterface#Inventory` and `ScriptInterface#Bank` respectively.

### Inventory
You can query and manage the player's inventory through `ScriptInterface#Inventory`.

#### Properties
`List<Item> Items` - The player's inventory as a list of items.

`List<TempItem> TempItems` - The player's temporary inventory as a list of temp items.

#### Methods
`bool Contains(string item, int quantity = 1)` - Checks whether the player's inventory contains the specified item in the specified quantity.

`bool ContainsTempItem(string item, int quantity = 1)` - Checks whether the player's inventory contains the specified temp item in the specified quantity.

`void ToBank(string item)` - Moves the specified item from the player's inventory to their bank.

`int GetQuantity(string item)` - Gets the specified item's quantity in the player's inventory.

`Item GetItemByName(string name)` - Gets the `Item` instance for the item in the player's inventory with the given name.

`Item GetItemById(int id)` - Gets the `Item` instance for the item in the player's inventory with the given id.

`int GetTempQuantity(string name)` - Gets the specified temp item's quantity in the player's temporary inventory.

`TempItem GetTempItemByName(string name)` - Gets the `TempItem` instance for the temp item in the player's temporary inventory with the given name.

`void DeleteItem(string name, int quantity)` - Deletes the item from the player's inventory in the given quantity.

`void BankAllCoinItems()` - Transfers all AC items to the bank from the player's inventory. This is useful at the start of a script to free up inventory space.

### Bank
The player's bank can also be managed through `ScriptInterface#Bank`. However, before using this object, you should load the player's bank through `ScriptPlayer#LoadBank`. The client will otherwise think the bank is empty. The bank should typically be loaded at the start of the script.

#### Properties
`List<Item> BankItems` - The player's bank as a list of items.

`int Slots` - The total number of bank slots the player has.

`int UsedSlots` - The numer of bank slots currently occupied by the player.

`int FreeSlots` - Calculates `Slots - UsedSlots`.

#### Methods
`bool Contains(string item, int quantity = 1)` - Checks if the bank contains the given item in the given quantity.

`void Swap(string invItem, string bankItem)` - Swaps the item with name `invItem` in the player's inventory with the item with name `bankItem` in the player's bank.

`void ToInventory(string name)` - Moves the given item from the player's bank to their inventory.

`void StackGlitch(string item)` - **This is patched**. This used to perform the bank stack glitch to bypass standard stack sizes.

### Notes
Inventory and bank management is typically done at the start of a script where options are set and skills are set up. It can also be done as quests are being completed or as drops are being picked up if inventory space is very limited. Remember to load the bank before attempting to transfer items from it.