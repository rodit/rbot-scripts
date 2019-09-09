using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		//Stonewrit 2933
		//Handle 2934
		//Hilt 2935
		//Blade 2936
		//Runes 2937
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.EquipItem("Chaos Slayer Mystic");
		if(!bot.Bank.Contains("Legendary Stonewrit")){
			bot.Quests.EnsureAccept(2933);
			bot.Player.Join("etherwardes");
			bot.Player.HuntForItem("Air Dragon Warrior|Earth Dragon Warrior|Fire Dragon Warrior|Water Dragon Warrior", "Stonewrit Found!", 1);
			bot.Quests.EnsureComplete(2933);
			bot.Wait.ForDrop("Legendary Stonewrit");
			bot.Player.Pickup("Legendary Stonewrit");
		}
		
		if(!bot.Bank.Contains("Legendary Handle")){
			bot.Quests.EnsureAccept(2934);
			bot.Player.Join("gilead");
			bot.Player.HuntForItem("Earth Elemental|Fire Elemental|Water Elemental|Wind Elemental", "Handle Found!", 1);
			bot.Quests.EnsureComplete(2934);
			bot.Wait.ForDrop("Legendary Handle");
			bot.Player.Pickup("Legendary Handle");
		}
		
		if(!bot.Bank.Contains("Legendary Hilt")){
			bot.Quests.EnsureAccept(2935);
			bot.Player.Join("battleunderb");
			bot.Player.HuntForItem("Skeleton Warrior|Skeleton Fighter", "Hilt Found!", 1);
			bot.Quests.EnsureComplete(2935);
			bot.Wait.ForDrop("Legendary Hilt");
			bot.Player.Pickup("Legendary Hilt");
		}
		
		if(!bot.Bank.Contains("Legendary Blade")){
			bot.Quests.EnsureAccept(2936);
			bot.Player.Join("hydra");
			bot.Player.HuntForItem("Hydra Head", "Blade Found!", 1);
			bot.Quests.EnsureComplete(2936);
			bot.Wait.ForDrop("Legendary Blade");
			bot.Player.Pickup("Legendary Blade");
		}
		
		bot.Options.PrivateRooms = false;
		bot.Player.EquipItem("Void Highlord");
		if(!bot.Bank.Contains("Legendary Runes")){
			bot.Quests.EnsureAccept(2937);
			bot.Player.Join("djinn");
			bot.Player.HuntForItem("Tibicenas", "Runes Found!", 1);
			bot.Quests.EnsureComplete(2937);
			bot.Wait.ForDrop("Legendary Runes");
			bot.Player.Pickup("Legendary Runes");
		}
	}
}
