using RBot;
using System.Linq;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Bank.ToInventory("Essence of Nulgath");
		bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
		bot.Bank.ToInventory("Gem of Nulgath");
		//4778
		
		if(bot.Map.Name != "tercessuinotlim"){
	        bot.Player.Join("citadel", "m22", "Right");
            bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
        }
        
		while(!bot.ShouldExit() && !bot.Inventory.Contains("Gem of Nulgath", 150)){
			bot.Quests.EnsureAccept(4778);
			
			bot.Player.HuntForItem("Dark Makai", "Essence of Nulgath", 60);
			
			bot.Player.Jump("Enter", "Spawn");
			bot.Quests.EnsureComplete(4778, 6136);
			
			bot.Wait.ForDrop("Gem of Nulgath");
			bot.Player.Pickup("Gem of Nulgath");
		}
	}
}
