using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Basic Weapon Kit");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(2136);
			
			bot.Player.Join("forest");
			bot.Player.HuntForItem("Zardman Grunt", "Zardman's StoneHammer", 1);
			
			bot.Player.Join("pyramid");
			bot.Player.HuntForItem("Mummy", "Triple Ply Mummy Wrap", 7, true);
			bot.Player.HuntForItem("Golden Scarab", "Golden Lacquer Finish", 1, true);
			
			bot.Player.Join("noobshire");
			bot.Player.HuntForItem("Horc Noob", "Noob Blade Oil", 1, true);
			
			bot.Player.Join("lair");
			bot.Player.HuntForItem("Bronze Draconian", "Bronze Brush", 1, true);
			
			bot.Player.Join("bloodtusk");
			bot.Player.HuntForItem("Rock", "Rocky Stone Sharpener", 1, true);
			
			bot.Player.Join("farm");
			bot.Player.HuntForItem("Scarecrow", "Burlap Cloth", 4, true);
			
			bot.Quests.EnsureComplete(2136);
			
			bot.Wait.ForDrop("Basic Weapon Kit");
			bot.Player.Pickup("Basic Weapon Kit");
		}
	}
}
