//test
using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Advanced Weapon Kit");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(2162);
			
			bot.Player.Join("safiria");
			bot.Player.HuntForItem("Chaos Lycan", "WolfClaw Hammer", 1);
			
			bot.Player.Join("hachiko");
			bot.Player.HuntForItem("Dai Tengu", "Superior Blade Oil", 1, true);
			
			bot.Player.Join("guru");
			bot.Player.HuntForItem("LeatherWing", "Leatherwing Hide", 10, true);
			
			bot.Player.Join("lycan");
			bot.Player.HuntForItem("Chaos Vampire Knight", "Silver Brush", 1, true);
			
			bot.Player.Join("mobius");
			bot.Player.HuntForItem("Cyclops Raider", "Brass Awl", 1, true);
			
			bot.Player.Join("darkoviaforest");
			bot.Player.HuntForItem("Lich of the Stone", "Slate Stone Sharpener", 1, true);
			
			bot.Player.Join("airstorm");
			bot.Player.HuntForItem("Lightning Ball", "Shining Lacquer Finish", 1, true);
			
			bot.Player.Join("sandport");
			bot.Player.HuntForItem("Tomb Robber", "Leather Case", 1, true);
			
			bot.Quests.EnsureComplete(2162);
			
			bot.Wait.ForDrop("Advanced Weapon Kit");
			bot.Player.Pickup("Advanced Weapon Kit");
		}
	}
}
