using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Skills.StartTimer();
		ManaGolem(bot);
	}
	
	public void ManaGolem(ScriptInterface bot){
        bot.Inventory.BankAllCoinItems();
        
        bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        bot.Bank.ToInventory("Voucher of Nulgath");
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Bank.ToInventory("Dark Crystal Shard");
        bot.Bank.ToInventory("Tainted Gem");
        bot.Bank.ToInventory("Totem of Nulgath");
        bot.Bank.ToInventory("Diamond of Nulgath");
        
        while(!bot.ShouldExit()){
            bot.Quests.EnsureAccept(2566);
            
            if(!bot.Inventory.ContainsTempItem("Charged Mana Energy for Nulgath", 5)){
                bot.Player.Join("gilead", "r8", "Down");
                while(!bot.Inventory.ContainsTempItem("Charged Mana Energy for Nulgath", 5))
                    bot.Player.Kill("Mana Elemental");
            }
            
            if(!bot.Inventory.ContainsTempItem("Mana Energy for Nulgath", 1)){
                bot.Player.Join("elemental", "r5", "Down");
                while(!bot.Inventory.ContainsTempItem("Mana Energy for Nulgath", 1))
                    bot.Player.Kill("Mana Golem");
                bot.Player.RejectAll();
            }
            
            bot.Player.Jump("Enter", "Spawn");
            
            bot.Quests.EnsureComplete(2556);
            
            bot.Player.Pickup("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
        }
    }
}
