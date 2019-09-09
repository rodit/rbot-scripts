using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.Join("doomvault");
		bot.Quests.EnsureAccept(4180);
		bot.Player.HuntForItem("Binky", "Cape Shard", 1);
		bot.Quests.EnsureComplete(4180);
		
		bot.Wait.ForDrop("Cape Shard");
		bot.Player.Pickup("Cape Shard");
	}
}
