using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Quests.EnsureAccept(2105);
		
		bot.Player.Join("doomwood");
		bot.Player.HuntForItem("Doomwood Treeant", "Paladaffodil", 25, true);
	}
}
