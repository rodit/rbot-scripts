using RBot;

public class Script{

	public void ScriptMain(ScriptInterface bot){
		bot.Skills.StartTimer();
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Quests.EnsureAccept(318);
		
		bot.Player.Join("well", "Boss", "Spawn");
		while(!bot.Inventory.ContainsTempItem("Black Knight Leg Piece"))
			bot.Player.Kill("Gell oh no");
		
		bot.Player.Join("greendragon", "Boss", "Spawn");
		while(!bot.Inventory.ContainsTempItem("Black Knight Chest Piece"))
			bot.Player.Kill("Greenguard Dragon");
		
		bot.Player.Join("deathgazer", "Enter", "Spawn");
		while(!bot.Inventory.ContainsTempItem("Black Knight Shoulder Piece"))
			bot.Player.Kill("Deathgazer");
		
		bot.Player.Join("trunk", "Enter", "Spawn");
		while(!bot.Inventory.ContainsTempItem("Black Knight Arm Piece"))
			bot.Player.Kill("Greenguard Basilisk");
		
		bot.Quests.EnsureComplete(318);
		
		bot.Wait.ForPickup("Black Knight Orb");
		bot.Player.Pickup("Black Knight Orb");
	}
}