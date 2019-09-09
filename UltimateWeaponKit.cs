using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Ultimate Weapon Kit");
		bot.Bank.ToInventory("Spirit Orb");
		bot.Bank.ToInventory("Loyal Spirit Orb");
		bot.Bank.ToInventory("Bright Aura");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(2163);
			
			bot.Player.Join("dragonplane");
			bot.Player.HuntForItem("Earth Elemental", "Great Ornate Warhammer", 1);
			
			bot.Player.Join("kitsune");
			bot.Player.HuntForItem("Kitsune", "No. 1337 Blade Oil", 1, true);
			
			bot.Player.Join("greendragon");
			bot.Player.HuntForItem("Greenguard Dragon", "Greenguard Dragon Hide", 3, true);
			
			bot.Player.Join("sandcastle");
			bot.Player.HuntForItem("Chaos Sphinx", "Gold Brush", 1, true);
			
			bot.Player.Join("roc");
			bot.Player.HuntForItem("Rock Roc", "Sharp Stone Sharpener", 1, true);
			
			bot.Player.Join("citadel");
			bot.Player.HuntForItem("Grand Inquisitor", "Blinding Lacquer Finish", 1, true);
			
			bot.Player.Join("crashsite");
			bot.Player.HuntForItem("ProtoSartorium", "Non-abrasive Power Powder", 1, true);
			
			bot.Player.Join("djinn");
			bot.Player.HuntForItem("Harpy", "Suede Travel Case", 1, true);
			
			bot.Quests.EnsureComplete(2163);
			
			bot.Wait.ForDrop("Ultimate Weapon Kit");
			bot.Player.Pickup("Ultimate Weapon Kit", "Loyal Spirit Orb", "Bright Aura", "Spirit Orb");
		}
	}
}
