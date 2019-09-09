using RBot;

public class Script {

	//Inventory space required: 22
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.SkipCutsenes = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        bot.Bank.ToInventory("Dark Crystal Shard");
        bot.Bank.ToInventory("Tainted Gem");
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Bank.ToInventory("Diamond of Nulgath");
        bot.Bank.ToInventory("Totem of Nulgath");
        bot.Bank.ToInventory("Unidentified 10");
        bot.Bank.ToInventory("Unidentified 13");
        bot.Bank.ToInventory("Unidentified 26");
        
    	bot.Quests.EnsureAccept(584);
		bot.Quests.EnsureAccept(2859);
		bot.Player.Join("underworld");
		bot.Player.HuntForItem("Legion Fenrir", "Nulgath Rune 3", 1, true);
		bot.Player.AddTempItem(15390, 100000);
		bot.Player.Join("yulgar");
		bot.Shops.Load(16);
		while(!bot.Inventory.Contains("Unidentified 26")){
			if(bot.Player.Gold < 500000){
				bot.Player.Join("greenguardwest");
				bot.Quests.EnsureAccept(236);
				bot.Player.HuntForItem("Big Bad Boar", "Were Egg", 1, true);
				bot.Player.AddTempItem(1051, 100000);
				while(bot.Player.Gold < 500000){
					bot.Quests.EnsureAccept(236);
					bot.Quests.EnsureComplete(236);
					bot.Wait.ForDrop("Berserker Bunny");
					bot.Player.Pickup("Berserker Bunny");
					bot.Shops.SellItem("Berserker Bunny");
				}
				bot.Player.Join("yulgar");
			}
			while(bot.Player.Gold >= 100000 && !bot.Inventory.Contains("Unidentified 26")){
				if(!bot.Inventory.Contains("Blood Cloak"))
					bot.Shops.BuyItem(16, "Blood Cloak");
				bot.Quests.EnsureAccept(2859);
				bot.Quests.EnsureComplete(2859);
				bot.Wait.ForDrop("DuckStick2000");
				bot.Player.Pickup("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath (non-mem)", "Unidentified 26");
				bot.Player.RejectExcept("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath (non-mem)", "Unidentified 26");
			}
		}
		
		if(!bot.Inventory.ContainsTempItem("Nulgath Rune 9")){
			if(bot.Map.Name != "tercessuinotlim"){
		        bot.Player.Join("citadel", "m22", "Right");
	            bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
            }
            
            bot.Player.HuntForItem("Dark Makai", "Nulgath Rune 9", 1, true);
		}
		
		FarmNulgath(bot, "Tainted Gem", 5);
		
		bot.Quests.EnsureComplete(584);
		bot.Wait.ForDrop("Unidentified 27");
		bot.Player.Pickup("Unidentified 27");
	}
	
	public void FarmNulgath(ScriptInterface bot, string item, int quantity){
		bot.Bank.ToInventory(item);
		if(bot.Inventory.Contains(item, quantity))
			return;
        
        bot.Quests.EnsureAccept(2566);
        bot.Player.Join("gilead");
        bot.Player.HuntForItem("Mana Elemental", "Charged Mana Energy for Nulgath", 1, true);
        bot.Player.Join("elemental");
        bot.Player.HuntForItem("Mana Golem", "Mana Energy for Nulgath", 1, true);
        bot.Player.AddTempItem(6135, 100000);
        bot.Player.AddTempItem(15385, 100000);
        bot.Player.Jump("Enter", "Spawn");
        
        int accum = 0;
        while(!bot.Inventory.Contains(item, quantity)){
            bot.Quests.EnsureAccept(2566);
            bot.Quests.EnsureComplete(2566);
            
            accum++;
            if(accum == 10){
            	accum = 0;
            	bot.Player.Pickup("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
            	bot.Player.RejectExcept("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
            }
		}
	}
}
