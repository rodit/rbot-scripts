Shops
======
It is very simple to buy and sell items using `ScriptInterface#Shops`.

#### Properties
`List<Item> ShopItems` - Gets a list of items in the last (or currently) loaded shop.

`bool IsShopLoaded` - Checks whether a shop is currently loaded.

#### Methods
`Load(int id)` - Loads the shop with the specified id.

`BuyItem(int shopId, string name)` - Buys the item with the specified name from the shop with id `shopId`. This will load the shop first.

`BuyItem(string name)` - Buys the item with the specified name from the last (or currently) loaded shop.

`SellItem(string name)` - Sells the item with the specified name from the player's inventory.

`LoadHairShop(int id)` - Loads the hair shop with the specified id.

`LoadArmourCustomizer()` - Loads the armour customizer.

These methods are very easy to use.