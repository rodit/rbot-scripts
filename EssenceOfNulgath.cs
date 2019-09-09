using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Skills.StartTimer();
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Essence of Nulgath");
		
		bot.Player.Join("citadel", "m22", "Right");
		bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
		
		bot.Monsters.HuntCellBlacklist.Add("Boss2");
		bot.Player.HuntForItem("Dark Makai", "Essence of Nulgath", int.MaxValue);
	}
}