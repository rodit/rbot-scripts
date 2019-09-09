using RBot;

public class Script {
		
	public void ScriptMain(ScriptInterface bot){
		bot.Skills.StartTimer();
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Inventory.BankAllCoinItems();
		
		while(!bot.ShouldExit() && !bot.Inventory.Contains("Elemental Ink", 50)){
			if(!bot.Inventory.Contains("Mystic Quills", 4)){
				bot.Player.Join("mobius", "Slugfit", "Spawn");
				while(!bot.Inventory.Contains("Mystic Quills", 4)){
					bot.Player.Kill("*");
					bot.Player.Pickup("Mystic Quills");
					bot.Player.RejectExcept("Mystic Quills");
				}
				bot.Player.Jump("Enter", "Spawn");
			}
			
			bot.Player.Join("spellcraft");

			bot.SendPacket("%xt%zm%buyItem%671975%13284%549%1637%");
			bot.Sleep(2500);
			bot.SendPacket("%xt%zm%buyItem%671975%13284%549%1637%");
			bot.Sleep(2500);
		}
	}
}